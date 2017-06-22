using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer.ModsProcessor.GameField
{
    public class GameFieldModsProcessor
    {
        private List<Mod> listMods;

        public GameFieldModsProcessor(List<Mod> listMods)
        {
            this.listMods = listMods;
        }

        internal void ProcessGameField(Playfield<BaseRpObject, RpJudgement> playfield)
        {

        }
    }
}
