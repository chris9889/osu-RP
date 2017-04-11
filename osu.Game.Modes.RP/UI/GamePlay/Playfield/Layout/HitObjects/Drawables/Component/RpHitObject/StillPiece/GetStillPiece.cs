using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.StillPiece.Click;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.StillPiece.Hold;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.StillPiece.Slide;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.StillPiece
{
    internal class GetStillPiece
    {
        /// <summary>
        ///     取得片段
        /// </summary>
        /// <returns></returns>
        public BaseStillPiece GetPicec(BaseRpHitObject hitObject)
        {
            if (hitObject is RpHitObject) //Click
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseStillClick(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new BaseStillClick(hitObject);
                }
            else if (hitObject is RpSliderObject) //Slide
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
