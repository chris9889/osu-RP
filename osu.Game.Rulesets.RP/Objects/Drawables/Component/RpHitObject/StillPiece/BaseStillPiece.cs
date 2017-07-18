﻿using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.StillPiece
{
    /// <summary>
    ///     靜止在Layout上面的物件
    /// </summary>
    internal class BaseStillPiece : BaseComponent
    {
        /// <summary>
        ///     建構
        /// </summary>
        public BaseStillPiece(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;


            Children = new Drawable[]
            {
            };
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
    }
}
