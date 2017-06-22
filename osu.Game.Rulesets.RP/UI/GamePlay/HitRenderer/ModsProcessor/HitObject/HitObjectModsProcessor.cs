using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;

namespace osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer.ModsProcessor.HitObject
{
    public class HitObjectModsProcessor
    {
        private List<Mod> listMods;

        public HitObjectModsProcessor(List<Mod> listMods)
        {
            this.listMods = listMods;
        }

        internal void ProcessHitObject(DrawableHitObject<BaseRpObject, RpJudgement> returnObject)
        {

        }
    }
}
