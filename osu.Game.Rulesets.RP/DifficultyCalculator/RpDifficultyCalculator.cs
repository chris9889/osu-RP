// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.DifficultyCalculator
{
    public class RpDifficultyCalculator : DifficultyCalculator<BaseRpObject>
    {
        /// <summary>
        ///     HitObjects are stored as a member variable.
        /// </summary>
        internal List<RpHitObjectDifficulty> DifficultyHitObjects = new List<RpHitObjectDifficulty>();

        /// <summary>
        ///     In milliseconds. For difficulty calculation we will only look at the highest strain value in each time interval of
        ///     size STRAIN_STEP.
        ///     This is to eliminate higher influence of stream over aim by simply having more HitObjects with high strain.
        ///     The higher this value, the less strains there will be, indirectly giving long beatmaps an advantage.
        /// </summary>
        protected const double STRAIN_STEP = 400;

        /// <summary>
        ///     The weighting of each strain value decays to this number * it's previous value
        /// </summary>
        protected const double DECAY_WEIGHT = 0.9;

        private const double star_scaling_factor = 0.0675;
        private const double extreme_scaling_factor = 0.5;

        public RpDifficultyCalculator(Beatmap beatmap)
            : base(beatmap)
        {
        }

        protected override void PreprocessHitObjects()
        {
        }

        protected override double CalculateInternal(Dictionary<string, string> categoryDifficulty)
        {
            // Fill our custom DifficultyHitObject class, that carries additional information
            DifficultyHitObjects.Clear();

            foreach (var hitObject in Objects)
                DifficultyHitObjects.Add(new RpHitObjectDifficulty(hitObject));

            // Sort DifficultyHitObjects by StartTime of the HitObjects - just to make sure.
            DifficultyHitObjects.Sort((a, b) => a.BaseHitObject.StartTime.CompareTo(b.BaseHitObject.StartTime));

            if (!CalculateStrainValues()) return 0;

            var speedDifficulty = CalculateDifficulty(DifficultyType.Speed);
            var aimDifficulty = CalculateDifficulty(DifficultyType.Aim);

            // OverallDifficulty is not considered in this algorithm and neither is HpDrainRate. That means, that in this form the algorithm determines how hard it physically is
            // to play the map, assuming, that too much of an error will not lead to a death.
            // It might be desirable to include OverallDifficulty into map difficulty, but in my personal opinion it belongs more to the weighting of the actual peformance
            // and is superfluous in the beatmap difficulty rating.
            // If it were to be considered, then I would look at the hit window of normal HitCircles only, since Sliders and Spinners are (almost) "free" 300s and take map length
            // into account as well.

            // The difficulty can be scaled by any desired metric.
            // In osu!tp it gets squared to account for the rapid increase in difficulty as the limit of a human is approached. (Of course it also gets scaled afterwards.)
            // It would not be suitable for a star rating, therefore:

            // The following is a proposal to forge a star rating from 0 to 5. It consists of taking the square root of the difficulty, since by simply scaling the easier
            // 5-star maps would end up with one star.
            var speedStars = Math.Sqrt(speedDifficulty) * star_scaling_factor;
            var aimStars = Math.Sqrt(aimDifficulty) * star_scaling_factor;

            if (categoryDifficulty != null)
            {
                categoryDifficulty.Add("Aim", aimStars.ToString("0.00"));
                categoryDifficulty.Add("Speed", speedStars.ToString("0.00"));

                var hitWindow300 = 30 /*HitObjectManager.HitWindow300*/ / TimeRate;
                var preEmpt = 450 /*HitObjectManager.PreEmpt*/ / TimeRate;

                categoryDifficulty.Add("OD", (-(hitWindow300 - 80.0) / 6.0).ToString("0.00"));
                categoryDifficulty.Add("AR", (preEmpt > 1200.0 ? -(preEmpt - 1800.0) / 120.0 : -(preEmpt - 1200.0) / 150.0 + 5.0).ToString("0.00"));

                var maxCombo = 0;
                foreach (var hitObject in DifficultyHitObjects)
                    maxCombo += hitObject.MaxCombo;

                categoryDifficulty.Add("Max combo", maxCombo.ToString());
            }

            // Again, from own observations and from the general opinion of the community a map with high speed and low aim (or vice versa) difficulty is harder,
            // than a map with mediocre difficulty in both. Therefore we can not just add both difficulties together, but will introduce a scaling that favors extremes.
            var starRating = speedStars + aimStars + Math.Abs(speedStars - aimStars) * extreme_scaling_factor;
            // Another approach to this would be taking Speed and Aim separately to a chosen power, which again would be equivalent. This would be more convenient if
            // the hit window size is to be considered as well.

            // Note: The star rating is tuned extremely tight! Airman (/b/104229) and Freedom Dive (/b/126645), two of the hardest ranked maps, both score ~4.66 stars.
            // Expect the easier kind of maps that officially get 5 stars to obtain around 2 by this metric. The tutorial still scores about half a star.
            // Tune by yourself as you please. ;)

            return starRating;
        }

        protected bool CalculateStrainValues()
        {
            // Traverse hitObjects in pairs to calculate the strain value of NextHitObject from the strain value of CurrentHitObject and environment.
            var hitObjectsEnumerator = DifficultyHitObjects.GetEnumerator();

            if (!hitObjectsEnumerator.MoveNext()) return false;

            var currentHitObject = hitObjectsEnumerator.Current;
            RpHitObjectDifficulty nextHitObject;

            // First hitObject starts at strain 1. 1 is the default for strain values, so we don't need to set it here. See DifficultyHitObject.
            while (hitObjectsEnumerator.MoveNext())
            {
                nextHitObject = hitObjectsEnumerator.Current;
                nextHitObject.CalculateStrains(currentHitObject, TimeRate);
                currentHitObject = nextHitObject;
            }

            return true;
        }

        protected double CalculateDifficulty(DifficultyType type)
        {
            var actualStrainStep = STRAIN_STEP * TimeRate;

            // Find the highest strain value within each strain step
            var highestStrains = new List<double>();
            var intervalEndTime = actualStrainStep;
            double maximumStrain = 0; // We need to keep track of the maximum strain in the current interval

            RpHitObjectDifficulty previousHitObject = null;
            foreach (var hitObject in DifficultyHitObjects)
            {
                // While we are beyond the current interval push the currently available maximum to our strain list
                while (hitObject.BaseHitObject.StartTime > intervalEndTime)
                {
                    highestStrains.Add(maximumStrain);

                    // The maximum strain of the next interval is not zero by default! We need to take the last hitObject we encountered, take its strain and apply the decay
                    // until the beginning of the next interval.
                    if (previousHitObject == null)
                    {
                        maximumStrain = 0;
                    }
                    else
                    {
                        var decay = Math.Pow(RpHitObjectDifficulty.DECAY_BASE[(int)type], (intervalEndTime - previousHitObject.BaseHitObject.StartTime) / 1000);
                        maximumStrain = previousHitObject.Strains[(int)type] * decay;
                    }

                    // Go to the next time interval
                    intervalEndTime += actualStrainStep;
                }

                // Obtain maximum strain
                maximumStrain = Math.Max(hitObject.Strains[(int)type], maximumStrain);

                previousHitObject = hitObject;
            }

            // Build the weighted sum over the highest strains for each interval
            double difficulty = 0;
            double weight = 1;
            highestStrains.Sort((a, b) => b.CompareTo(a)); // Sort from highest to lowest strain.

            foreach (var strain in highestStrains)
            {
                difficulty += weight * strain;
                weight *= DECAY_WEIGHT;
            }

            return difficulty;
        }

        protected override BeatmapConverter<BaseRpObject> CreateBeatmapConverter() => new BeatmapConvertor();


        //�E�z�E�E
        //protected override BeatmapConverter<BaseRpObject> CreateBeatmapConverter() => new BeatmapConvertor();

        // Those values are used as array indices. Be careful when changing them!
        public enum DifficultyType
        {
            Speed = 0,
            Aim
        }
    }
}
