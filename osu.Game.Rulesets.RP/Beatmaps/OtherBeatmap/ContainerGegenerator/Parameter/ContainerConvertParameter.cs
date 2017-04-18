using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Parameter
{
    public class containerConvertParameter
    {
        /// <summary>
        ///     The container number.
        /// </summary>
        public int ContainerNumber = 1;

        /// <summary>
        ///     The layout number.
        /// </summary>
        public int LayoutNumber = 1;

        /// <summary>
        ///     enable multiObject or not
        /// </summary>
        public bool MultiObjectMode = false;

        /// <summary>
        ///     all of the container class
        /// </summary>
        public List<RpContainer> ListObjectContainer = new List<RpContainer>();
    }
}
