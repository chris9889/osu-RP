using OpenTK;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition
{
    /// <summary>
    ///     it can define the proper position for comvertor
    /// </summary>
    public class LinePositionDefinition
    {
        //目前總共有幾幾行
        public int MaxContainerNumber;

        public LinePositionDefinition()
        {
            ReCalMaxContainerNumber();
        }

        /// <summary>
        ///     重新計算最大可以容納幾行
        /// </summary>
        public void ReCalMaxContainerNumber()
        {
            MaxContainerNumber = 7;
        }

        //先用隨機代替


        internal Vector2 GetPosition(int nowLineIndex)
        {
            return new Vector2(0, nowLineIndex * 400 / MaxContainerNumber + 50);
        }
    }
}
