using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.MovePiece.ApproachCircle;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.MovePiece.Flow;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.MovePiece
{
    internal class GetMovePiece
    {
        /// <summary>
        ///     取得片段
        /// </summary>
        /// <returns></returns>
        public BaseMovePicec GetPicec(BaseRpHitObject hitObject)
        {
            if (hitObject is RpHitObject) //Click
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseMoveApproachCircle(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new ClickMoveFlow(hitObject); //V
                }
            else if (hitObject is RpSliderObject) //Slide
                switch (hitObject.ApproachType)
                {
                    case RpBaseHitObjectType.ApproachType.ApproachCircle:
                        return new BaseMoveApproachCircle(hitObject); //V
                    case RpBaseHitObjectType.ApproachType.flow:
                        return new SliderMoveFlow(hitObject); //V
                }
            else if (false)//(hitObject is RpHold) //Hold
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
