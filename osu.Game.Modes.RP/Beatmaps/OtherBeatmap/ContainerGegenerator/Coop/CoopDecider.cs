using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Coop
{
    class CoopDecider
    {
        private int _coopNumber = 10;

        /// <summary>
        /// DecideCoop
        /// </summary>
        /// <param name="single"></param>
        internal void DecideCoop(ComvertParameter single)
        {
            int layoutNumber = 0;
            //Get the number of layoutNumber;
            foreach (ObjectContainer sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
            {
                layoutNumber = layoutNumber + sligleContainer.ContainerLayerList.Count;
            }

            //Get how many number of the HitObject
            int refCount = single.ListRefrenceObject.Count;

            //decide use coop or not
            if (refCount < _coopNumber)
            {
                GenerateCoop(single);
            }
            else
            {
                GenerateNonCoop(single);
            }

        }

        /// <summary>
        /// all the layout will have non-coop
        /// </summary>
        void GenerateNonCoop(ComvertParameter single)
        {
            foreach (ObjectContainer sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
            {
                foreach (ObjectContainerLayer layout in sligleContainer.ContainerLayerList)
                {
                    layout.Coop= RpBaseHitObjectType.Coop.Both;
                }
            }
        }

        /// <summary>
        /// Depend on how many layout and decide the coop
        /// </summary>
        void GenerateCoop(ComvertParameter single)
        {
            List< ObjectContainerLayer > listLayout=new List<ObjectContainerLayer>();
            foreach (ObjectContainer sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
            {
                listLayout.AddRange(sligleContainer.ContainerLayerList);
            }

            int additionRandomValue = GetRandomValue(single);
            for (int i = 0; i < listLayout.Count; i++)
            {
                if ((i+additionRandomValue) % 2 == 0)
                {
                    //assign Left
                    listLayout[i].Coop= RpBaseHitObjectType.Coop.LeftOnly;
                }
                else
                {
                    //assign Right
                    listLayout[i].Coop = RpBaseHitObjectType.Coop.RightOnly; 
                }
            }
        }

        /// <summary>
        /// generate readom value by something
        /// </summary>
        /// <returns></returns>
        int GetRandomValue(ComvertParameter single)
        {
            return single.ListRefrenceObject.Count+single.ContainerConvertParameter.ListObjectContainer.Count+1;
        }
    }
}
