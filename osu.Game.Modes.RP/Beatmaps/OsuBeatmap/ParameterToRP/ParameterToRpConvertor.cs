// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.ParameterToRP
{
    /// <summary>
    ///     把參數轉成RP物件
    /// </summary>
    internal class ParameterToRpConvertor
    {
        public Beatmap SongBeatmap;

        /// <summary>
        ///     轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<BaseRpObject> Convert(List<ConvertParameter> input)
        {
            //目前所有物件
            var output = ConvertParameterToNote(input);
            //地圖

            //丟入地圖
            RPNoteBindingToBeatmap(output, SongBeatmap);
            //針對曲線重新計算
            RecalculateCurve(output);

            return output;
        }

        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<BaseRpObject> ConvertParameterToNote(List<ConvertParameter> input)
        {
            var output = new List<BaseRpObject>();
            foreach (var single in input)
            {
                if (single is HitObjectConvertParameter)
                    output.AddRange(((HitObjectConvertParameter)single).ListConvertedParameter);

                if (single is ContainerConvertParameter)
                    output.AddRange(((ContainerConvertParameter)single).ListConvertedParameter);
            }
            return output;
        }

        /// <summary>
        /// </summary>
        /// <param name="originalNode"></param>
        /// <returns></returns>
        private void RPNoteBindingToBeatmap(List<BaseRpObject> originalNode, Beatmap songBeatmap)
        {
            //songBeatmap.HitObjects.Clear();
            //這邊是所有的Note，要重新計算
            foreach (var single in originalNode)
                single.SetDefaultsFromBeatmap(songBeatmap);
        }

        /// <summary>
        ///     對曲線重新計算
        /// </summary>
        private void RecalculateCurve(List<BaseRpObject> notes)
        {
            foreach (var single in notes)
                single.Curve.Calculate();
        }
    }
}
