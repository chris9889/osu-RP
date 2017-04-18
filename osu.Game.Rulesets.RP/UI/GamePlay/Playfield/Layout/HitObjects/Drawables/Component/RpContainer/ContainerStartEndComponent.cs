using System.Collections.Generic;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpContainer
{
    /// <summary>
    /// </summary>
    internal class ContainerStartEndComponent : BaseContainerComponent, IChangeableContainerComponent,IComponentHasStartTime,IComponentHasEndTime
    {
        /// <summary>
        ///     Start Point
        /// </summary>
        private RectanglePiece _containerStartDecisionLineComponent;

        /// <summary>
        ///    EndPoint
        /// </summary>
        private RectanglePiece _containerEndDecisionLineComponent;

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public ContainerStartEndComponent(Objects.RpContainer hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        ///     èCâ¸ï®åèçÇìx
        /// </summary>
        /// <param name="newHeight"></param>
        public void ChangeHeight(float newHeight)
        {
            _containerStartDecisionLineComponent.Height = newHeight;
            _containerEndDecisionLineComponent.Height = newHeight;
        }

        /// <summary>
        /// </summary>
        /// <param name="layerCount"></param>
        protected override void InitialObject(int layerCount = 1)
        {
            //äJénÍy
            _containerStartDecisionLineComponent = new RectanglePiece(100, 100)
            {
                Scale = new Vector2(0.002f, 0.2f * layerCount),
                Position = CalculatePosition(0)
            };
            //åãë©ï®åè
            _containerEndDecisionLineComponent = new RectanglePiece(100, 100)
            {
                Scale = new Vector2(0.002f, 0.2f * layerCount),
                Position = CalculatePosition(HitObject.EndTime - HitObject.StartTime)
            };
        }

        protected override void InitialChild()
        {
            var listContainer = new List<Framework.Graphics.Containers.Container>();
            listContainer.Add(_containerStartDecisionLineComponent);
            listContainer.Add(_containerEndDecisionLineComponent);
            Children = listContainer;
        }

        /// <summary>
        /// update start Time
        /// </summary>
        /// <param name="startTime"></param>
        public void SetStartTime(double startTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Update End Time
        /// </summary>
        /// <param name="time"></param>
        public void SetEndTime(double time)
        {
            throw new System.NotImplementedException();
        }
    }
}
