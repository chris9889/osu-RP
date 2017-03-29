using System.Collections.Generic;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using osu.Game.Modes.RP.SkinManager;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.Container
{
    /// <summary>
    /// </summary>
    internal class ContainerDecisionLineComponent : BaseContainerComponent, IChangeableContainerComponent
    {
        /// <summary>
        ///     判定線
        /// </summary>
        private ImagePicec _containerDecisionLineComponent;

        /// <summary>
        /// </summary>
        public ContainerDecisionLineComponent(ObjectContainer hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        ///     更新時間
        /// </summary>
        /// <param name="time"></param>
        public void UpdateTime(double time)
        {
            //計算指針位置 
            _containerDecisionLineComponent.Position = CalculatePosition(time - HitObject.StartTime);
        }

        /// <summary>
        ///     修改物件高度
        /// </summary>
        /// <param name="newHeight"></param>
        public void ChangeHeight(float newHeight)
        {
        }


        protected override void InitialObject(int layerCount = 1)
        {
            //指標
            _containerDecisionLineComponent = new ImagePicec(RpTexturePathManager.GetDecisionLineTexture())
            {
                Position = new Vector2(0, 0),
                Scale = new Vector2(1f, 1f * layerCount)
            };
        }


        protected override void InitialChild()
        {
            var listDrawable = new List<Framework.Graphics.Containers.Container>();
            listDrawable.Add(_containerDecisionLineComponent);
            Children = listDrawable;
        }
    }
}
