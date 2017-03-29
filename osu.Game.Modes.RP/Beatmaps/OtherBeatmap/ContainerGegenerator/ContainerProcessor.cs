using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.MultiContainer;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator
{
    public class ContainerProcessor
    {
        //物件數量決定
        private readonly MultiContainerDecidor MultiContainerDecidor = new MultiContainerDecidor();

        //實作並且分配
        private readonly ContainerGenerator ContainerGenerator = new ContainerGenerator();

        //決定物件位置
        private readonly PositionDecidor PositionDecidor = new PositionDecidor();

        public List<ComvertParameter> Convert(List<ComvertParameter> output)
        {
            foreach (var single in output)
            {
                //decide the number of container and layout
                single.ContainerConvertParameter = MultiContainerDecidor.GetParameter(single);

                //generator physical object //MultiAlocate
                single.ContainerConvertParameter.ListObjectContainer = ContainerGenerator.GetListContainer(single);
                //position(PositionDecidor)
                PositionDecidor.AllocatePosition(single);
            }
            return output;
        }
    }
}
