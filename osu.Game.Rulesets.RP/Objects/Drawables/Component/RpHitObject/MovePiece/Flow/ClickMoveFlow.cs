// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.Common.ShapePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.MovePiece.Flow
{
    internal class ClickMoveFlow : BaseMoveFlow, IComponentSliderProgress
    {
        /// <summary>
        ///     �J���a��������
        /// </summary>
        private readonly HitObjectAnyShapePiece hitObjectAnyShapePieceFirstObjectAny;

        public ClickMoveFlow(BaseRpHitableObject baseHitObject)
            : base(baseHitObject)
        {
            Children = new Drawable[]
            {
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


        /// <summary>
        /// </summary>
        /// <param name="startProgress"></param>
        /// <param name="endProgress"></param>
        public new void UpdateProgress(double startProgress = 0, double endProgress = 1)
        {
            hitObjectAnyShapePieceFirstObjectAny.Position = BaseHitObject.Curve.PositionAt(startProgress) - BaseHitObject.Position;
        }
    }
}
