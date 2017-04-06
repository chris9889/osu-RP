using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.PostConvert;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap
{
    /// <summary>
    ///     can convert any beatmap from any other beatmap
    /// </summary>
    public class BeatmapConvertor : IBeatmapConverter<BaseRpObject>
    {
        //切片
        private readonly SliceProcessor SliceProcessor = new SliceProcessor();

        //建構Container
        private readonly ContainerProcessor ContainerProcessor = new ContainerProcessor();

        //建構打擊物件
        private readonly HitObjectProcessor HitObjectProcessor = new HitObjectProcessor();

        //把參數轉回RP物件
        private readonly PostConvertor PostConvertor = new PostConvertor();

        /// <summary>
        ///     轉換Beatmap
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public Beatmap<BaseRpObject> Convert(Beatmap original)
        {
            return new Beatmap<BaseRpObject>(original)
            {
                HitObjects = convertHitObjects(original, original.BeatmapInfo?.StackLeniency ?? 0.7f)
            };
        }


        /// <summary>
        ///     裡面丟入的都是OsuHitObject
        ///     要轉換成 RPHitObject
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<BaseRpObject> convertHitObjects(Beatmap originalBeatmap, float stackLeniency)
        {
            //先把listObject切出來
            var listComvertParameter = SliceProcessor.GetListComvertParameter(originalBeatmap);
            //整理出Container
            listComvertParameter = ContainerProcessor.Convert(listComvertParameter);
            //整理出HitObjects
            listComvertParameter = HitObjectProcessor.Convert(listComvertParameter);
            //轉回原本的物件
            return PostConvertor.Convert(listComvertParameter);
        }
    }
}
