using System;

namespace osu.Game.Modes.RP.Objects.type
{
    /// <summary>
    /// 物件類型
    /// </summary>
    public class RpBaseHitObjectType : RpBaseObjectType
    {
        /// <summary>
        /// 定義物件類別
        /// 鍵盤設定也會用到
        /// </summary>
        [Flags]
        public enum Shape
        {
            Triangle = 1, //三角(對應上下左右的定義)
            Cross = 2, //叉叉
            Square = 4, //方
            Circle = 8, //圈圈
            Special = 16, // Triangle| Cross| Square| Circle, //特殊，隨便按一個鍵都OK
            ContainerPress=32,
        }

        /// <summary>
        /// 是同時按壓一個鍵還是多個同時
        /// </summary>
        [Flags]
        public enum Multi
        {
            SingleClick,
            Multi
        }

        /// <summary>
        /// 是左右邊都OK
        /// 還是只有其中一邊
        /// </summary>
        [Flags]
        public enum LeftRight
        {
            LeftOnly,
            RightOnly,
            Both
        }

        /// <summary>
        /// 定義落下方式是osu! 那樣還是 Diva那樣
        /// </summary>
        [Flags]
        public enum ApproachType
        {
            ApproachCircle,
            flow,
        }
    }
}