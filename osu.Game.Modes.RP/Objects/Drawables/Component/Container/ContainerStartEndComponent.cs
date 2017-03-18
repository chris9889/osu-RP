using System.Collections.Generic;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.Container
{
    /// <summary>
    /// 
    /// </summary>
    class ContainerStartEndComponent : BaseContainerComponent
    {
        /// <summary>
        /// 開始點
        /// </summary>
        private RectanglePiece _containerStartDecisionLineComponent;

        /// <summary>
        /// 結束
        /// </summary>
        private RectanglePiece _containerEndDecisionLineComponent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hitObject"></param>
        public ContainerStartEndComponent(ObjectContainer hitObject) : base(hitObject)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layerCount"></param>
        protected override void InitialObject(int layerCount=1)
        {
            //開始點
            _containerStartDecisionLineComponent = new RectanglePiece(100,100)
            {
                Scale = new OpenTK.Vector2(0.002f, 0.2f * layerCount),
                Position = CalculatePosition(0),
            };
            //結束物件
            _containerEndDecisionLineComponent = new RectanglePiece(100,100)
            {
                Scale = new OpenTK.Vector2(0.002f, 0.2f * layerCount),
                Position = CalculatePosition(HitObject.EndTime - HitObject.StartTime),
            };
        }

        protected override void InitialChild()
        {
            List<Framework.Graphics.Containers.Container> listContainer = new List<Framework.Graphics.Containers.Container>();
            listContainer.Add(_containerStartDecisionLineComponent);
            listContainer.Add(_containerEndDecisionLineComponent);
            Children = listContainer;
        }
    }
}
