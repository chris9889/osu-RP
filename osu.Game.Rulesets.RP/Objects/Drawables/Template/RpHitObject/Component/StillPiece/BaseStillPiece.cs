// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.StillPiece
{
    /// <summary>
    ///     靜止在Layout上面的物件
    /// </summary>
    public class BaseStillPiece : BaseComponent
    {
        /// <summary>
        ///     建構
        /// </summary>
        public BaseStillPiece(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
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
