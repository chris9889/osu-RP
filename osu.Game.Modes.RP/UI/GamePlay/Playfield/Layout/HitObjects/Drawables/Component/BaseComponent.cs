using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component
{
    /// <summary>
    ///     元素區塊
    /// </summary>
    internal class BaseComponent : Framework.Graphics.Containers.Container
    {
        /// <summary>
        /// </summary>
        public float Delay;

        /// <summary>
        ///     打擊物件，DrawableHitCircle 會根據打擊物件把 物件繪製出來
        /// </summary>
        protected BaseRpObject HitObject;

        /// <summary>
        ///     初始化顯示
        /// </summary>
        public virtual void Initial()
        {
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public virtual void FadeIn(double time = 0)
        {
        }

        /// <summary>
        ///     結束
        /// </summary>
        public virtual void FadeOut(double time = 0)
        {
        }
    }
}
