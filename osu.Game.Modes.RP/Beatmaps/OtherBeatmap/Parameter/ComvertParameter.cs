using System.Collections.Generic;
using osu.Game.Modes.Objects;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter
{
    /// <summary>
    /// a little monent of the beatmap
    /// </summary>
    public class ComvertParameter
    {
        /// <summary>
        /// original hit Object;
        /// can be use as refrence;
        /// </summary>
        public List<HitObject> ListRefrenceObject = new List<HitObject>();

        /// <summary>
        /// 切片時臨時會用參數
        /// </summary>
		public SliceConvertParameter SliceConvertParameter = new SliceConvertParameter();

        /// <summary>
        /// 打擊物件會用到的參數
        /// </summary>
        public HitObjectConvertParameter HitObjectConvertParameter = new HitObjectConvertParameter();

        /// <summary>
        /// Container 會用到的臨時參數
        /// </summary>
        public containerConvertParameter ContainerConvertParameter = new containerConvertParameter();
        
    }
}
