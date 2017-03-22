using System.Collections.Generic;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Parameter
{
	public class containerConvertParameter
    {
        /// <summary>
        /// The container number.
        /// </summary>
        public int ContainerNumber = 1;

        /// <summary>
        /// The layout number.
        /// </summary>
        public int LayoutNumber = 1;

        /// <summary>
        /// enable multiObject or not
        /// </summary>
        public bool MultiObjectMode = false;

        /// <summary>
        /// all of the container class
        /// </summary>
        public List<ObjectContainer> ListObjectContainer = new List<ObjectContainer>();
    }
}
