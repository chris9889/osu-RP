using System.Collections.Generic;
using osu.Framework.MathUtils;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.PathPrecentage;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.Common;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template
{

    /// <summary>
    ///     基本樣板
    ///     會控制物件要擺放位置
    /// </summary>
    public class RpDrawBaseObjectTemplate : Framework.Graphics.Containers.Container
    {

        public DrawableBaseRpObject DrawablehitObject { get; set; }

        public BaseRpObject HitObject => DrawablehitObject.HitObject;

        /// <summary>
        ///     整體延遲時間
        /// </summary>
        public double DelayTime = 0;

        /// <summary>
        ///     打擊點上的物件，會隨時間移動
        /// </summary>
        public List<IComponentSliderProgress> Components = new List<IComponentSliderProgress>();

        /// <summary>
        ///     把所有開頭物件都丟在這裡
        /// </summary>
        public BaseComponent StartObjectContainer;

       

        /// <summary>
        ///     百分比計算
        /// </summary>
        protected PathPrecentageCounter PathPrecentageCounter;

        /// <summary>
        ///     載入特效
        /// </summary>
        protected LoadEffect LoadEffect;


        public RpDrawBaseObjectTemplate(DrawableBaseRpObject drawablehitObject)
        {
            DrawablehitObject = drawablehitObject;

            LoadEffect = new LoadEffect(DrawablehitObject.HitObject);

            PathPrecentageCounter = new PathPrecentageCounter(drawablehitObject.HitObject);

            Position = drawablehitObject.Position;

            //裝基本物件用
            StartObjectContainer = new BaseComponent();

            InitialStartObjectEffect();
        }

        /// <summary>
        ///     更新樣板顯示
        /// </summary>
        public void UpdateTemplate(double currentTime)
        {
            UpdateProgress(currentTime);
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public virtual void Initial()
        {
            LoadEffect.Initial();
        }

        /// <summary>
        ///     淡入(開始顯示物件)
        /// </summary>
        /// <param name="time"></param>
        public virtual void FadeIn(double time = 0)
        {
            LoadEffect.FadeIn();
        }

        /// <summary>
        /// </summary>
        /// <param name="time"></param>
        public virtual void FadeOut(double time = 0)
        {
            LoadEffect.FadeOut();
        }

        /// <summary>
        ///     更新
        ///     會更新物件位置
        /// </summary>
        protected void UpdateProgress(double currentTime)
        {
            //開始 結束 進度
            var startProgress = PathPrecentageCounter.CalculatePrecentage(HitObject.StartTime - currentTime + DelayTime);
            var endProgress = PathPrecentageCounter.CalculatePrecentage(HitObject.EndTime - currentTime + DelayTime);
            //影響程度
            var curveEasingTypesPrecentage = DrawablehitObject.HitObject.CurveEasingTypesPrecentage;

            //修正
            startProgress = MathHelper.Clamp(startProgress, 0, 1);
            endProgress = MathHelper.Clamp(endProgress, 0, 1);
            //根據設定曲線去改變百分比
            startProgress = Interpolation.ApplyEasing(HitObject.CurveEasingTypes, startProgress, 0, 1, 1) * curveEasingTypesPrecentage + startProgress * (1 - curveEasingTypesPrecentage);
            endProgress = Interpolation.ApplyEasing(HitObject.CurveEasingTypes, endProgress, 0, 1, 1) * curveEasingTypesPrecentage + endProgress * (1 - curveEasingTypesPrecentage);


            //更新開始打擊和放開打擊的位置定義
            Components.ForEach(c => c.UpdateProgress(startProgress, endProgress));
        }

        protected override void Update()
        {
            base.Update();  
        }

        /// <summary>
        ///     設定包在開始特效裡面的物件的Scale
        /// </summary>
        private void InitialStartObjectEffect()
        {
            StartObjectContainer.ScaleTo(0, 0);
            StartObjectContainer.ScaleTo(1, 500);

            StartObjectContainer.Alpha = 0;
            StartObjectContainer.FadeTo(0.7f, 50);
            StartObjectContainer.FadeTo(1.0f, 100);
        }
    }
}
