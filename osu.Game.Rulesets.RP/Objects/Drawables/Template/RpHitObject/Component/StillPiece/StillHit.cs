// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common.ShapePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.StillPiece
{
    internal class StillHit : BaseStillPiece
    {
        /// <summary>
        ///     �J���a��������
        /// </summary>
        private readonly HitObjectAnyShapePiece hitObjectAnyShapePieceFirstObjectAny;

        public StillHit(BaseRpHitableObject baseHitObject)
            : base(baseHitObject)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                //�J������
                hitObjectAnyShapePieceFirstObjectAny = new HitObjectAnyShapePiece(baseHitObject) //false
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,

                    Position = new Vector2(0, 0),
                    //Scale = new Vector2(HitObject.Scale),
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
