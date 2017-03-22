using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.MultiContainer;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator
{
	public class ContainerProcessor
    {
        //物件數量決定
        MultiContainerDecidor MultiContainerDecidor=new MultiContainerDecidor();

        //實作並且分配
        ContainerGenerator ContainerGenerator=new ContainerGenerator();

        //決定物件位置
        PositionDecidor PositionDecidor =new PositionDecidor();

        public List<ComvertParameter> Convert(List<ComvertParameter> output)
        {
            foreach (ComvertParameter single in output)
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
