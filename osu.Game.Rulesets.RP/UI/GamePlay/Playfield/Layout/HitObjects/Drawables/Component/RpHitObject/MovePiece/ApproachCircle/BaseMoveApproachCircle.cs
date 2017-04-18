// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.MovePiece.ApproachCircle
{
    /// <summary>
    /// </summary>
    internal class BaseMoveApproachCircle : BaseMovePicec, IComponentSliderProgress
    {
        /// <summary>
        ///     像osu! approach circle 那樣
        /// </summary>
        public ImagePicec ApproachHitPicec;


        public BaseMoveApproachCircle(BaseRpHitObject baseHitObject)
            : base(baseHitObject)
        {
            Children = new Drawable[]
            {
                ApproachHitPicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(BaseHitObject))
            };
        }

        /// <summary>
        ///     初始化顯示
        /// </summary>
        public override void Initial()
        {
            ApproachHitPicec.Alpha = 0;
            ApproachHitPicec.Scale = new Vector2(3);
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public override void FadeIn(double time = 0)
        {
            ApproachHitPicec.Delay(BaseHitObject.TIME_PREEMPT / 5 * 4);
            ApproachHitPicec.FadeTo(1, BaseHitObject.TIME_PREEMPT / 5 * 4);
            //ApproachHitPicec.FadeIn(Math.Min(BaseHitObject.TIME_FADEIN * 2, BaseHitObject.TIME_PREEMPT));
            ApproachHitPicec.ScaleTo(0.5f, BaseHitObject.TIME_PREEMPT / 5 * 1);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public override void FadeOut(double time = 0)
        {
            ApproachHitPicec.FadeOut(time);
        }

        public void UpdateProgress(double startProgress = 0, double endProgress = 1)
        {
            //throw new NotImplementedException();
        }
    }
}
