using System.Collections.Generic;
using osu.Framework.MathUtils;
using osu.Game.Modes.RP.Objects.Drawables.Calculator.PathPrecentage;
using osu.Game.Modes.RP.Objects.Drawables.Component;
using osu.Game.Modes.RP.Objects.Drawables.Component.Common;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Template
{
    /// <summary>
    ///     基本樣板
    ///     會控制物件要擺放位置
    /// </summary>
    internal class RpDrawBaseObjectTemplate : Framework.Graphics.Containers.Container
    {
        /// <summary>
        ///     整體延遲時間
        /// </summary>
        public double DelayTime = 0;

        /// <summary>
        ///     打擊點上的物件，會隨時間移動
        /// </summary>
        public List<ISliderProgress> Components = new List<ISliderProgress>();

        /// <summary>
        ///     把所有開頭物件都丟在這裡
        /// </summary>
        public BaseComponent StartObjectContainer;

        /// <summary>
        ///     物件
        /// </summary>
        protected BaseRpObject _hitObject;

        /// <summary>
        ///     百分比計算
        /// </summary>
        protected PathPrecentageCounter PathPrecentageCounter;

        /// <summary>
        ///     載入特效
        /// </summary>
        protected LoadEffect LoadEffect;

        public RpDrawBaseObjectTemplate(BaseRpObject hitObject)
        {
            _hitObject = hitObject;

            LoadEffect = new LoadEffect(_hitObject);

            PathPrecentageCounter = new PathPrecentageCounter(hitObject);

            Position = hitObject.Position;

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
            var startProgress = PathPrecentageCounter.CalculatePrecentage(_hitObject.StartTime - currentTime + DelayTime);
            var endProgress = PathPrecentageCounter.CalculatePrecentage(_hitObject.EndTime - currentTime + DelayTime);
            //影響程度
            var CurveEasingTypesPrecentage = _hitObject.CurveEasingTypesPrecentage;

            //修正
            startProgress = MathHelper.Clamp(startProgress, 0, 1);
            endProgress = MathHelper.Clamp(endProgress, 0, 1);
            //根據設定曲線去改變百分比
            startProgress = Interpolation.ApplyEasing(_hitObject.CurveEasingTypes, startProgress, 0, 1, 1) * CurveEasingTypesPrecentage + startProgress * (1 - CurveEasingTypesPrecentage);
            endProgress = Interpolation.ApplyEasing(_hitObject.CurveEasingTypes, endProgress, 0, 1, 1) * CurveEasingTypesPrecentage + endProgress * (1 - CurveEasingTypesPrecentage);


            //更新開始打擊和放開打擊的位置定義
            Components.ForEach(c => c.UpdateProgress(startProgress, endProgress));
        }

        /// <summary>
        ///     更新
        /// </summary>
        protected override void Update()
        {
            DrawConnectionLine();
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

        private void DrawConnectionLine()
        {
            var startposition = Position;
            var endposition = Position;
        }
    }
}
