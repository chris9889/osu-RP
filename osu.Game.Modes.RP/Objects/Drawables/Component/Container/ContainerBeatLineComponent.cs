using System.Collections.Generic;
using osu.Game.Modes.RP.Objects.Drawables.Calculator;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.Container
{
    /// <summary>
    /// 裝判定點用
    /// </summary>
    class ContainerBeatLineComponent : BaseContainerComponent, IChangeableContainerComponent
    {
        /// <summary>
        /// 中間的節拍
        /// </summary>
        private List<Pieces.ImagePicec> _containerBeatDecisionLineComponent = new List<Pieces.ImagePicec>();

        /// <summary>
        /// 計算物件的相關高度和Height位置
        /// </summary>
        ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        public ContainerBeatLineComponent(ObjectContainer hitObject) : base(hitObject)
        {

        }

        /// <summary>
        /// 初始化顯示
        /// </summary>
        protected override void InitialObject(int layerCount = 0)
        {
            InitialBeat();
        }


        protected override void InitialChild()
        {
            Children = _containerBeatDecisionLineComponent;
        }

        /// <summary>
        /// 初始化節拍點
        /// </summary>
        void InitialBeat()
        {
            for (int i = 0; i < 4; i++)
            {
                //物件
                Pieces.ImagePicec line = new Pieces.ImagePicec(SkinManager.RPSkinManager.GetBeatLineTexture());
                //
                line.Scale = new Vector2(0.6f);
                //設定位置
                line.Position = CalculatePosition(HitObject.StartTime + i * GetDeltaBeatTime());
                //加入
                _containerBeatDecisionLineComponent.Add(line);
            }
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
