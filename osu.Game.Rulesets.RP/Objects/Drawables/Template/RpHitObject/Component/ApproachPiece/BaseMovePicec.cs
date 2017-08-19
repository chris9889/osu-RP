// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece
{
    /// <summary>
    ///     結束的物件後面帶的特效
    /// </summary>
    public class BaseMovePicec : BaseComponent, IComponentUpdateEachFrame
    {
        /// <summary>
        ///     打擊物件
        /// </summary>
        protected BaseRpHitableObject BaseHitObject;

        public BaseMovePicec(BaseRpHitableObject baseHitObject)
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
