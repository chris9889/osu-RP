using System.Collections.Generic;
using osu.Game.Modes.Objects.Drawables;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables
{
    public class RPJudgementInfo : PositionalJudgementInfo
    {
        public RPScoreResult Score;
        public RPComboResult Combo;
        public List<Vector2> HitExplosionPosition=new List<Vector2>();
    }
}