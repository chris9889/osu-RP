using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Position;
using OpenTK;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Container
{
    internal class BaseContainerComponent : BaseComponent
    {
        /// <summary>
        /// </summary>
        public new RpContainer HitObject;

        /// <summary>
        ///     負責計算物件在時間點該有的位置
        /// </summary>
        protected readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        public BaseContainerComponent(RpContainer hitObject)
        {
            HitObject = hitObject;
            InitialObject();
            InitialChild();
        }

        /// <summary>
        ///     更新新的 Layout數量
        /// </summary>
        /// <param name="newLayerNumber"></param>
        public virtual void UpdateLayerNumber()
        {
            //資料從 ObjectContainer 裡面讀取
        }

        /// <summary>
        ///     如果更新了開始或是結束的時間
        /// </summary>
        public virtual void UpdateTime()
        {
        }


        /// <summary>
        ///     初始化所有顯示物件
        /// </summary>
        protected virtual void InitialObject(int layerCount = 1)
        {
        }

        /// <summary>
        ///     初始化所有顯示物件
        /// </summary>
        protected virtual void InitialChild()
        {
        }

        /// <summary>
        ///     根據時間點計算物件位置
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        protected Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time, HitObject.Velocity), 0);
        }

        /// <summary>
        ///     取得間隔時間
        /// </summary>
        /// <returns></returns>
        protected double GetDeltaBeatTime()
        {
            return 1000 * 60 / HitObject.BPM;
        }
    }
}
