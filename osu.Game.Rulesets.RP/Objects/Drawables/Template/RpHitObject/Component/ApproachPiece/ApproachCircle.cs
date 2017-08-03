// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component.Common;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece
{
    /// <summary>
    /// </summary>
    internal class ApproachCircle : BaseMovePicec, IComponentUpdateEachFrame
    {
        /// <summary>
        ///     ëúosu! approach circle ìﬂûÈ
        /// </summary>
        public ImagePicec ApproachHitPicec;


        public ApproachCircle(BaseRpHitableObject baseHitObject)
            : base(baseHitObject)
        {

            Children = new Drawable[]
            {
                ApproachHitPicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(BaseHitObject))
                {
                },
            };
        }

        /// <summary>
        ///     èâénâªË˚é¶
        /// </summary>
        public override void Initial()
        {
            ApproachHitPicec.Alpha = 0;
            ApproachHitPicec.Scale = new Vector2(3);
        }

        /// <summary>
        ///     äJénì¡ù¡
        /// </summary>
        public override void FadeIn(double time = 0)
        {
            ApproachHitPicec.Delay(BaseHitObject.PreemptTime / 5 * 4);
            ApproachHitPicec.FadeTo(1, BaseHitObject.PreemptTime / 5 * 4);
            //ApproachHitPicec.FadeIn(Math.Min(BaseHitObject.FadeInTime * 2, BaseHitObject.PreemptTime));
            ApproachHitPicec.ScaleTo(0.5f, BaseHitObject.PreemptTime / 5 * 1);
        }

        /// <summary>
        ///     åãë©
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
