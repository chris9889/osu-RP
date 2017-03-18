using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type.Special
{
    class RpSpecialGenerator
    {

        //丟進來的參數
        List<ConvertParameter> _parameter;

        public RpSpecialGenerator()
        {

        }

        /// <summary>
        /// 目前預設都是正常模式
        /// </summary>
        /// <param name="scannParameter"></param>
        /// <returns></returns>
        public List<ConvertParameter> Convert(List<ConvertParameter> scannParameter)
        {
            _parameter = scannParameter;
            foreach (ConvertParameter single in _parameter)
            {
                foreach (BaseHitObject divaObject in single.ListConvertedParameter)
                {
                    divaObject.Special = Objects.type.RpBaseHitObjectType.Special.Normal;
                }
            }
            return _parameter;
        }

    }
}
