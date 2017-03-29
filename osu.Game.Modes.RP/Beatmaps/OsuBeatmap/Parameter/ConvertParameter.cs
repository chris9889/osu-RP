// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.Osu.Objects;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter
{
    /// <summary>
    ///     轉換用參數
    ///     裡面會儲存一段時間內同時要打擊的所有Note
    ///     會把osu換成RP資料存在這裡
    /// </summary>
    internal class ConvertParameter
    {
        /// <summary>
        ///     原本的物件
        /// </summary>
        public OsuHitObject OsuHitObject;

        /// <summary>
        ///     傳遞嵾數
        /// </summary>
        public BasePassParameter PassParameter = new BasePassParameter();

        /// <summary>
        ///     最後要變回物件
        ///     同一個時間點底下的所有物件
        /// </summary>
        public List<BaseRpObject> ListConvertedParameter = new List<BaseRpObject>();
    }

    /// <summary>
    ///     container才會用到的parameter
    /// </summary>
    internal class ContainerConvertParameter : ConvertParameter
    {
        /// <summary>
        ///     傳遞嵾數
        /// </summary>
        public new ContainerPassParameter PassParameter = new ContainerPassParameter();

        /// <summary>
        ///     最後要變回物件
        ///     同一個時間點底下的所有物件
        /// </summary>
        public new List<ObjectContainer> ListConvertedParameter = new List<ObjectContainer>();
    }

    /// <summary>
    ///     container才會用到的parameter
    /// </summary>
    internal class HitObjectConvertParameter : ConvertParameter
    {
        /// <summary>
        ///     前置掃描時會預先處理好的一些參數
        /// </summary>
        public ScanParameter ScanParameter = new ScanParameter();

        /// <summary>
        ///     傳遞嵾數
        /// </summary>
        public new HitObjectPassParameter PassParameter = new HitObjectPassParameter();

        /// <summary>
        ///     最後要變回物件
        ///     同一個時間點底下的所有物件
        /// </summary>
        public new List<BaseHitObject> ListConvertedParameter = new List<BaseHitObject>();
    }
}
