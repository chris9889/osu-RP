using System.Collections.Generic;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator
{
    public class ContainerGenerator
    {
        //parameter

        /// <summary>
        ///     Generators the object by parameter.
        /// </summary>
        internal List<RpContainer> GetListContainer(ConvertParameter single)
        {
            var returnContainer = new List<RpContainer>();
            var listLayout = new List<RpContainerLayout>();

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


        private RpContainer GenerateSingleContainer(ConvertParameter single)
        {
            var objectContainer = new RpContainer(single.SliceConvertParameter.StartTime);
            objectContainer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainer.ContainerEndTime = single.SliceConvertParameter.EndTime;
            objectContainer.BPM = single.SliceConvertParameter.BPM;
            objectContainer.Velocity = single.SliceConvertParameter.Volocity;
            return objectContainer;
        }

        private RpContainerLayout GenerateSingleLayout(ConvertParameter single, RpContainer container)
        {
            var objectContainerLayer = new RpContainerLayout(container);
            objectContainerLayer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainerLayer.EndTime = single.SliceConvertParameter.EndTime;
            return objectContainerLayer;
        }
    }
}
