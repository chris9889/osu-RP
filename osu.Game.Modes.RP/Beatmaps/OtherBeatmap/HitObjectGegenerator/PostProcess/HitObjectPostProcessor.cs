using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PostProcess
{
    internal class HitObjectPostProcessor
    {
        internal void PostProcess(ConvertParameter single)
        {
            //follow the coop on the layout HotObject locate in
            ProcessCoop(single);
            //set all the objects is converted
            ProcessConvert(single);
            //Set the object is multiObject or not
            ProcessMulti(single);
        }

        /// <summary>
        ///     Process coop
        /// </summary>
        /// <param name="single"></param>
        private void ProcessCoop(ConvertParameter single)
        {
            //蜷御ｸ鄒､邨・・逧・黄莉ｶ菴咲ｽｮ
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            foreach (var singleObject in singleTupleHitObjects.ListBaseHitObject)
            {
                var containerIndex = singleObject.ContainerIndex;
                var layoutIndex = singleObject.LayoutIndex;
                singleObject.Coop = single.ContainerConvertParameter.ListObjectContainer[containerIndex].ContainerLayerList[layoutIndex].Coop;
            }
        }

        /// <summary>
        ///     the object is convert from other beatmap or RP beatmap
        /// </summary>
        /// <param name="single"></param>
        private void ProcessConvert(ConvertParameter single)
        {
            //蜷御ｸ鄒､邨・・逧・黄莉ｶ菴咲ｽｮ
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
            //蜷御ｸ鄒､邨・・逧・黄莉ｶ菴咲ｽｮ
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            foreach (var singleObject in singleTupleHitObjects.ListBaseHitObject)
                if (singleTupleHitObjects.ListBaseHitObject.Count > 1)
                    singleObject.Multi = RpBaseHitObjectType.Multi.Multi;
                else
                    singleObject.Multi = RpBaseHitObjectType.Multi.SingleClick;
        }
    }
}
