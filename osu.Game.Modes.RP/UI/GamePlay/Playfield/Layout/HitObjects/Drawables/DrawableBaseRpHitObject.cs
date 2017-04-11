//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.ComponentModel;
using osu.Framework.Audio.Sample;
using osu.Framework.Graphics;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.ScoreProcessor;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.DrawableDetectPress;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    /// <summary>
    ///     繪製可以打擊的物件
    /// </summary>
    internal class DrawableBaseRpHitObject : DrawableBaseRpObject
    {
        /// <summary>
        ///     打擊物件，DrawableHitCircle 會根據打擊物件把 物件繪製出來
        /// </summary>
        public new BaseRpHitObject HitObject;

        /// <summary>
        ///     目前是當作RP物件的結尾
        /// </summary>
        protected DetectPress _rpDetectPress;

        private SampleChannel seeya;

        /// <summary>
        ///     建構，所有的RP物件一定要建構到這邊
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableBaseRpHitObject(BaseRpHitObject hitObject)
            : base(hitObject)
        {
            HitObject = hitObject;
            //載入判斷點
            if (Judgement == null)
                Judgement = CreateJudgement();

            Template = new RpDrawBaseObjectTemplate(HitObject)
            {
                //Position = this.Position,
                Alpha = 1
            };

            //初始化
            InitialDetectPressEvent();


            Children = new Drawable[]
            {
                Template
                //_rpDetectPress
            };
        }

        /// <summary>
        ///     按下去
        ///     UpdateJudgement 用途 : 給出一個判定，目前是miss還是hit
        /// </summary>
        protected virtual void OnKeyPressDown()
        {
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
            UpdateJudgement(true);
            //Debug.Print(Judgement.Result + " " + HitObject.StartTime + " " + Position.X + "," + Position.Y);
        }

        /// <summary>
        /// </summary>
        protected virtual void OnKeyPressUp()
        {
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
            //UpdateJudgement(true);
            //Debug.Print(Judgement.Result.ToString());
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

        /// <summary>
        ///     RP判斷
        /// </summary>
        /// <returns></returns>
        protected override RpJudgement CreateJudgement() => new RpJudgement();


        /// <summary>
        ///     檢查判定點
        /// </summary>
        /// <param name="userTriggered"></param>
        protected override void CheckJudgement(bool userTriggered)
        {
            if (!userTriggered)
            {
                if (Judgement.TimeOffset > HitObject.hit50)
                    Judgement.Result = HitResult.Miss;

                return;
            }

            var hitOffset = Math.Abs(Judgement.TimeOffset);


            var rpInfo = Judgement;
            rpInfo.HitExplosionPosition.Add(Position);

            if (hitOffset < HitObject.hit50)
            {
                Judgement.Result = HitResult.Hit;
                rpInfo.Score = HitObject.ScoreResultForOffset(hitOffset);
            }
            else
            {
                Judgement.Result = HitResult.Miss;
            }
        }


        //[BackgroundDependencyLoader]
        //private void load(AudioManager audio)
        //{
        //    SampleType type = HitObject.Sample?.Type ?? SampleType.Whistle;
        //    if (type == SampleType.None)
        //        type = SampleType.Normal;

        //    SampleSet sampleSet = HitObject.Sample?.Set ?? SampleSet.Soft;

        //    Sample = audio.Sample.Get($@"Gameplay/{sampleSet.ToString().ToLower()}-hit{type.ToString().ToLower()}");
        //}

        private void InitialDetectPressEvent()
        {
            //抓取按下的事件
            _rpDetectPress = new DetectPress(HitObject, Judgement)
            {
                Hit = () =>
                {
                    //if (Judgement.Result.HasValue) return false;
                    OnKeyPressDown();
                    return true;
                },
                Release = () =>
                {
                    //if (Judgement.Result.HasValue) return false;
                    OnKeyPressUp();
                    return true;
                }
            };
        }
    }

    /// <summary>
    ///     如果遇到combo的情況
    ///     用不到，但目前先不要移除
    /// </summary>
    public enum RpComboResult
    {
        [Description(@"")] None,
        [Description(@"Good")] Good,
        [Description(@"Amazing")] Perfect
    }

    /// <summary>
    ///     一般打擊
    /// </summary>
    public enum RpScoreResult
    {
        [Description(@"Sad")] Sad,
        [Description(@"Safe")] Safe,
        [Description(@"Fine")] Fine,
        [Description(@"Cool")] Cool,
        [Description(@"Slider")] Slider
    }
}
