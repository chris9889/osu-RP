using System.Collections.Generic;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Convert.OsuBeatmap.Parameter
{
    /// <summary>
    /// container才會用到的parameter
    /// </summary>
    class ContainerConvertParameter : ConvertParameter
    {
        /// <summary>
        /// 傳遞嵾數
        /// </summary>
        public new ContainerPassParameter PassParameter = new ContainerPassParameter();

        /// <summary>
        /// 最後要變回物件
        /// 同一個時間點底下的所有物件
        /// </summary>
        public new List<ObjectContainer> ListConvertedParameter = new List<ObjectContainer>();
    }
}