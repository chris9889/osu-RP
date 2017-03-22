// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Beatmaps;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing.TimeSliceCalculator
{

    public class TimeSlicingCalculator
    {
        private Beatmap _beatmap;

        private double minSliceTime = 1000;

        public double maxSliceTime = 2000;

        public void SetBeatmap(Beatmap beatmap)
        {
            _beatmap = beatmap;
        }

        /// <summary>
        /// slicing from A to B
        /// </summary>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int SlicingFrom(int startIndex)
        {
            int nowIndex = startIndex;
            double totalTime = 0;

            //先算出至少要多少
            while (totalTime< maxSliceTime && nowIndex< _beatmap.HitObjects.Count)
            {
                totalTime = _beatmap.HitObjects[nowIndex].StartTime - _beatmap.HitObjects[startIndex].StartTime;
                nowIndex++;
            }

            if (totalTime > maxSliceTime)
            {
                nowIndex--;
            }

            return nowIndex;
        }

        
    }
}