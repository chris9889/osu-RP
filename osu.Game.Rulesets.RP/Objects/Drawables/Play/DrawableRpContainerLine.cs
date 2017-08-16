// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer;
using osu.Game.Rulesets.RP.Scoreing;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    public class DrawableRpContainerLine : DrawableBaseContainableObject<DrawableBaseRpHitableObject> 
    {
        /// <summary>
        /// </summary>
        public new RpContainerLine HitObject
        {
            get { return (RpContainerLine)base.HitObject; }
        }

        /// <summary>
        ///     template
        /// </summary>
        public new RpContainerLineTemplate Template => (RpContainerLineTemplate)base.Template;

        private bool _startFadeont;

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableRpContainerLine(BaseRpObject hitObject)
            : base(hitObject)
        {
        }

        protected override void ConstructObject()
        {
            base.Template = new RpContainerLineTemplate(HitObject)
            {
                Position = new Vector2(0, 0),
                Alpha = 1
            };
        }

        protected override void InitialChildObject()
        {
            Children = new Drawable[]
            {
                Template
            };
        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public override void AddObject(DrawableBaseRpHitableObject dragObject)
        {
            ((RpContainerLineTemplate)Template).AddObject(dragObject);
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

            //如果時間趁E��就執衁E
            if (HitObject.EndTime < Time.Current && !_startFadeont)
            {
                _startFadeont = true;
                this.FadeOut(FadeOutTime);
                Template.FadeOut(FadeOutTime);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected override RpJudgement CreateJudgement()
        {
            return new RpJudgement();
        }

        /// <summary>
        ///     從這邊去更新狀慁E
        /// </summary>
        /// <param name="userTriggered"></param>
        protected override void CheckJudgement(bool userTriggered)
        {
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateCurrentState(ArmedState state)
        {
            this.Delay(HitObject.Duration + PreemptTime + FadeOutTime);

            if (state == ArmedState.Hit)
            {
            }
        }
    }
}
