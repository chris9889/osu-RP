﻿using osu.Framework.Graphics;
using osu.Framework.Input;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    public class DrawableBaseRpObject : DrawableHitObject<BaseRpObject, RpJudgement>
    {
        //物件出現需要花的時間
        public readonly float FadeInTime = 100;
        //物件在打擊多久前提早出現
        public readonly float PreemptTime = 2000;
        //打擊過後多久會消失
        public readonly float FadeOutTime = 100;

        /// <summary>
        ///     打擊物件，DrawableHitCircle 會根據打擊物件把 物件繪製出來
        /// </summary>
        public new BaseRpObject HitObject;

        /// <summary>
        ///     樣板，把物件綁上去就對了
        /// </summary>
        protected RpDrawBaseObjectTemplate Template;

        public DrawableBaseRpObject(BaseRpObject hitObject)
            : base(hitObject)
        {
            FadeInTime = hitObject.FadeInTime;
            PreemptTime = hitObject.PreemptTime;
            FadeOutTime = hitObject.FadeOutTime;

            HitObject = hitObject;

            Origin = Anchor.Centre;
            Position = HitObject.Position;
            Scale = new Vector2(HitObject.Scale);
        }

        /// <summary>
        ///     更新狀態
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateState(ArmedState state)
        {
            state = ArmedState.Hit;

            if (!IsLoaded) return;

            Flush();

            UpdateInitialState();

            Delay(HitObject.StartTime - Time.Current - PreemptTime + Judgement.TimeOffset, true);

            UpdatePreemptState();

            Delay(PreemptTime, true);
        }

        /// <summary>
        /// </summary>
        protected virtual void UpdateInitialState()
        {
            //要設定成0 ，第一針才不會有殘影
            Alpha = 0;
        }

        /// <summary>
        /// </summary>
        protected virtual void UpdatePreemptState()
        {
            FadeIn(FadeInTime);
            //開始特效
            Template.FadeIn(FadeInTime);
        }

        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();

            //更新物件位置
            Template.UpdateTemplate(Time.Current);
        }


        protected override bool OnDoubleClick(InputState state)
        {
            if (!HitObject.Editable)
                return false;

            return base.OnDoubleClick(state);
        }

        protected override bool OnDragStart(InputState state)
        {
            if (!HitObject.Editable)
                return false;

            return base.OnDragStart(state);
        }

        protected override bool OnDrag(InputState state)
        {
            if (!HitObject.Editable)
                return false;

            return base.OnDrag(state);
        }

        protected override bool OnDragEnd(InputState state)
        {
            if (!HitObject.Editable)
                return false;

            return base.OnDragEnd(state);
            
        }

        //if rotate , notified the template
        public new float Rotation
        {
            get { return base.Rotation; }
            set
            {
                base.Rotation = value;
                ChangeRotationValue(base.Rotation);
            }
        }

        //update rotation value
        public virtual void ChangeRotationValue(float rotation)
        {

        }


        protected override RpJudgement CreateJudgement() => new RpJudgement { Score = RpScoreResult.Cool };
    }
}
