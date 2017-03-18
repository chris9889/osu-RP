using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.StillPiece.Click;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.StillPiece.Hold;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.StillPiece.Slide;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.StillPiece
{
    class GetStillPiece
    {
        /// <summary>
        /// 取得片段
        /// </summary>
        /// <returns></returns>
        public BaseStillPiece GetPicec(BaseHitObject hitObject)
        {

            if (hitObject is RpHitObject)//Click
            {
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseStillClick(hitObject);//V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new BaseStillClick(hitObject);
                }
            }
            else if (hitObject is RpLongTailObject)//Slide
            {
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseStillSlide(hitObject);//V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new BaseStillSlide(hitObject);//V
                }
            }
            else if (hitObject is RpHold)//Hold
            {
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseStillHold(hitObject);//V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new BaseStillHold(hitObject);//V
                }
            }

            return new BaseStillPiece(hitObject);
        }
    }
}
