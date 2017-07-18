//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpHitObject.RpHoldObject;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    /// <summary>
    ///     Slider
    /// </summary>
    public class DrawableRpHoldObject : DrawableBaseRpHitableObject
    {
        public DrawableRpHoldObject(RpHoldObject h) : base(h)
        {
           
        }

        public override void InitialTemplate()
        {
            Template = new RpHoldObjectTemplate(this)
            {
                Position = new Vector2(0, 0),
                Alpha = 1
            };
        }

        public override void InitialChild()
        {
            Children = new Drawable[]
            {
                Template,
                _rpDetectPress
            };
        }

        // Since the DrawableSlider itself is just a container without a size we need to
        // pass all input through.
        //public override bool Contains(Vector2 screenSpacePos) => true;

        /// <summary>
        /// </summary>
        /// <param name="userTriggered"></param>
        protected override void CheckJudgement(bool userTriggered)
        {
            if (!userTriggered)
            {
                if (Judgement.TimeOffset > (this.HitObject.hit50))
                    Judgement.Result = HitResult.Miss;
                return;
            }

            var hitOffset = Math.Abs(Judgement.TimeOffset);

            var rpJudgement = Judgement;
            rpJudgement.HitExplosionPosition.Add(Position);

            if (hitOffset < (this.HitObject.hit50))
            {
                Judgement.Result = HitResult.Hit;


                if (hitOffset < (this.HitObject.hit300))
                    rpJudgement.Score = RpScoreResult.Cool;
                else if (hitOffset < (this.HitObject.hit100))
                    rpJudgement.Score = RpScoreResult.Fine;
                else if (hitOffset < (this.HitObject.hit50))
                    rpJudgement.Score = RpScoreResult.Safe;
            }
            else
            {
                Judgement.Result = HitResult.Miss;
            }
        }

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
        ///     這裡估計會一直更新
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
                    Delay(((DrawableBaseRpObject)this).HitObject.Duration + PreemptTime);
                    FadeOut(FadeOutTime);
                    break;
                case ArmedState.Miss:
                    FadeOut(FadeOutTime / 5);
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

                    FadeOut(800);
                    ScaleTo(Scale * 1.5f, 400, EasingTypes.OutQuad);
                    //播放打擊的聲音
                    PlaySamples();
                    break;
            }

            //
            //_template.FadeOut();
        }
    }
}
