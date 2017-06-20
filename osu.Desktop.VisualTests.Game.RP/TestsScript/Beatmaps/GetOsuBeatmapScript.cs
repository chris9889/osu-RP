using System.Collections.Generic;
using System.Linq;
using osu.Desktop.VisualTests.Beatmaps;
using osu.Game.Beatmaps;
using osu.Game.Database;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.UI;
using OpenTK;

namespace osu.Desktop.VisualTests.TestsScript.Beatmaps
{
    /// <summary>
    /// Get osu beatmap script.
    /// </summary>
    public class GetOsuBeatmapScript
    {
        private BeatmapDatabase db;
        private RulesetDatabase rulesets;

        public GetOsuBeatmapScript(BeatmapDatabase db, RulesetDatabase rulesets)
        {
            this.db = db;
            this.rulesets = rulesets;
        }

        //get single osu beatmap
        public WorkingBeatmap GetOsuBeatmap()
        {
            WorkingBeatmap beatmap = null;

            var beatmapInfo = db.Query<BeatmapInfo>().FirstOrDefault(b => b.RulesetID == 0);
            if (beatmapInfo != null)
                beatmap = db.GetWorkingBeatmap(beatmapInfo);

            //if cannot find any beatmap,just create one
            if (beatmap?.Track == null)
            {
                var objects = new List<HitObject>();

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
                        Ruleset = rulesets.Query<RulesetInfo>().First(),
                        Metadata = new BeatmapMetadata
                        {
                            Artist = @"Unknown",
                            Title = @"Sample Beatmap",
                            Author = @"peppy",
                        }
                    }
                };

                beatmap = new RpTestWorkingBeatmap(b);
            }

            return beatmap;
        }
    }
   
}
