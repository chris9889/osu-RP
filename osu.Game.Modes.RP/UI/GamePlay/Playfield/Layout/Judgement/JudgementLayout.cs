using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.ScoreProcessor;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Judgement
{
    class JudgementLayout : BaseGamePlayLayout
    {
        public void AddHitEffect(DrawableHitObject<BaseRpObject, RpJudgement> drawableHitObject)
        {
            var explosion = new HitExplosion.HitExplosion(drawableHitObject.Judgement, drawableHitObject.HitObject);
            this.Add(explosion);
        }
    }
}
