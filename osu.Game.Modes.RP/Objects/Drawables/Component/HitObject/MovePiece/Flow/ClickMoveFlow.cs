// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Component.Common;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common.ShapePiece;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.MovePiece.Flow
{
    internal class ClickMoveFlow : BaseMoveFlow, ISliderProgress
    {
        /// <summary>
        ///     開頭和結尾物件
        /// </summary>
        private readonly HitObjectAnyShapePiece hitObjectAnyShapePieceFirstObjectAny;

        public ClickMoveFlow(BaseHitObject baseHitObject)
            : base(baseHitObject)
        {
            Children = new Drawable[]
            {
                //開頭物件
                hitObjectAnyShapePieceFirstObjectAny = new HitObjectAnyShapePiece(BaseHitObject) //false
                {
                    Position = new Vector2(0, 0),
                    //Scale = new Vector2(_hitObject.Scale),
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
