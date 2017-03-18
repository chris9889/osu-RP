using System.Collections.Generic;
using osu.Game.Modes.Osu.Objects;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.OsuToParameter.Scanner;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.OsuToParameter
{
    /// <summary>
    /// 這邊是把Osu物件轉換成處理用參數
    /// </summary>
    class OsuToParameterConvertor
    {
        PrefixScanner prefixScanner = new PrefixScanner();

        public List<HitObjectConvertParameter> Convert(List<OsuHitObject> input)
        {
            List<HitObjectConvertParameter> output = new List<HitObjectConvertParameter>();
            //先把參數都丟進去
            foreach (OsuHitObject single in input)
            {
                HitObjectConvertParameter singleParameter = new HitObjectConvertParameter();
                singleParameter.OsuHitObject = single;
                output.Add(singleParameter);
            }
            //然後預先把要用的參數做掃描
            output=prefixScanner.Convert(output);

            return output;
        }
    }
}
