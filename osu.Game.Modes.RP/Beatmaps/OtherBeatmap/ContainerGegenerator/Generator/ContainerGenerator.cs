using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator
{
    public class ContainerGenerator
    {
        //parameter

        /// <summary>
        ///     Generators the object by parameter.
        /// </summary>
        internal List<ObjectContainer> GetListContainer(ComvertParameter single)
        {
            var returnContainer = new List<ObjectContainer>();
            var listLayout = new List<ObjectContainerLayer>();

            //container number
            for (var i = 0; i < single.ContainerConvertParameter.ContainerNumber; i++)
            {
                returnContainer.Add(GenerateSingleContainer(single));

                //decide this container shouble allocate number of layout
                listLayout.Add(GenerateSingleLayout(single, returnContainer[i]));

                //    container layout number;
                //TODO : adjust it later
                returnContainer[i].ContainerLayerList[0] = listLayout[i];
            }

            return returnContainer;
        }


        private ObjectContainer GenerateSingleContainer(ComvertParameter single)
        {
            var objectContainer = new ObjectContainer(single.SliceConvertParameter.StartTime);
            objectContainer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainer.ContainerEndTime = single.SliceConvertParameter.EndTime;
            objectContainer.BPM = single.SliceConvertParameter.BPM;
            objectContainer.Velocity = single.SliceConvertParameter.Volocity;
            return objectContainer;
        }

        private ObjectContainerLayer GenerateSingleLayout(ComvertParameter single, ObjectContainer container)
        {
            var objectContainerLayer = new ObjectContainerLayer(container);
            objectContainerLayer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainerLayer.EndTime = single.SliceConvertParameter.EndTime;
            return objectContainerLayer;
        }
    }
}
