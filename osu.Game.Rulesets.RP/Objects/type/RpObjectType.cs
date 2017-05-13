using System;

namespace osu.Game.Rulesets.RP.Objects.type
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
            Click = 16, //扁E
            LongTail = 32, //Slider
            Hold = 64, //壓住可以累積�E數
            ContainerPress = 128, //背景壓佁E
            NewCombo = 256
        }

        /// <summary>
        ///     物件是轉換過的�E�還是原本譜面
        /// </summary>
        [Flags]
        public enum Convert
        {
            Original,
            Convert
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
        ///     定義是正常模式還是gold 模弁E
        ///     如果是在Arcade 模式底下�E個一起按的也會變�Egold 模弁E
        /// </summary>
        [Flags]
        public enum Special
        {
            Normal = 0,
            Gold = 1
        }

        /// <summary>
        ///     出現位置
        ///     要�E自動，半自動還是全部手動
        /// </summary>
        [Flags]
        public enum CurveGenerate
        {
            //RP譜面�E�所有頂點�E是手動
            Manual = 1,
            //RP譜面�E�只有製作開始和結束位置
            Manual_Start_End_Position = 2,
            //RP譜面�E�只有設定開始位置
            Manual_StartPosition = 4,
            //全部由osu譜面出侁E��
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
            Up = 1, //三见E對應上下左右皁E��義)
            Down = 2, //叉叉
            Left = 4, //方
            Right = 8, //圈圈
            Special = 16, // Up| Down| Left| Right, //特殊，隨便按一個鍵都OK
            ContainerPress = 32 //
        }

        /// <summary>
        ///     是同時按壓一個鍵邁E��多個同晁E
        /// </summary>
        [Flags]
        public enum Multi
        {
            SingleClick,
            Multi
        }

        /// <summary>
        ///     是左右邊�EOK
        ///     邁E��只有�E中一邁E
        /// </summary>
        [Flags]
        public enum Coop
        {
            LeftOnly,
            RightOnly,
            Both
        }

        /// <summary>
        ///     定義落下方式是osu! 那樣邁E�� Diva那樣
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
