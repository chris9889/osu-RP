using System;
using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator
{
    public class ContainerGenerator
    {
        //parameter

        public ContainerGenerator()
        {
            
        }

        /// <summary>
        /// Generators the object by parameter.
        /// </summary>
        internal List<ObjectContainer> GetListContainer(ComvertParameter single)
        {
            List < ObjectContainer > returnContainer=new List<ObjectContainer>();
            List<ObjectContainerLayer> listLayout = new List<ObjectContainerLayer>();

            //container number
            for (int i = 0; i < single.ContainerConvertParameter.ContainerNumber; i++)
            {
                returnContainer.Add(GenerateSingleContainer(single));

                //decide this container shouble allocate number of layout
                listLayout.Add(GenerateSingleLayout(single, returnContainer[i]));

                //    container layout number;
                //TODO : adjust it later
                returnContainer[i].ContainerLayerList[0]=(listLayout[i]);
            }

            return returnContainer;
        }


        ObjectContainer GenerateSingleContainer(ComvertParameter single)
        {
            ObjectContainer objectContainer = new ObjectContainer(single.SliceConvertParameter.StartTime);
            objectContainer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainer.ContainerEndTime = single.SliceConvertParameter.EndTime;
            return objectContainer;
        }

        ObjectContainerLayer GenerateSingleLayout(ComvertParameter single, ObjectContainer container)
        {
            ObjectContainerLayer objectContainerLayer = new ObjectContainerLayer(container);
            objectContainerLayer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainerLayer.EndTime = single.SliceConvertParameter.EndTime;
            return objectContainerLayer;

        }

       
    }
}
