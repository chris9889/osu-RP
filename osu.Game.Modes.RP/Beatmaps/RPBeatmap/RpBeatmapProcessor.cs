using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.Objects;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.RPBeatmap
{
    /// <summary>
    /// RP譜面轉成物件
    /// </summary>
    class RpBeatmapProcessor : IBeatmapProcessor<BaseRpObject>
    {
        public RpBeatmapProcessor()
        {

        }

        public Beatmap<BaseRpObject> Convert(Beatmap original)
        {
            return new Beatmap<BaseRpObject>(original)
            {
                HitObjects = convertHitObjects(original.HitObjects, original.BeatmapInfo?.StackLeniency ?? 0.7f)
            };
        }

        public void PostProcess(Beatmap<BaseRpObject> beatmap)
        {
            //throw new NotImplementedException();
        }

        private List<BaseRpObject> convertHitObjects(List<HitObject> hitObjects, float stackLeniency)
        {
            List<HitObject> input = hitObjects;
            List<BaseRpObject> output = new List<BaseRpObject>();
            foreach (HitObject h in input)
                output.Add((BaseRpObject)h);
            return output;
        }
    }
}
