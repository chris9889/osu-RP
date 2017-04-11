// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.PostConvert
{
    public class PostConvertor
    {
        /// <summary>
        ///     Convert ComvertParameter to BaseRpObject
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public List<BaseRpObject> Convert(List<ConvertParameter> output)
        {
            var list = new List<BaseRpObject>();

            foreach (var single in output)
            foreach (var singleContainer in single.ContainerConvertParameter.ListObjectContainer)
                list.Add(singleContainer);


            foreach (var single in output)
            foreach (var objectTuple in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            foreach (var hitObject in objectTuple.ListBaseHitObject)
                list.Add(hitObject);

            return list;
        }
    }
}
