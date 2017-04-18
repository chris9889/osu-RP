using System.Collections.Generic;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpContainer
{
    /// <summary>
    /// </summary>
    internal class ContainerDecisionLineComponent : BaseContainerComponent, IChangeableContainerComponent,IComponentHasStartTime,IComponentHasEndTime
    {
        /// <summary>
        ///     判定線
        /// </summary>
        private ImagePicec _containerDecisionLineComponent;

        /// <summary>
        /// </summary>
        public ContainerDecisionLineComponent(Objects.RpContainer hitObject)
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

        
        public void SetStartTime(double startTime)
        {
            throw new System.NotImplementedException();
        }

        public void SetEndTime(double time)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        void UpdateMovingTransform()
        {

        }
    }
}
