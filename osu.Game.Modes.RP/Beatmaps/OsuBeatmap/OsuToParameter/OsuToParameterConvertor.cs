// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.Osu.Objects;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.OsuToParameter.Scanner;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.OsuToParameter
{
    /// <summary>
    ///     這邊是把Osu物件轉換成處理用參數
    /// </summary>
    internal class OsuToParameterConvertor
    {
        private readonly PrefixScanner prefixScanner = new PrefixScanner();

        public List<HitObjectConvertParameter> Convert(List<OsuHitObject> input)
        {
            var output = new List<HitObjectConvertParameter>();
            //先把參數都丟進去
            foreach (var single in input)
            {
                var singleParameter = new HitObjectConvertParameter();
                singleParameter.OsuHitObject = single;
                output.Add(singleParameter);
            }
            //然後預先把要用的參數做掃描
            output = prefixScanner.Convert(output);

            return output;
        }
    }
}
