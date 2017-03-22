using System;
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
        public void PostProcess(Beatmap<BaseRpObject> beatmap)
        {
            if (beatmap.HitObjects.Count == 0)
            {
                throw new ArgumentNullException();
            }
        }

    }
}
