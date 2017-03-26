using System.Collections.Generic;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.Container
{
    /// <summary>
    /// 
    /// </summary>
    class ContainerDecisionLineComponent : BaseContainerComponent, IChangeableContainerComponent
    {

        /// <summary>
        /// 判定線
        /// </summary>
        private Pieces.ImagePicec _containerDecisionLineComponent;

        /// <summary>
        /// 
        /// </summary>
        public ContainerDecisionLineComponent(ObjectContainer hitObject) : base(hitObject)
        {
            
        }


        protected override void InitialObject(int layerCount=1)
        {
            //指標
            _containerDecisionLineComponent = new Pieces.ImagePicec(SkinManager.RpTexturePathManager.GetDecisionLineTexture())
            {
                Position = new OpenTK.Vector2(0, 0),
                Scale = new Vector2(1f, 1f * layerCount),
            };
        }


        protected override void InitialChild()
        {
            List<Framework.Graphics.Containers.Container> listDrawable = new List<Framework.Graphics.Containers.Container>();
            listDrawable.Add(_containerDecisionLineComponent);
            Children = listDrawable;
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        /// <param name="time"></param>
        public void UpdateTime(double time)
        {
            //計算指針位置 
            _containerDecisionLineComponent.Position = CalculatePosition(time-HitObject.StartTime);
        }

        /// <summary>
        /// 修改物件高度
        /// </summary>
        /// <param name="newHeight"></param>
        public new void ChangeHeight(float newHeight)
        {

        }
    }
}
