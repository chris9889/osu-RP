using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.ParameterToRP
{
    /// <summary>
    /// 把參數轉成RP物件
    /// </summary>
    class ParameterToRpConvertor
    {
        public Beatmap SongBeatmap;

        /// <summary>
        /// 轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<BaseRpObject> Convert(List<ConvertParameter> input)
        {
            //目前所有物件
            List<BaseRpObject> output = ConvertParameterToNote(input);
            //地圖

            //丟入地圖
            RPNoteBindingToBeatmap(output, SongBeatmap);
            //針對曲線重新計算
            RecalculateCurve(output);

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<BaseRpObject> ConvertParameterToNote(List<ConvertParameter> input)
        {
            List<BaseRpObject> output = new List<BaseRpObject>();
            foreach (ConvertParameter single in input)
            {
                if(single is HitObjectConvertParameter)
                    output.AddRange(((HitObjectConvertParameter)single).ListConvertedParameter);

                if (single is ContainerConvertParameter)
                    output.AddRange(((ContainerConvertParameter)single).ListConvertedParameter);
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalNode"></param>
        /// <returns></returns>
        private void RPNoteBindingToBeatmap(List<BaseRpObject> originalNode, Beatmap songBeatmap)
        {
            //songBeatmap.HitObjects.Clear();
            //這邊是所有的Note，要重新計算
            foreach (BaseRpObject single in originalNode)
            {
                single.SetDefaultsFromBeatmap(songBeatmap);
                //然後把Beatmap 的 HitObjects 重新加入
                //songBeatmap.HitObjects.Add(single);
            }
        }

        /// <summary>
        /// 對曲線重新計算
        /// </summary>
        private void RecalculateCurve(List<BaseRpObject> notes)
        {
            foreach (BaseRpObject single in notes)
            {
                single.Curve.Calculate();
            }
        }
    }
}
