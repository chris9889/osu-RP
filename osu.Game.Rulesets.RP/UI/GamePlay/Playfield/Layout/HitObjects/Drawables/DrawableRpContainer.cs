using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    /// <summary>
    ///     匁E��RP物件
    /// </summary>
    internal class DrawableRpContainer : DrawableBaseRpObject
    {
        /// <summary>
        /// </summary>
        public new RpContainer HitObject;


        /// <summary>
        ///     樣板�E�把物件綁上去就對亁E
        /// </summary>
        public ContainerTemplate ContainerTemplate
        {
            get { return (ContainerTemplate)Template; }
            set { Template = value; }
        }

        private bool _startFadeont;

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableRpContainer(BaseRpObject hitObject)
            : base(hitObject)
        {
            HitObject = (RpContainer)hitObject;


            Template = new ContainerTemplate(HitObject)
            {
                Position = new Vector2(0, 0),
                Alpha = 1
            };

            Children = new Drawable[]
            {
                Template
            };

            //may not be so correct
            //Size = _rpDetectPress.DrawSize;
            Scale = new Vector2(HitObject.Scale);
        }


        /// <summary>
        ///     更新初始狀慁E
        /// </summary>
        protected override void UpdateInitialState()
        {
            base.UpdateInitialState();

            //sane defaults
            //ring.Alpha = _detectPress.Alpha = number.Alpha = glow.Alpha = 1;
            //初始化持E��E
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

            //如果時間趁E��就執衁E
            if (HitObject.EndTime < Time.Current && !_startFadeont)
            {
                _startFadeont = true;
                FadeOut(TIME_FADEOUT);
                Template.FadeOut(TIME_FADEOUT);
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
        protected override void UpdateState(ArmedState state)
        {
            base.UpdateState(state);
            Delay(HitObject.Duration + TIME_PREEMPT + TIME_FADEOUT);

            if (state == ArmedState.Hit)
            {
            }
        }
    }
}
