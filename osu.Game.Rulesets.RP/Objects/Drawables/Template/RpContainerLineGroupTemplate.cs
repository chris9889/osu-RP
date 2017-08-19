// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Linq;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer
{
    /// <summary>
    /// </summary>
    public class RpContainerLineGroupTemplate : BaseRpContainableTemplate<DrawableRpContainerLine>, IChangeableContainerComponent
    {
        public new RpContainerLineGroup RpObject
        {
            get { return (RpContainerLineGroup)base.RpObject; }
        }

        /// <summary>
        ///     按壓的template
        /// </summary>
        public ContainerLongPressDraw ContainerLongPressDraw;


        /// <summary>
        ///     負責計算物件在時間點該有的位置
        /// </summary>
        private readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        /// <summary>
        ///     計算物件皁E��關高度和Height位置
        /// </summary>
        private readonly ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        /// <summary>
        ///     背景
        /// </summary>
        private ContainerBackground containerBackground;

        /// <summary>
        ///     判定緁E
        /// </summary>
        private ContainerDecisionLine containerDecisionLine;

        /// <summary>
        ///     開始結束
        /// </summary>
        private ContainerStartEnd containerStartEnd;

        /// <summary>
        ///     顯示節拍線的
        /// </summary>
        private ContainerBeatLine containerBeatLine;

        public RpContainerLineGroupTemplate(RpContainerLineGroup rpObject)
            : base(rpObject)
        {
            //ChangeHeight
            UpdateContainerHeight();
        }

        //initial all component template will use
        protected override void ConstructComponent()
        {
            //背景物件
            containerBackground = new ContainerBackground(RpObject);
            //持E��E
            containerDecisionLine = new ContainerDecisionLine(RpObject);
            //開始結束黁E
            containerStartEnd = new ContainerStartEnd(RpObject);
            //長壁E
            ContainerLongPressDraw = new ContainerLongPressDraw(RpObject);
            //節拍緁E
            containerBeatLine = new ContainerBeatLine(RpObject);

            Components.Clear();
            //背景
            Components.Add(containerBackground);
            //節拍黁E
            Components.Add(containerBeatLine);
            ///開始結束黁E
            Components.Add(containerStartEnd);
            //按壁E
            Components.Add(ContainerLongPressDraw);
            //持E��E
            Components.Add(containerDecisionLine);
        }


        //call this to calculate new height
        public void UpdateContainerHeight()
        {
            _heightCalculator.LayoutCount = ListContainObject.Count;
            var newHeight = _heightCalculator.GetContainerHeight();
            ChangeHeight(newHeight);
        }

        //calculate position
        public Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time, RpObject.Velocity), 0);
        }

        //get row position
        public Vector2 GetRowPosition()
        {
            return RpObject.Position;
        }

        /// <summary>
        ///     從這裡去更新物件位置
        /// </summary>
        protected override void Update()
        {
            //
            containerDecisionLine.UpdateTime(Time.Current);
        }

        //Add object
        public override void AddObject(DrawableRpContainerLine dragObject)
        {
            dragObject.Position = GetRowPosition();

            base.AddObject(dragObject);
            //update Height
            UpdateContainerHeight();
        }

        /// <summary>
        ///     增加物件
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public void AddObject(DrawableRpContainerLineHoldObject drawableHitObject)
        {
            ContainerLongPressDraw.Add(drawableHitObject);
        }

        //if update new height
        public void ChangeHeight(float newHeight)
        {
            foreach (IChangeableContainerComponent single in Components.Where(n => n is IChangeableContainerComponent))
            {
                single.ChangeHeight(newHeight);
            }
        }
    }
}
