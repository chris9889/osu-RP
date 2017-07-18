using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.Common.ShapePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.StillPiece.Click
{
    internal class BaseStillClick : BaseStillPiece
    {
        /// <summary>
        ///     �J���a��������
        /// </summary>
        private readonly HitObjectAnyShapePiece hitObjectAnyShapePieceFirstObjectAny;

        public BaseStillClick(BaseRpHitableObject baseHitObject)
            : base(baseHitObject)
        {
            Children = new Drawable[]
            {
                //�J������
                hitObjectAnyShapePieceFirstObjectAny = new HitObjectAnyShapePiece(baseHitObject) //false
                {
                    Position = new Vector2(0, 0),
                    //Scale = new Vector2(_hitObject.Scale),
                    IsFirst = true
                }
            };
        }

        /// <summary>
        ///     ���n������
        /// </summary>
        public override void Initial()
        {
            hitObjectAnyShapePieceFirstObjectAny.Alpha = 1;
        }

        /// <summary>
        ///     �J�n����
        /// </summary>
        public override void FadeIn(double time = 0)
        {
            hitObjectAnyShapePieceFirstObjectAny.FadeIn(time);
        }

        /// <summary>
        ///     ����
        /// </summary>
        public override void FadeOut(double time = 0)
        {
            hitObjectAnyShapePieceFirstObjectAny.FadeOut(time);
        }
    }
}
