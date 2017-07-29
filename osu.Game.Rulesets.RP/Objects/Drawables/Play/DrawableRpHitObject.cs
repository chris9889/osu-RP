// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    ///     繪製 RP HitCircle
    /// </summary>
    public class DrawableRpHitObject : DrawableBaseRpHitableObject
    {
        /// <summary>
        /// </summary>
        public new RpHitObject HitObject
        {
            get { return (RpHitObject)base.HitObject; }
        }

        /// <summary>
        ///     template
        /// </summary>
        public new RpHitObjectTemplate Template
        {
            get { return (RpHitObjectTemplate)base.Template; }
            set { base.Template = value; }
        }

        public DrawableRpHitObject(RpHitObject h)
            : base(h)
        {
        }

        protected override void ConstructObject()
        {
            Template = new RpHitObjectTemplate(HitObject)
            {
                Position = new Vector2(0, 0),
                Alpha = 1
            };
            
        }

        /// <summary>
        ///     更新初始狀態
        /// </summary>
        protected override void UpdateInitialState()
        {
            base.UpdateInitialState();
        }

        /// <summary>
        ///     初始時會跑一次
        /// </summary>
        protected override void UpdatePreemptState()
        {
            base.UpdatePreemptState();
        }

        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();
        }

        /// <summary>
        ///     結果，有打到或是miss
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateState(ArmedState state)
        {
            if (!IsLoaded) return;

            base.UpdateState(state);

            //glow.FadeOut(400);

            switch (state)
            {
                case ArmedState.Idle:
                    // Delay(((DrawableBaseRpObject)this).HitObject.Duration + PreemptTime);
                    this.Delay(PreemptTime);
                    this.FadeOut(FadeOutTime);
                    break;
                case ArmedState.Miss:
                    this.FadeOut(FadeOutTime / 5);
                    break;
                case ArmedState.Hit:
                    const double flash_in = 40;

                    //flash.FadeTo(0.8f, flash_in);
                    //flash.Delay(flash_in);
                    //flash.FadeOut(100);

                    //explode.FadeIn(flash_in);

                    this.Delay(flash_in);

                    //after the flash, we can hide some elements that were behind it
                    //ring.FadeOut();
                    //_detectPress.FadeOut();
                    //number.FadeOut();
                    this.FadeOut(FadeOutTime);
                    //FadeOut(200);
                    //ScaleTo(Scale * 1.5f, 400, EasingTypes.OutQuad);
                    //播放打擊的聲音
                    PlaySamples();
                    Expire();
                    break;
            }

            //
            //_template.FadeOut();
        }
    }
}
