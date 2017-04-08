using System.Collections.Generic;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Height;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Position;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Container;
using OpenTK;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.Container
{
    /// <summary>
    /// </summary>
    internal partial class ContainerTemplate : RpDrawBaseObjectTemplate
    {
        /// <summary>
        ///     放置Layout物件的地方
        /// </summary>
        public List<ContainerLayoutTemplate> ListLayoutTemplate = new List<ContainerLayoutTemplate>();

        /// <summary>
        ///     按壓的template
        /// </summary>
        public ContainerLongPressDrawComponent ContainerLongPressDrawComponent;

        /// <summary>
        ///     打擊物件(Container)
        /// </summary>
        protected ObjectContainer HitObject;

        private readonly List<IChangeableContainerComponent> IChangeableContainerComponent = new List<IChangeableContainerComponent>();

        /// <summary>
        ///     背景
        /// </summary>
        private ContainerBackgroundComponent _containerBackgroundComponent;

        /// <summary>
        ///     判定線
        /// </summary>
        private ContainerDecisionLineComponent _containerDecisionLineComponent;

        /// <summary>
        ///     開始結束
        /// </summary>
        private ContainerStartEndComponent _containerStartEndComponent;

        /// <summary>
        ///     顯示節拍線的
        /// </summary>
        private ContainerBeatLineComponent _containerBeatLineComponent;

        /// <summary>
        ///     負責計算物件在時間點該有的位置
        /// </summary>
        private readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        /// <summary>
        ///     計算物件的相關高度和Height位置
        /// </summary>
        private readonly ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        public ContainerTemplate(ObjectContainer hitObject)
            : base(hitObject)
        {
            HitObject = hitObject;
            //設定目前物件
            InitialTemplate();
            //Layout
            InitialListLayoutTemplate();
            //打擊物件
            InitialHitObject();
            //把所有物件加入到子物件當中
            InitialChild();
            //
            AddAllComponentToIChangeableContainerComponent();
            //ChangeHeight
            UpdateContainerHeight();
        }

        /// <summary>
        ///     修改物件寬度
        /// </summary>
        /// <param name="newHeight"></param>
        public void UpdateContainerHeight()
        {
            _heightCalculator.LayoutCount = ListLayoutTemplate.Count;
            var newHeight = _heightCalculator.GetContainerHeight();
            IChangeableContainerComponent.ForEach(c => c.ChangeHeight(newHeight));
        }

        /// <summary>
        ///     增加物件
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public void AddObject(DrawableRpLongPress drawableHitObject)
        {
            ContainerLongPressDrawComponent.Add(drawableHitObject);
        }

        /// <summary>
        ///     根據時間點計算物件位置
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time, HitObject.Velocity), 0);
        }

        /// <summary>
        ///     取得原點座標
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRowPosition()
        {
            return HitObject.Position;
        }

        /// <summary>
        ///     淡入
        /// </summary>
        /// <param name="time">有多少時間可以FadeIn</param>
        public override void FadeIn(double time = 0)
        {
            base.FadeIn(time);

            // 通知所有layout要開始fade in 了
            foreach (var layout in ListLayoutTemplate)
                layout.FadeIn(time);
            _containerBackgroundComponent.FadeIn(time);
        }

        /// <summary>
        ///     淡出
        /// </summary>
        /// <param name="time"></param>
        public override void FadeOut(double time = 0)
        {
            base.FadeOut(time);

            // 通知所有layout要開始fade out 了
            foreach (var layout in ListLayoutTemplate)
                layout.FadeOut(time);

            _containerBackgroundComponent.FadeOut(time);
        }

        /// <summary>
        ///     從這裡去更新物件位置
        /// </summary>
        protected override void Update()
        {
            //計算指針位置 
            _containerDecisionLineComponent.UpdateTime(Time.Current);
        }

        /// <summary>
        ///     增加所有物件到 IChangeableContainerComponent 裡
        /// </summary>
        private void AddAllComponentToIChangeableContainerComponent()
        {
            IChangeableContainerComponent.Clear();
            //背景
            IChangeableContainerComponent.Add(_containerBackgroundComponent);
            //節拍點
            IChangeableContainerComponent.Add(_containerBeatLineComponent);
            ///開始結束點
            IChangeableContainerComponent.Add(_containerStartEndComponent);
            //按壓
            IChangeableContainerComponent.Add(ContainerLongPressDrawComponent);
            //指標
            IChangeableContainerComponent.Add(_containerDecisionLineComponent);
        }

        /// <summary>
        ///     初始化Layout
        /// </summary>
        private void InitialListLayoutTemplate()
        {
            foreach (var layout in HitObject.ContainerLayerList)
                ListLayoutTemplate.Add(new ContainerLayoutTemplate(layout));
        }

        /// <summary>
        ///     初始化打擊物件
        /// </summary>
        private void InitialHitObject()
        {
            /*
            foreach (RPLongPress longPress in _hitObject.ListRPLongPress)
            {
                DrawableRPLongPress pressObject = new DrawableRPLongPress(longPress);
                pressObject.Position = new OpenTK.Vector2();
                ListPressObject.Add(pressObject);
            }
            */
        }


        /// <summary>
        /// </summary>
        private void InitialTemplate(int layerCount = 1)
        {
            //背景物件
            _containerBackgroundComponent = new ContainerBackgroundComponent(HitObject);
            //指標
            _containerDecisionLineComponent = new ContainerDecisionLineComponent(HitObject);
            //開始結束點
            _containerStartEndComponent = new ContainerStartEndComponent(HitObject);
            //長壓
            ContainerLongPressDrawComponent = new ContainerLongPressDrawComponent(HitObject);
            //節拍線
            _containerBeatLineComponent = new ContainerBeatLineComponent(HitObject);

            //旋轉角度
            Rotation = HitObject.Rotation;
        }

        /// <summary>
        /// </summary>
        private void InitialChild()
        {
            //要加到仔物件的所有物件
            var listContainer = new List<Framework.Graphics.Containers.Container>();
            //背景
            listContainer.Add(_containerBackgroundComponent);
            //節拍點
            listContainer.Add(_containerBeatLineComponent);
            ///開始結束點
            listContainer.Add(_containerStartEndComponent);
            //按壓
            listContainer.Add(ContainerLongPressDrawComponent);
            //Layout
            listContainer.AddRange(ListLayoutTemplate);
            //指標
            //listContainer.Add(_containerDecisionLineComponent);

            Children = listContainer;
        }
    }
}
