using System.Collections.Generic;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     包住RP物件的容器
    /// </summary>
    public class RpContainerLineGroup : BaseRpObject, IHasEndTime
    {
        /// <summary>
        ///     結束時間，可以任意設定
        /// </summary>
        public override double EndTime { get; set; }

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

        //Fade Out time after PreemptTime
        public override float FadeInTime => 300 * FadeSpeedMultiple;

        //Fade Out time after EndTime 
        public override float FadeOutTime => 300 * FadeSpeedMultiple;
        /// <summary>
        ///     Layout
        /// </summary>
        public List<RpContainerLine> ContainerLayerList = new List<RpContainerLine>();

        /// <summary>
        ///     建立預設的Container
        /// </summary>
        /// <param name="startTime"></param>
        public RpContainerLineGroup(double startTime)
        {
            StartTime = startTime;
        }

        /// <summary>
        ///     初始化物件參數
        /// </summary>
        public override void InitialDefaultValue()
        {
            //顏色
            Colour = new Color4(0, 0, 0, 255);
            //初始化layout
            InitialLayer();
            //預設長度
            Lenght = 512;
            //速度
            Velocity = 1f;
            //預設試3秒後結束
            EndTime = StartTime + 3000;
        }

        /// <summary>
        ///     把容器切斷
        /// </summary>
        /// <param name="splitTime"></param>
        /// <returns></returns>
        public RpContainerLineGroup Split(double splitTime)
        {
            return new RpContainerLineGroup(splitTime);
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
            ContainerLayerList.Add(new RpContainerLine(this));
        }
    }
}
