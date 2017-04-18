// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Audio;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;
using OpenTK;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Generator
{
    /// <summary>
    /// </summary>
    public class HitObjectGenerator
    {
        public List<SingleHitObjectConvertParameter> GeneratorListHitObject(ConvertParameter single)
        {
            foreach (var singleHitObject in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            {
                var singleHitObjects = new List<BaseRpHitObject>();
                for (var i = 0; i < singleHitObject.MultiNumber; i++)
                    singleHitObjects.Add(GenerateRpHitObject(singleHitObject));
                singleHitObject.ListBaseHitObject = singleHitObjects;
            }

            return single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter;
        }

        public RpHitObject GenerateRpHitObject(SingleHitObjectConvertParameter singleHitObject)
        {
            var rpHitObject = new RpHitObject();
            //fake sample
            rpHitObject.Samples.Clear();
            rpHitObject.Samples.Add(
                new SampleInfo
                {
                    Bank = "whistle",
                    Name = "soft"
                }
            );

            //fake position
            rpHitObject.Position = new Vector2(100, 100);

            rpHitObject.StartTime = singleHitObject.StartTime;
            return rpHitObject;
        }
    }
}
