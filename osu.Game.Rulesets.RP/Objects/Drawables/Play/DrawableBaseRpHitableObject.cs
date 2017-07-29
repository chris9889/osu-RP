// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.ComponentModel;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Common;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject;
using osu.Game.Rulesets.RP.Scoreing;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    //DrawableBaseRpHitableObject
    public abstract class DrawableBaseRpHitableObject : DrawableBaseRpObject
    {
        // HitObject
        public new BaseRpHitableObject HitObject
        {
            get { return (BaseRpHitableObject)base.HitObject; }
        }

        public new BaseRpHitableObjectTemplate Template
        {
            get { return (BaseRpHitableObjectTemplate)base.Template; }
            set { base.Template = value; }
        }

        //press detector
        protected PressDetecor RpPressDetecor;

        //constructor
        protected DrawableBaseRpHitableObject(BaseRpHitableObject hitObject)
            : base(hitObject)
        {
            //載�E判斷黁E
            //if (Judgement == null)
            //    Judgement = CreateJudgement();
        }

        protected override void ConstructObject()
        {
            
        }

        protected override void InitialChildObject()
        {
            //press event
            InitialDetectPressEvent();
            //
            Children = new Drawable[]
            {
                Template,
                RpPressDetecor
            };
        }

        //press event
        protected void InitialDetectPressEvent()
        {
            //get press down and up event
            RpPressDetecor = new PressDetecor(HitObject, Judgement)
            {
                Hit = () =>
                {
                    OnKeyPressDown();
                    return true;
                },
                Release = () =>
                {
                    OnKeyPressUp();
                    return true;
                }
            };
        }

        //press down event
        protected virtual void OnKeyPressDown()
        {
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
            UpdateJudgement(true);
            //Debug.Print(Judgement.Result + " " + RpHitObject.StartTime + " " + Position.X + "," + Position.Y);
        }

        //press up event
        protected virtual void OnKeyPressUp()
        {
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
            //UpdateJudgement(true);
            //Debug.Print(Judgement.Result.ToString());
        }

        //update every frame
        protected override void Update()
        {
            base.Update();
        }

        //CheckJudgement
        protected override void CheckJudgement(bool userTriggered)
        {
            if (!userTriggered)
            {
                if (Judgement.TimeOffset > HitObject.Hit50)
                    Judgement.Result = HitResult.Miss;

                return;
            }

            var hitOffset = Math.Abs(Judgement.TimeOffset);

            var rpInfo = Judgement;
            rpInfo.HitExplosionPosition.Add(Position);

            if (hitOffset < HitObject.Hit50)
            {
                Judgement.Result = HitResult.Hit;
                rpInfo.Score = HitObject.ScoreResultForOffset(hitOffset);
            }
            else
            {
                Judgement.Result = HitResult.Miss;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected override RpJudgement CreateJudgement()
        {
            return new RpJudgement();
        }
    }

    //RpComboResult
    public enum RpComboResult
    {
        [Description(@"")] None,
        [Description(@"Good")] Good,
        [Description(@"Amazing")] Perfect
    }

    //RpScoreResult
    public enum RpScoreResult
    {
        [Description(@"Sad")] Sad,
        [Description(@"Safe")] Safe,
        [Description(@"Fine")] Fine,
        [Description(@"Cool")] Cool,
        [Description(@"Slider")] Slider
    }
}
