// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Game.Beatmaps;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing.DiffStarCalculator
{
    /// <summary>
    /// in avoid of another GameMode's beatmap change the calculation formula
    /// use this Calculator
    /// </summary>
    public class OriginalBeatmapDifficultyCalculator
    {
        public float CalculateBeatmapDifficulty(Beatmap originalBeatmap)
        {
            try
            {
                int hitObjectNumber = originalBeatmap.HitObjects.Count;
                float totalTime = (float)(originalBeatmap.HitObjects[hitObjectNumber - 1].StartTime - originalBeatmap.HitObjects[0].StartTime)/1000;
                float numti = 1.0f;

                return hitObjectNumber / totalTime * numti;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 100;
            }

        }
    }
}