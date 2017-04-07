//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Graphics;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Objects.Drawables.Template.HitObject.Click;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables
{
    /// <summary>
    ///     繪製 RP HitCircle
    /// </summary>
    internal class DrawableRpHitObject : DrawableBaseHitObject, IDrawableHitObjectWithProxiedApproach
    {
        public Drawable ProxiedLayer
        {
            get { throw new NotImplementedException(); }
        }

        public DrawableRpHitObject(RpHitObject h)
            : base(h)
        {
            Template = new ClickTemplate(HitObject)
            {
                Position = new Vector2(0, 0),
                Alpha = 1
            };

            Children = new Drawable[]
            {
                Template,
                _rpDetectPress
            };

            //may not be so correct
            //Size = _rpDetectPress.DrawSize;
            Scale = new Vector2(HitObject.Scale);
        }

        // Since the DrawableSlider itself is just a container without a size we need to
        // pass all input through.
        //public override bool Contains(Vector2 screenSpacePos) => true;

        /// <summary>
        ///     更新初始狀態
        /// </summary>
        protected override void UpdateInitialState()
        {
            base.UpdateInitialState();

            //sane defaults
            //ring.Alpha = _detectPress.Alpha = number.Alpha = glow.Alpha = 1;
            //初始化指標
            Template.Initial();
            //explode.Alpha = 0;
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
                    Delay(HitObject.Duration + TIME_PREEMPT);
                    FadeOut(TIME_FADEOUT);
                    break;
                case ArmedState.Miss:
                    FadeOut(TIME_FADEOUT / 5);
                    break;
                case ArmedState.Hit:
                    const double flash_in = 40;

                    //flash.FadeTo(0.8f, flash_in);
                    //flash.Delay(flash_in);
                    //flash.FadeOut(100);

                    //explode.FadeIn(flash_in);

                    Delay(flash_in, true);

                    //after the flash, we can hide some elements that were behind it
                    //ring.FadeOut();
                    //_detectPress.FadeOut();
                    //number.FadeOut();
                    FadeOut(TIME_FADEOUT);
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
