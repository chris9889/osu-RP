// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type.Special
{
    internal class RpSpecialGenerator
    {
        //丟進來的參數
        private List<ConvertParameter> _parameter;

        /// <summary>
        ///     目前預設都是正常模式
        /// </summary>
        /// <param name="scannParameter"></param>
        /// <returns></returns>
        public List<ConvertParameter> Convert(List<ConvertParameter> scannParameter)
        {
            _parameter = scannParameter;
            foreach (var single in _parameter)
            foreach (BaseHitObject divaObject in single.ListConvertedParameter)
                divaObject.Special = RpBaseObjectType.Special.Normal;
            return _parameter;
        }
    }
}
