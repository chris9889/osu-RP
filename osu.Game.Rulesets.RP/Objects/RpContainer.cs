using System.Collections.Generic;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     包住RP物件的容器
    /// </summary>
    public class RpContainer : BaseRpObject, IHasPosition, IHasEndTime
    {
        /// <summary>
        ///     結束時間，可以任意設定
        /// </summary>
        public override double EndTime => ContainerEndTime;

        public float X => Position.X;
        public float Y => Position.Y;

        public new RpBaseObjectType.ObjectType ObjectType = RpBaseObjectType.ObjectType.Container;

        /// <summary>
        ///     旋轉角度
        /// </summary>
        public float Rotation;

        /// <summary>
        ///     物件長度
        /// </summary>
        public float Lenght = 512;

        /// <summary>
        /// </summary>
        public double ContainerEndTime;

        /// <summary>
        ///     取得目前的BGM速度
        /// </summary>
        public double BPM = 180;

        /// <summary>
        ///     顯示倍率
        /// </summary>
        public RpContainerPressType.ShowTimeLineView ShowTimeLineViewMulti = RpContainerPressType.ShowTimeLineView._4x;

        /// <summary>
        ///     可以從反方向出來
        /// </summary>
        public bool Reverse;

        /// <summary>
        ///     要不要在時間點更新BPM
        /// </summary>
        public bool UpdateBPMByBeatmapTime = true;

        /// <summary>
        ///     Layout
        /// </summary>
        public List<RpContainerLayout> ContainerLayerList = new List<RpContainerLayout>();

        /// <summary>
        ///     建立預設的Container
        /// </summary>
        /// <param name="startTime"></param>
        public RpContainer(double startTime)
        {
            StartTime = startTime;
        }

        /// <summary>
        ///     初始化物件參數
        /// </summary>
        public override void InitialDefaultValue()
        {
            //時間
            TIME_FADEIN = 300;
            TIME_PREEMPT = 1500;
            TIME_FADEOUT = 300;
            //顏色
            Colour = new Color4(0, 0, 0, 255);
            //初始化layout
            InitialLayer();
            //預設長度
            Lenght = 512;
            //速度
            Velocity = 1f;
            //預設試3秒後結束
            ContainerEndTime = StartTime + 3000;
        }

        /// <summary>
        ///     把容器切斷
        /// </summary>
        /// <param name="SplitTime"></param>
        /// <returns></returns>
        public RpContainer Split(double SplitTime)
        {
            return new RpContainer(SplitTime);
        }

        /// <summary>
        ///     合併兩個物件
        ///     參數會參照前面那個
        ///     時間點會變成頭的開始和尾巴結束
        /// </summary>
        public void Conbine()
        {
        }

        /// <summary>
        ///     取得BPM
        /// </summary>
        /// <param name="beatmap"></param>
        /// <summary>
        ///     根據物件時間點更新BGM速度
        /// </summary>
        public void UpdateBPM()
        {
            if (UpdateBPMByBeatmapTime)
                BPM = 180; //_beatmap.BeatmapInfo.(StartTime);
        }

        /// <summary>
        ///     更新所有layout 的參數
        /// </summary>
        public void UpdateListChildLayout()
        {
            foreach (var layout in ContainerLayerList)
                layout.UpdateContainerLayout(this);
        }


        private void InitialLayer()
        {
            //每個Container裡面至少會有一層Layout
            ContainerLayerList.Add(new RpContainerLayout(this));
        }
    }
}
