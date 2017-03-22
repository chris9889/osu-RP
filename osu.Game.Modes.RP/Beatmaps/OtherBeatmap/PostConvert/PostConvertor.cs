// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.PostConvert
{
    public class PostConvertor
    {
        /// <summary>
        /// Convert ComvertParameter to BaseRpObject
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public List<BaseRpObject> Convert(List<ComvertParameter> output)
        {
            List < BaseRpObject > list=new List<BaseRpObject>();

            foreach (ComvertParameter single in output)
            {
                //增加Container
                foreach (ObjectContainer singleContainer in single.ContainerConvertParameter.ListObjectContainer)
                {
                    list.Add(singleContainer);
                }
            }


            foreach (ComvertParameter single in output)
            {
                //增加打擊物件
                foreach (SingleHitObjectConvertParameter objectTuple in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
                {
                    foreach (BaseHitObject hitObject in objectTuple.ListBaseHitObject)
                    {
                        list.Add(hitObject);
                    }
                }
            }
           
            return list;
        }
    }
}