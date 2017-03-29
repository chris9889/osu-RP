using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.MovePiece.ApproachCircle;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.MovePiece.Flow;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.MovePiece
{
    internal class GetMovePiece
    {
        /// <summary>
        ///     取得片段
        /// </summary>
        /// <returns></returns>
        public BaseMovePicec GetPicec(BaseHitObject hitObject)
        {
            if (hitObject is RpHitObject) //Click
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseMoveApproachCircle(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new ClickMoveFlow(hitObject); //V
                }
            else if (hitObject is RpLongTailObject) //Slide
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseMoveApproachCircle(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new SliderMoveFlow(hitObject); //V
                }
            else if (hitObject is RpHold) //Hold
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseMoveApproachCircle(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new ClickMoveFlow(hitObject); //V
                }

            return new BaseMovePicec(hitObject);
        }
    }
}
