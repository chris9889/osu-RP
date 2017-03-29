// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing.VolocityCalculator
{
    public class ContainerVolocityCalculator
    {
        private float multiple = 1.4f;

        public void UpdateCalculateVolocity()
        {


        }

        public float GetVolocity()
        {
            return 1* multiple;
        }


        public float GetTime()
        {
            return 2000/ multiple;
        }
    }
}