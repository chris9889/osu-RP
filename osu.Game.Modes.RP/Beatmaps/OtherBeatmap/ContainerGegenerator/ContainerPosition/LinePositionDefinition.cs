using System;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition
{
    /// <summary>
    /// it can define the proper position for comvertor
    /// </summary>
    public class LinePositionDefinition
    {
        DodgeSameLine DodgeSameLine = new DodgeSameLine();

        private int _containerNumber;

        public void SetContainerNumber(int number)
        {
            _containerNumber = number;
        }

        public LinePositionDefinition()
        {

        }

        //先用隨機代替
        Random random = new Random();

        internal Vector2 GetPosition(int index)
        {
            
            float randomValue = (float)random.NextDouble() * 400 + 40;
            return new Vector2(0, randomValue);
        }
    }
}
