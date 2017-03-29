using System;

namespace osu.Game.Modes.RP.Objects.type
{
    /// <summary>
    ///     所有物件基本
    /// </summary>
    public class RpBaseObjectType
    {
        /// <summary>
        ///     哪一種物件
        /// </summary>
        [Flags]
        public enum ObjectType
        {
            Undefined = 1,
            HitObject = 2,
            Container = 4,
            ContainerLayout = 8,
            Click = 16, //打
            LongTail = 32, //Slider
            Hold = 64, //壓住可以累積分數
            ContainerPress = 128, //背景壓住
            NewCombo = 256
        }

        /// <summary>
        ///     物件是轉換過的，還是原本譜面
        /// </summary>
        [Flags]
        public enum Comvert
        {
            Original,
            Comvert
        }

        /// <summary>
        ///     物件移動的軌跡類型
        /// </summary>
        [Flags]
        public enum CurveTypes
        {
            Catmull,
            Bezier,
            Linear,
            PerfectCurve
        }

        /// <summary>
        ///     定義是正常模式還是gold 模式
        ///     如果是在Arcade 模式底下兩個一起按的也會變成gold 模式
        /// </summary>
        [Flags]
        public enum Special
        {
            Normal = 0,
            Gold = 1
        }

        /// <summary>
        ///     出現位置
        ///     要全自動，半自動還是全部手動
        /// </summary>
        [Flags]
        public enum CurveGenerate
        {
            //RP譜面，所有頂點都是手動
            Manual = 1,
            //RP譜面，只有製作開始和結束位置
            Manual_Start_End_Position = 2,
            //RP譜面，只有設定開始位置
            Manual_StartPosition = 4,
            //全部由osu譜面出來的
            Auto = 8
        }
    }

    /// <summary>
    ///     物件類型
    /// </summary>
    public class RpBaseHitObjectType : RpBaseObjectType
    {
        /// <summary>
        ///     定義物件類別
        ///     鍵盤設定也會用到
        /// </summary>
        [Flags]
        public enum Shape
        {
            Up = 1, //三角(對應上下左右的定義)
            Down = 2, //叉叉
            Left = 4, //方
            Right = 8, //圈圈
            Special = 16, // Up| Down| Left| Right, //特殊，隨便按一個鍵都OK
            ContainerPress = 32
        }

        /// <summary>
        ///     是同時按壓一個鍵還是多個同時
        /// </summary>
        [Flags]
        public enum Multi
        {
            SingleClick,
            Multi
        }

        /// <summary>
        ///     是左右邊都OK
        ///     還是只有其中一邊
        /// </summary>
        [Flags]
        public enum LeftRight
        {
            LeftOnly,
            RightOnly,
            Both
        }

        /// <summary>
        ///     定義落下方式是osu! 那樣還是 Diva那樣
        /// </summary>
        [Flags]
        public enum ApproachType
        {
            ApproachCircle,
            flow
        }
    }

    /// <summary>
    ///     RPHitObject物件類型
    /// </summary>
    public class RpHitObjectType : RpBaseHitObjectType
    {
    }

    /// <summary>
    ///     RPHitObject物件類型
    /// </summary>
    public class RpHoldType : RpBaseHitObjectType
    {
    }

    /// <summary>
    ///     RPLongTailObject物件類型
    /// </summary>
    public class RpLongTailObjectType : RpBaseHitObjectType
    {
    }

    /// <summary>
    ///     RPLeftRightSlider物件類型
    /// </summary>
    public class RpContainerPressType : RpBaseHitObjectType
    {
        /// <summary>
        ///     時間點顯示倍率
        /// </summary>
        public enum ShowTimeLineView
        {
            none,
            normal,
            _2x,
            _3x,
            _4x,
            _6x,
            _8x
        }
    }
}
