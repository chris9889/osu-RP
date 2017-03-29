// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Beatmaps;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing.TimeSliceCalculator
{
    /// <summary>
    ///     will decide the speed and BPM and other to slide to a better time
    ///     will decide : deltaTime
    /// </summary>
    public class TimeSlicingCalculator
    {
        private Beatmap _beatmap;

        private double maxSliceTime = 2000;

        public void SetBeatmap(Beatmap beatmap)
        {
            _beatmap = beatmap;
        }

        public void SetSliceTime(double slicetime)
        {
            maxSliceTime = slicetime;
        }

        /// <summary>
        ///     slicing from A to B
        /// </summary>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int SlicingFrom(int startIndex)
        {
            var nowIndex = startIndex;
            double totalTime = 0;

            //先算出至少要多少
            while (totalTime < maxSliceTime && nowIndex < _beatmap.HitObjects.Count)
            {
                totalTime = _beatmap.HitObjects[nowIndex].StartTime - _beatmap.HitObjects[startIndex].StartTime;
                nowIndex++;
            }

            if (totalTime > maxSliceTime)
                nowIndex--;

            return nowIndex;
        }
    }
}
