


using System;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition
{
    public class PositionDecidor
    {
        //物件位置定義，會定義可以的座標等等
        LinePositionDefinition LinePositionDefinition=new LinePositionDefinition();

        public void AllocatePosition(ComvertParameter single)
        {
            LinePositionDefinition.SetContainerNumber(single.ContainerConvertParameter.ListObjectContainer.Count);
            for (int i = 0; i < single.ContainerConvertParameter.ListObjectContainer.Count; i++)
            {
                single.ContainerConvertParameter.ListObjectContainer[i].Position = LinePositionDefinition.GetPosition(i);
            }
        }
    }
}
