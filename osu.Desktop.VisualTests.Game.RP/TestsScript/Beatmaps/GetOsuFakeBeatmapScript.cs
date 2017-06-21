using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Beatmaps;
using osu.Game.Database;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.UI;
using OpenTK;

namespace osu.Desktop.VisualTests.TestsScript.Beatmaps
{
    class GetOsuFakeBeatmapScript
    {
       
        public Beatmap GetFakeBeatmap(RulesetInfo info)
        {
            var objects = new List<Game.Rulesets.Objects.HitObject>();

            int time = 1500;
            for (int i = 0; i < 50; i++)
            {
                objects.Add(new HitCircle
                {
                    StartTime = time,
                    Position = new Vector2(i % 4 == 0 || i % 4 == 2 ? 0 : OsuPlayfield.BASE_SIZE.X,
                        i % 4 < 2 ? 0 : OsuPlayfield.BASE_SIZE.Y),
                    NewCombo = i % 4 == 0
                });

                time += 500;
            }

            Beatmap b = new Beatmap
            {
                HitObjects = objects,
                BeatmapInfo = new BeatmapInfo
                {
                    Difficulty = new BeatmapDifficulty(),
                    Ruleset = info,
                    Metadata = new BeatmapMetadata
                    {
                        Artist = @"Unknown",
                        Title = @"Sample Beatmap",
                        Author = @"peppy",
                    }
                }
            };

            return b;
        }
    }
}
