// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse
{
    public class AnaylseMulti
    {
        public int GetMultiNumber(ConvertParameter single, int i)
        {
            if (single.ContainerConvertParameter.LayoutNumber > 1)
                return CalRandomNumber(single, i) % single.ContainerConvertParameter.LayoutNumber + 1;
            return 1;
        }

        /// <summary>
        ///     產生亂數
        /// </summary>
        /// <param name="single"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private int CalRandomNumber(ConvertParameter single, int i)
        {
            return single.ListRefrenceObject.Count + (int)single.ListRefrenceObject[i].StartTime;
        }
    }
}
