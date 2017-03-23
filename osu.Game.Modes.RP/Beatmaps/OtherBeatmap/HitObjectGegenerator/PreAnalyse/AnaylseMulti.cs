// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
using System;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse
{

    public class AnaylseMulti
    {
        public int GetMultiNumber(ComvertParameter single, int i)
        {
            if (single.ContainerConvertParameter.LayoutNumber > 1)
            {
                //return single.ContainerConvertParameter.LayoutNumber;
                return CalRandomNumber(single, i) % single.ContainerConvertParameter.LayoutNumber + 1;
            }
            return 1;
        }

        /// <summary>
        /// 產生亂數
        /// </summary>
        /// <param name="single"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        int CalRandomNumber(ComvertParameter single, int i)
        {
            return single.ListRefrenceObject.Count + (int)single.ListRefrenceObject[i].StartTime;
        }
    }
}