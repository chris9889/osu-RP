// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    ///     繪製 RP HitCircle
    /// </summary>
    public class DrawableRpHitObject : DrawableBaseRpHitableObject, IKeyBindingHandler<RpAction>
    {
        /// <summary>
        /// </summary>
        public new RpHitObject HitObject
        {
            get { return (RpHitObject)base.HitObject; }
        }

        //RpHitObjectTemplate IHasTemplate<RpHitObjectTemplate>.Template => (RpHitObjectTemplate)base.Template;

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

        public bool OnPressed(RpAction action)
        {
            bool press = HitObject.CanHitBy(action);
            if (press)
            {
                OnKeyPressDown();
            }
            return press;
        }

        public bool OnReleased(RpAction action)
        {
            bool release = HitObject.CanHitBy(action);
            if (release)
            {
                OnKeyPressUp();
            }
            return release;
        }

        /// <summary>
        ///     結果，有打到或是miss
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateCurrentState(ArmedState state)
        {
            double duration = ((HitObject as IHasEndTime)?.EndTime ?? HitObject.StartTime) - HitObject.StartTime;

            using (Template.BeginDelayedSequence(duration))
                Template.FadeOut(400);

            //glow.FadeOut(400);

            switch (state)
            {
                case ArmedState.Idle:
                    using (BeginDelayedSequence(duration + PreemptTime))
                        this.FadeOut(PreemptTime);
                    Expire(true);
                    break;
                case ArmedState.Miss:
                    this.FadeOut(FadeOutTime / 5);
                    break;
                case ArmedState.Hit:

                    const double flash_in = 40;


                    using (BeginDelayedSequence(flash_in, true))
                    {
                        Template.FadeOut(flash_in);
                    }
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
