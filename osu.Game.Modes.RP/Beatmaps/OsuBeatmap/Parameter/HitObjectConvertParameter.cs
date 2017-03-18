using System.Collections.Generic;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Convert.OsuBeatmap.Parameter
{
    /// <summary>
    /// container才會用到的parameter
    /// </summary>
    class HitObjectConvertParameter : ConvertParameter
    {
        /// <summary>
        /// 前置掃描時會預先處理好的一些參數
        /// </summary>
        public ScanParameter ScanParameter = new ScanParameter();

        /// <summary>
        /// 傳遞嵾數
        /// </summary>
        public new HitObjectPassParameter PassParameter = new HitObjectPassParameter();

        /// <summary>
        /// 最後要變回物件
        /// 同一個時間點底下的所有物件
        /// </summary>
        public new List<BaseHitObject> ListConvertedParameter = new List<BaseHitObject>();
    }
}