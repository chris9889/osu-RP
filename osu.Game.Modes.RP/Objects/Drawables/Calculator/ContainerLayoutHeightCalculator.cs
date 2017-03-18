using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Modes.RP.Objects.Drawables.Calculator
{
    /// <summary>
    /// 用來計算物件寬度，還有相對應該出現的位置等等
    /// </summary>
    class ContainerLayoutHeightCalculator
    {

        const float LAYOUT_HEIGHT = 35;

        const float LAYOUT_INTERVAL_HEIGHT = 40;

        const float CONTAINER_TO_FIRST_LAYOUT_HEIGHT = 20;

        int _layoutCount;

        public void SetLayoutCount(int layoutCount)
        {
            _layoutCount = layoutCount;
        }

        /// <summary>
        /// Container 寬度
        /// </summary>
        public float GetContainerHeight()
        {
            return LAYOUT_INTERVAL_HEIGHT * _layoutCount + CONTAINER_TO_FIRST_LAYOUT_HEIGHT * 2;
        }

        /// <summary>
        /// Layout
        /// </summary>
        public float GetLayoutPosition(int layoutIndex)
        {
            return  LAYOUT_INTERVAL_HEIGHT * layoutIndex;
        }

        /// <summary>
        /// 取得
        /// </summary>
        /// <returns></returns>
        public float GetLayoutHeight()
        {
            return LAYOUT_HEIGHT;
        }
    }
}
