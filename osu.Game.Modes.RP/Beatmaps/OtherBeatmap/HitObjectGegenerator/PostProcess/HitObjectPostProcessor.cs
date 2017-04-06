using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PostProcess
{
    class HitObjectPostProcessor
    {
        internal void PostProcess(ComvertParameter single)
        {
            //follow the coop on the layout HotObject locate in
            ProcessCoop(single);
            //set all the objects is converted
            ProcessConvert(single);
            //Set the object is multiObject or not
            ProcessMulti(single);
        }

        /// <summary>
        /// Process coop
        /// </summary>
        /// <param name="single"></param>
        void ProcessCoop(ComvertParameter single)
        {
            //同一群組內的物件位置
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            {
                foreach (BaseHitObject singleObject in singleTupleHitObjects.ListBaseHitObject)
                {
                    int containerIndex =singleObject.ContainerIndex;
                    int layoutIndex = singleObject.LayoutIndex;
                    singleObject.Coop = single.ContainerConvertParameter.ListObjectContainer[containerIndex].ContainerLayerList[layoutIndex].Coop;
                }
            }
        }

        /// <summary>
        /// the object is convert from other beatmap or RP beatmap
        /// </summary>
        /// <param name="single"></param>
        void ProcessConvert(ComvertParameter single)
        {
            //同一群組內的物件位置
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            {
                foreach (BaseHitObject singleObject in singleTupleHitObjects.ListBaseHitObject)
                {
                    singleObject.Comvert= RpBaseObjectType.Comvert.Comvert;
                }
            }
        }

        /// <summary>
        /// Set the object is multiObject or not
        /// </summary>
        /// <param name="single"></param>
        void ProcessMulti(ComvertParameter single)
        {
            //同一群組內的物件位置
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            {
                foreach (BaseHitObject singleObject in singleTupleHitObjects.ListBaseHitObject)
                {
                    if (singleTupleHitObjects.ListBaseHitObject.Count > 1)
                    {
                        singleObject.Multi= RpBaseHitObjectType.Multi.Multi;
                    }
                    else
                    {
                        singleObject.Multi = RpBaseHitObjectType.Multi.SingleClick;
                    }
                }
            }
        }
    }
}
