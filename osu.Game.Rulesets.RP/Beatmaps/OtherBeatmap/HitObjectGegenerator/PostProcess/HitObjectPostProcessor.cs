// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects.Types;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PostProcess
{
    internal class HitObjectPostProcessor
    {
        internal void PostProcess(ConvertParameter single)
        {
            //set all the objects is converted
            ProcessConvert(single);
            //Set the object is multiObject or not
            ProcessMulti(single);
        }

        /// <summary>
        ///     the object is convert from other beatmap or RP beatmap
        /// </summary>
        /// <param name="single"></param>
        private void ProcessConvert(ConvertParameter single)
        {
            //同一群絁E�E�E皁E�E��E�件位置
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            foreach (var singleObject in singleTupleHitObjects.ListBaseHitObject)
                singleObject.Convert = RpBaseObjectType.Convert.Convert;
        }

        /// <summary>
        ///     Set the object is multiObject or not
        /// </summary>
        /// <param name="single"></param>
        private void ProcessMulti(ConvertParameter single)
        {
            //同一群絁E�E�E皁E�E��E�件位置
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            foreach (var singleObject in singleTupleHitObjects.ListBaseHitObject)
                if (singleTupleHitObjects.ListBaseHitObject.Count > 1)
                    singleObject.Multi = RpBaseHitObjectType.Multi.Multi;
                else
                    singleObject.Multi = RpBaseHitObjectType.Multi.SingleClick;
        }
    }
}
