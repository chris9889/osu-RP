using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.type;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.StillPiece.Click;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.StillPiece.Hold;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.StillPiece.Slide;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.StillPiece
{
    internal class GetStillPiece
    {
        /// <summary>
        ///     �擾�Вi
        /// </summary>
        /// <returns></returns>
        public BaseStillPiece GetPicec(BaseRpHitableObject hitObject)
        {
            if (hitObject is Objects.RpHitObject) //Click
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseStillClick(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new BaseStillClick(hitObject);
                }
            else if (hitObject is RpHoldObject) //Slide
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseStillSlide(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new BaseStillSlide(hitObject); //V
                }
            else if (false)// (hitObject is RpHold) //Hold
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseStillHold(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new BaseStillHold(hitObject); //V
                }

            return new BaseStillPiece(hitObject);
        }
    }
}
