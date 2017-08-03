// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component;
using osu.Game.Rulesets.RP.SkinManager;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer
{
    /// <summary>
    /// </summary>
    public class RpContainerLineTemplate : BaseRpContainableTemplate<DrawableBaseRpHitableObject>
    {
        public new RpContainerLine RpObject
        {
            get { return (RpContainerLine)base.RpObject; }
        }

        /// <summary>
        ///     負責計算物件在時間點該有的位置
        /// </summary>
        private readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        /// <summary>
        ///     計算物件皁E��關高度和Height位置
        /// </summary>
        private readonly ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        /// <summary>
        ///     顯示單行背景
        /// </summary>
        private ContainerBackgroundComponent _rpRectanglePiece;

        /// <summary>
        ///     顯示單行背景
        /// </summary>
        private ContainerBackgroundComponent _linePiece;

        public RpContainerLineTemplate(RpContainerLine rpObject)
            : base(rpObject)
        {
        }

        protected override void ConstructComponent()
        {
            //背景物件
            _linePiece = new ContainerBackgroundComponent(RpObject.ParentObject)
            {
                Origin = Anchor.CentreRight,
                Scale = new Vector2(1.0f, 0f),
                Colour = RpTextureColorManager.GetCoopJudgementLineColor(RpObject.Coop)
            };

            //背景物件
            _rpRectanglePiece = new ContainerBackgroundComponent(RpObject.ParentObject)
            {
                Scale = new Vector2(1.0f, 0f),
                Alpha = 0.5f,
                Colour = RpTextureColorManager.GetCoopLayoutColor(RpObject.Coop)
            };


            //背景
            Components.Add(_rpRectanglePiece);
            Components.Add(_linePiece);


            //初始化物件
            InitialHitObject();
            //更新物件
            UpdateHitObject();
        }

        protected override void InitialChild()
        {
            Children = Components.ToArray();
        }

        /// <summary>
        ///     初始化Layout
        /// </summary>
        private void InitialHitObject()
        {
        }

        /// <summary>
        ///     更新物件
        /// </summary>
        private void UpdateHitObject()
        {
            foreach (var hitObject in ListContainObject)
                hitObject.Position = new Vector2(100, 100);
        }

        /// <summary>
        ///     增加物件
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public override void AddObject(DrawableBaseRpHitableObject drawableHitObject)
        {
            drawableHitObject.Position = CalculatePosition(((DrawableBaseRpObject)drawableHitObject).HitObject.StartTime) + GetRowPosition();
            base.AddObject(drawableHitObject);
        }

        /// <summary>
        ///     根據時間點計算物件位置
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time - RpObject.StartTime, RpObject.Velocity), 0);
        }

        /// <summary>
        ///     取得原點座樁E
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRowPosition()
        {
            return RpObject.ParentObject.Position + Position;
        }

        public override void FadeIn(double time = 0)
        {
            base.FadeIn(time);
        }

        public override void FadeOut(double time = 0)
        {
            base.FadeOut(time);
        }

        /// <summary>
        ///     隨時更新位置
        /// </summary>
        protected override void Update()
        {
            _linePiece.Position = CalculatePosition(Time.Current);
            base.Update();
        }
    }
}
