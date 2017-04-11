using System;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.CommonInterface;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.MovePiece
{
    /// <summary>
    ///     結束的物件後面帶的特效
    /// </summary>
    internal class BaseMovePicec : BaseComponent, IComponentSliderProgress
    {
        /// <summary>
        ///     打擊物件
        /// </summary>
        protected BaseRpHitObject BaseHitObject;

        public BaseMovePicec(BaseRpHitObject baseHitObject)
        {
            BaseHitObject = baseHitObject;
        }

        /// <summary>
        ///     初始化顯示
        /// </summary>
        public override void Initial()
        {
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public override void FadeIn(double time = 0)
        {
        }

        /// <summary>
        ///     結束
        /// </summary>
        public override void FadeOut(double time = 0)
        {
        }

        public void UpdateProgress(double startProgress = 0, double endProgress = 1)
        {
            throw new NotImplementedException();
        }
    }
}
