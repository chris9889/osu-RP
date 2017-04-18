using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.type;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.MovePiece.ApproachCircle;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.MovePiece.Flow;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.MovePiece
{
    internal class GetMovePiece
    {
        /// <summary>
        ///     取得片段
        /// </summary>
        /// <returns></returns>
        public BaseMovePicec GetPicec(BaseRpHitObject hitObject)
        {
            if (hitObject is Objects.RpHitObject) //Click
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
