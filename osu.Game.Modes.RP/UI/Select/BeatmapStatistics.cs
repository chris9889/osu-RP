using System;
using System.Collections;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Graphics;

namespace osu.Game.Modes.RP.UI.Select
{
    /// <summary>
    ///     統計beatmap數據
    /// </summary>
    internal class BeatmapStatistics : IEnumerable<BeatmapStatistic>
    {
        private Game.Beatmaps.Beatmap _beatmap;

        public BeatmapStatistics(WorkingBeatmap beatmap)
        {
            _beatmap = beatmap.Beatmap;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<BeatmapStatistic> GetEnumerator()
        {
            //打擊點數量
            yield return new BeatmapStatistic
            {
                Name = @"Hit",
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is HitCircle).ToString(),
                Icon = FontAwesome.fa_dot_circle_o
            };

            //slider數量
            yield return new BeatmapStatistic
            {
                Name = @"Slider",
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is Slider).ToString(),
                Icon = FontAwesome.fa_circle_o
            };

            //press數量
            yield return new BeatmapStatistic
            {
                Name = @"Press",
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is Slider).ToString(),
                Icon = FontAwesome.fa_circle_o
            };

            //Container數量
            yield return new BeatmapStatistic
            {
                Name = @"Container",
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is Slider).ToString(),
                Icon = FontAwesome.fa_circle_o
            };
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
