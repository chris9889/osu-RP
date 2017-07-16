using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.Common;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.Common.ShapePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.MovePiece.Flow
{
    /// <summary>
    ///     ���L�G�ڕ���
    /// </summary>
    internal class BaseMoveFlow : BaseMovePicec, IComponentSliderProgress
    {
        /// <summary>
        ///     �����g铕���
        /// </summary>
        private readonly SliderBody _rpLongBody;

        /// <summary>
        ///     �J���a��������
        /// </summary>
        private readonly HitObjectAnyShapePiece hitObjectAnyShapePieceFirstObjectAny;

        /// <summary>
        /// </summary>
        private readonly HitObjectAnyShapePiece hitObjectAnyShapePieceSecondObjectAny;


        public BaseMoveFlow(BaseRpHitableObject baseHitObject)
            : base(baseHitObject)
        {
            Children = new Drawable[]
            {
                //Slider�g�
                _rpLongBody = new SliderBody(BaseHitObject)
                {
                    Position = new Vector2(0, 0),
                    PathWidth = BaseHitObject.Scale * 15
                },
                //��������
                hitObjectAnyShapePieceSecondObjectAny = new HitObjectAnyShapePiece(BaseHitObject) //true
                {
                    Position = new Vector2(0, 0),
                    //Scale = new Vector2(_hitObject.Scale),
                    IsFirst = false
                },
                //�J������
                hitObjectAnyShapePieceFirstObjectAny = new HitObjectAnyShapePiece(BaseHitObject) //false
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
            _rpLongBody.Alpha = 1;
        }

        /// <summary>
        ///     �J�n����
        /// </summary>
        public override void FadeIn(double time = 0)
        {
        }

        /// <summary>
        ///     ����
        /// </summary>
        public override void FadeOut(double time = 0)
        {
            _rpLongBody.FadeOut();
            hitObjectAnyShapePieceFirstObjectAny.FadeOut();
            hitObjectAnyShapePieceSecondObjectAny.FadeOut();
        }

        /// <summary>
        /// </summary>
        /// <param name="startProgress"></param>
        /// <param name="endProgress"></param>
        public void UpdateProgress(double startProgress = 0, double endProgress = 1)
        {
            _rpLongBody.UpdateProgress(startProgress, endProgress);
            hitObjectAnyShapePieceFirstObjectAny.Position = HitObject.Curve.PositionAt(startProgress) - HitObject.Position;
            hitObjectAnyShapePieceSecondObjectAny.Position = HitObject.Curve.PositionAt(endProgress) - HitObject.Position;
        }
    }
}
