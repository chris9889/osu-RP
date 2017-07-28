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
        ///     開頭和結尾物件
        /// </summary>
        private readonly HitObjectAnyShapePiece hitObjectAnyShapePieceFirstObjectAny;

        public StillHit(BaseRpHitableObject baseHitObject)
            : base(baseHitObject)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                //開頭物件
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
        ///     初始化顯示
        /// </summary>
        public override void Initial()
        {
            hitObjectAnyShapePieceFirstObjectAny.Alpha = 1;
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public override void FadeIn(double time = 0)
        {
            hitObjectAnyShapePieceFirstObjectAny.FadeIn(time);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public override void FadeOut(double time = 0)
        {
            hitObjectAnyShapePieceFirstObjectAny.FadeOut(time);
        }
    }
}
