// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.Component
{
    /// <summary>
    ///     元素區塊
    /// </summary>
    public interface IComponentBase :IContainer
    {

        /// <summary>
        ///     打擊物件，DrawableHitCircle 會根據打擊物件把 物件繪製出來
        /// </summary>
        BaseRpObject HitObject { get; set; }

        /// <summary>
        ///     初始化顯示
        /// </summary>
        void Initial();

        /// <summary>
        ///     開始特效
        /// </summary>
        void FadeIn(double time = 0);

        /// <summary>
        ///     結束
        /// </summary>
        void FadeOut(double time = 0);
    }
}
