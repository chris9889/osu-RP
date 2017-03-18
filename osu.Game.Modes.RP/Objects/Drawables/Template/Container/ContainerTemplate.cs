using osu.Game.Modes.RP.Objects.Drawables.Component;
using osu.Game.Modes.RP.Objects.Drawables.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using osu.Game.Modes.RP.Objects.Drawables.Calculator;
using osu.Framework.Graphics.Transforms;
using osu.Game.Modes.RP.Objects.Drawables.Component.Container;

namespace osu.Game.Modes.RP.Objects.Drawables.Template.Container
{
    /// <summary>
    /// 
    /// </summary>
    class ContainerTemplate : RpDrawBaseObjectTemplate
    {
        /// <summary>
        /// 背景
        /// </summary>
        ContainerBackgroundComponent _containerBackgroundComponent;

        /// <summary>
        /// 放置Layout物件的地方
        /// </summary>
        public List<ContainerLayoutTemplate> ListLayoutTemplate=new List<ContainerLayoutTemplate>();

        /// <summary>
        /// 按壓的template
        /// </summary>
        public ContainerLongPressDrawComponent ContainerLongPressDrawComponent;

        /// <summary>
        /// 判定線
        /// </summary>
        ContainerDecisionLineComponent _containerDecisionLineComponent;

        /// <summary>
        /// 開始結束
        /// </summary>
        ContainerStartEndComponent _containerStartEndComponent;

        /// <summary>
        /// 顯示節拍線的
        /// </summary>
        ContainerBeatLineComponent _containerBeatLineComponent;

        /// <summary>
        /// 負責計算物件在時間點該有的位置
        /// </summary>
        ContainerLayoutPositionCounter _positionCounter=new ContainerLayoutPositionCounter();

        /// <summary>
        /// 計算物件的相關高度和Height位置
        /// </summary>
        ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        /// <summary>
        /// 打擊物件(Container)
        /// </summary>
        protected new ObjectContainer HitObject;

        public ContainerTemplate(ObjectContainer hitObject) : base(hitObject)
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
        }

      

        /// <summary>
        /// 初始化Layout
        /// </summary>
        void InitialListLayoutTemplate()
        {
            foreach (ObjectContainerLayer layout in HitObject.ContainerLayerList)
            {
                ListLayoutTemplate.Add(new ContainerLayoutTemplate(layout));
            }
        }

        /// <summary>
        /// 初始化打擊物件
        /// </summary>
        void InitialHitObject()
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
        /// 從這裡去更新物件位置
        /// </summary>
        protected override void Update()
        {
            //計算指針位置 
            _containerDecisionLineComponent.UpdateTime(Time.Current);
        }

        

        /// <summary>
        /// 
        /// </summary>
        void InitialTemplate(int layerCount=1)
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
            this.Rotation = HitObject.Rotation;
        }


        /// <summary>
        /// 
        /// </summary>
        void InitialChild()
        {
            //要加到仔物件的所有物件
            List<osu.Framework.Graphics.Containers.Container> listContainer = new List<Framework.Graphics.Containers.Container>();
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

        /// <summary>
        /// 增加物件
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public void AddObject(DrawableRpLongPress drawableHitObject)
        {
            ContainerLongPressDrawComponent.Add(drawableHitObject);
        }

        /// <summary>
        /// 根據時間點計算物件位置
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Vector2 CalculatePosition(double time)
        {
            return new Vector2((float)_positionCounter.GetPointerPosition(time), 0);
        }

        /// <summary>
        /// 取得原點座標
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRowPosition()
        {
            return HitObject.Position;
        }

        /// <summary>
        /// 淡入
        /// </summary>
        /// <param name="time">有多少時間可以FadeIn</param>
        public override void FadeIn(double time = 0)
        {
            base.FadeIn(time);
            
            // 通知所有layout要開始fade in 了
            foreach (ContainerLayoutTemplate layout in ListLayoutTemplate)
            {
                layout.FadeIn(time);
            }
            _containerBackgroundComponent.FadeIn(time);
        }

        /// <summary>
        /// 淡出
        /// </summary>
        /// <param name="time"></param>
        public override void FadeOut(double time = 0)
        {
            base.FadeOut(time);

            // 通知所有layout要開始fade out 了
            foreach (ContainerLayoutTemplate layout in ListLayoutTemplate)
            {
                layout.FadeOut(time);
            }

            _containerBackgroundComponent.FadeOut(time);
        }
    }
}
