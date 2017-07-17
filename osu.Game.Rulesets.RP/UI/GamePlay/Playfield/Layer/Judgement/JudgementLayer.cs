using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement
{
    public class JudgementLayer : BaseGamePlayLayer
    {
        public void AddHitEffect(DrawableHitObject<BaseRpObject, RpJudgement> drawableHitObject)
        {
            var explosion = new HitExplosion.HitExplosion(drawableHitObject.Judgement, drawableHitObject.HitObject);
            Add(explosion);
        }
    }
}
