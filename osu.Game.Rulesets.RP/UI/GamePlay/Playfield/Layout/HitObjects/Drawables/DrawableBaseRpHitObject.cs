//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.ComponentModel;
using osu.Framework.Audio.Sample;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.DrawableDetectPress;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    /// <summary>
    ///     郢ｪ陬ｽ蜿ｯ莉･謇捺投逧・・ｽ・ｽ莉ｶ
    /// </summary>
    internal class DrawableBaseRpHitObject : DrawableBaseRpObject
    {
        /// <summary>
        ///     謇捺投迚ｩ莉ｶ・ｽE・ｽDrawableHitCircle 譛・・ｽ・ｽ謫壽遠謫顔黄莉ｶ謚・迚ｩ莉ｶ郢ｪ陬ｽ蜃ｺ萓・
        /// </summary>
        public new BaseRpHitObject HitObject;

        /// <summary>
        ///     逶ｮ蜑肴弍逡ｶ菴彝P迚ｩ莉ｶ逧・・ｽ・ｽ蟆ｾ
        /// </summary>
        protected DetectPress _rpDetectPress;

        private SampleChannel seeya;

        /// <summary>
        ///     蟒ｺ讒具ｼ梧園譛臥噪RP迚ｩ莉ｶ荳螳夊ｦ∝ｻｺ讒句芦騾咎ｊ
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableBaseRpHitObject(BaseRpHitObject hitObject)
            : base(hitObject)
        {
            HitObject = hitObject;
            //霈会ｿｽE蛻､譁ｷ鮟・
            if (Judgement == null)
                Judgement = CreateJudgement();

            Template = new RpDrawBaseObjectTemplate(HitObject)
            {
                //Position = this.Position,
                Alpha = 1
            };

            //蛻晏ｧ句喧
            InitialDetectPressEvent();


            Children = new Drawable[]
            {
                Template
                //_rpDetectPress
            };
        }

        /// <summary>
        ///     謖我ｸ句悉
        ///     UpdateJudgement 逕ｨ騾・: 邨ｦ蜃ｺ荳蛟句愛螳夲ｼ檎岼蜑肴弍miss驍・・ｽ・ｽhit
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
        ///     謖∫ｺ御ｸ逶ｴ譖ｴ譁ｰ迚ｩ莉ｶ
        /// </summary>
        protected override void Update()
        {
            base.Update();

            //譖ｴ譁ｰ迚ｩ莉ｶ菴咲ｽｮ
            Template.UpdateTemplate(Time.Current);
        }

        /// <summary>
        ///     RP蛻､譁ｷ
        /// </summary>
        /// <returns></returns>
        protected override RpJudgement CreateJudgement() => new RpJudgement();


        /// <summary>
        ///     讙｢譟･蛻､螳夐ｻ・
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
            //謚灘叙謖我ｸ狗噪莠倶ｻｶ
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
    ///     螯よ棡驕・・ｽ・ｽcombo逧・・ｽ・ｽ豕・
    ///     逕ｨ荳榊芦・ｽE・ｽ菴・・ｽ・ｽ蜑搾ｿｽE荳崎ｦ∫ｧｻ髯､
    /// </summary>
    public enum RpComboResult
    {
        [Description(@"")] None,
        [Description(@"Good")] Good,
        [Description(@"Amazing")] Perfect
    }

    /// <summary>
    ///     荳闊ｬ謇捺投
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
