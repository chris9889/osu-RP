using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Coop;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.MultiContainer;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator
{
    public class ContainerProcessor
    {
        //物件數量決定
        private readonly MultiContainerDecidor multiContainerDecidor = new MultiContainerDecidor();

        //實作並且分配
        private readonly ContainerGenerator containerGenerator = new ContainerGenerator();

        //決定物件位置
        private readonly PositionDecidor positionDecidor = new PositionDecidor();

        private readonly CoopDecider coopDecider = new CoopDecider();

        public List<ConvertParameter> Convert(List<ConvertParameter> output)
        {
            foreach (var single in output)
            {
                //decide the number of container and layout
                single.ContainerConvertParameter = multiContainerDecidor.GetParameter(single);
                //generator physical object //MultiAlocate
                single.ContainerConvertParameter.ListObjectContainer = containerGenerator.GetListContainer(single);
                //Decide Left or right
                coopDecider.DecideCoop(single);
                //position(PositionDecidor)
                positionDecidor.AllocatePosition(single);
            }
            return output;
        }
    }
}
