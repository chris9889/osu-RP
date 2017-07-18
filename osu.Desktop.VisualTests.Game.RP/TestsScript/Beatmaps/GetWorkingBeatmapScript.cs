using System.Collections.Generic;
using System.Linq;
using osu.Desktop.VisualTests.Beatmaps;
using osu.Game.Beatmaps;
using osu.Game.Database;
using osu.Game.Rulesets.Mods;


namespace osu.Desktop.VisualTests.TestsScript.Beatmaps
{
    /// <summary>
    /// Get osu or RP beatmap script.
    /// </summary>
    public class GetWorkingBeatmapScript
    {
        private BeatmapDatabase db;
        private RulesetDatabase rulesets;

        public GetWorkingBeatmapScript(BeatmapDatabase db, RulesetDatabase rulesets)
        {
            this.db = db;
            this.rulesets = rulesets;
        }

        //get single osu beatmap
        public WorkingBeatmap GetWorkingBeatmap(int rulesetID=0,bool useFake=false, int beatmapIndex = 0, List<Mod> listMops = null)
        {
            WorkingBeatmap beatmap = null;

            var beatmapInfo = db.Query<BeatmapInfo>().FirstOrDefault(b => b.RulesetID == rulesetID);
            if (beatmapInfo != null)
                beatmap = db.GetWorkingBeatmap(beatmapInfo);

            //if cannot find any beatmap ,or use fake beatmap just create one
            if (beatmap?.Track == null || useFake)
            {
                beatmap = new RpTestWorkingBeatmap(getFakeBeatmapByRulesetId(rulesetID));
            }

            //adding Mods
            if(listMops!=null)
                beatmap.Mods.Value = listMops?.ToArray();

            return beatmap;
        }

        /// <summary>
        /// get faake beatmap
        /// </summary>
        /// <param name="rulesetId"></param>
        /// <returns></returns>
        private Beatmap getFakeBeatmapByRulesetId(int rulesetId)
        {
            switch (rulesetId)
            {
                case 0:
                        GetOsuFakeBeatmapScript getOsuFakeBeatmapScript=new GetOsuFakeBeatmapScript();
                        return getOsuFakeBeatmapScript.GetFakeBeatmap(rulesets.Query<RulesetInfo>().FirstOrDefault());
                    break;

                case 1111:
                    GetRpFakeBeatmapScript getRpFakeBeatmapScript = new GetRpFakeBeatmapScript();
                    return getRpFakeBeatmapScript.GetFakeBeatmap(rulesets.Query<RulesetInfo>().FirstOrDefault(info => info.ID==5));
                    break;
            }

            GetOsuFakeBeatmapScript getDefaultFakeBeatmapScript = new GetOsuFakeBeatmapScript();
            return getDefaultFakeBeatmapScript.GetFakeBeatmap(rulesets.Query<RulesetInfo>().FirstOrDefault());
        }
    }
   
}
