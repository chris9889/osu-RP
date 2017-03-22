//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.ComponentModel;
using osu.Game.Modes.Objects.Drawables;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Template;
using osu.Game.Modes.RP.KeyManager;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Game.Beatmaps.Samples;
using System;
using System.Diagnostics;
using osu.Framework.Audio.Sample;
using osu.Framework.Input;
using osu.Game.Modes.RP.Objects.Drawables.Calculator.DrawableDetectPress;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common;
using osu.Game.Modes.RP.ScoreProcessor;

namespace osu.Game.Modes.RP.Objects.Drawables
{
    /// <summary>
    /// 繪製可以打擊的物件
    /// </summary>
    class DrawableBaseHitObject : DrawableBaseRpObject
    {

        /// <summary>
        /// 目前是當作RP物件的結尾
        /// </summary>
        protected DetectPress _rpDetectPress;

        /// <summary>
        /// 打擊物件，DrawableHitCircle 會根據打擊物件把 物件繪製出來
        /// </summary>
        public new BaseHitObject HitObject;

        /// <summary>
        /// 建構，所有的RP物件一定要建構到這邊
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableBaseHitObject(BaseHitObject hitObject) : base(hitObject)
        {
            HitObject = hitObject;
            //載入判斷點
            if (Judgement == null)
                Judgement = CreateJudgementInfo();

            Template = new RpDrawBaseObjectTemplate(HitObject)
            {
                //Position = this.Position,
                Alpha = 1,
            };

            //初始化
            InitialDetectPressEvent();
            //預先取得那些按鍵按了會有作用
            _rpDetectPress.SetListKey(RpKeyManager.GetListKey(HitObject));
            

            Children = new Drawable[]
            {
                Template,
                _rpDetectPress,
            };
        }

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
                },
            };
        }

        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            Debug.Print("Down");
            return false;
        }

        protected override bool OnKeyUp(InputState state, KeyUpEventArgs args)
        {
            Debug.Print("Up");
            return false;
        }

        /// <summary>
        /// 按下去
        /// UpdateJudgement 用途 : 給出一個判定，目前是miss還是hit
        /// </summary>
        protected virtual void OnKeyPressDown()
        {
            
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
            UpdateJudgement(true);
            Debug.Print(Judgement.Result.ToString() + " "+HitObject.StartTime.ToString() +" "+ Position.X + "," + Position.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnKeyPressUp()
        {
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
            //UpdateJudgement(true);
            Debug.Print(Judgement.Result.ToString());
        }

        /// <summary>
        /// 持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();

            //更新物件位置
            Template.UpdateTemplate(Time.Current);
        }

        /// <summary>
        /// RP判斷
        /// </summary>
        /// <returns></returns>
        protected override RPJudgementInfo CreateJudgementInfo() => new RPJudgementInfo();
       

        /// <summary>
        /// 檢查判定點
        /// </summary>
        /// <param name="userTriggered"></param>
        protected override void CheckJudgement(bool userTriggered)
        {
            if (!userTriggered)
            {
                if (Judgement.TimeOffset > HitObject.hit50)
                {
                    Judgement.Result = HitResult.Miss;
                    //Debug.Print("Miss");
                }
                    
                return;
            }

            double hitOffset = Math.Abs(Judgement.TimeOffset);


            RPJudgementInfo rpInfo = Judgement as RPJudgementInfo;
            rpInfo.HitExplosionPosition.Add(Position);

            if (hitOffset < HitObject.hit50)
            {
                Judgement.Result = HitResult.Hit;
                rpInfo.Score = HitObject.ScoreResultForOffset(hitOffset);
            }
            else
                Judgement.Result = HitResult.Miss;
        }

        SampleChannel seeya;

        /// <summary>
        /// 聲音
        /// </summary>
        /// <param name="audio"></param>
        [BackgroundDependencyLoader]
        protected void load(AudioManager audio)
        {
            string hitType = (HitObject.Sample.Type == SampleType.None ? SampleType.Normal : HitObject.Sample.Type).ToString().ToLower();
            string sampleSet = HitObject.Sample.Set.ToString().ToLower();

            //sample = audio.Sample.Get($@"Gameplay/diva/{sampleSet}-hit{hitType}");
            seeya = audio.Sample.Get($@"Gameplay/diva/sound");
        }


    }

    /// <summary>
    /// 如果遇到combo的情況
    /// 用不到，但目前先不要移除
    /// </summary>
    public enum RPComboResult
    {
        [Description(@"")]
        None,
        [Description(@"Good")]
        Good,
        [Description(@"Amazing")]
        Perfect
    }

    /// <summary>
    /// 一般打擊
    /// </summary>
    public enum RPScoreResult
    {
        [Description(@"Sad")]
        Sad,
        [Description(@"Safe")]
        Safe,
        [Description(@"Fine")]
        Fine,
        [Description(@"Cool")]
        Cool,
        [Description(@"Slider")]
        Slider,
    }


   
}
