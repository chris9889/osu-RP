// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.Component
{
    /// <summary>
    ///     元素區塊
    /// </summary>
    public class BaseComponent : Container
    {
        /// <summary>
        /// </summary>
        public new float Delay;

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
