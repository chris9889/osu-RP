//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.Common
{
    /// <summary>
    ///     ㉐��f��
    /// </summary>
    internal class SliderBody : BaseComponent, IComponentSliderProgress
    {
        public float PathWidth
        {
            get { return slider.PathWidth; }
            set { slider.PathWidth = value; }
        }

        private readonly Slider slider;

        private readonly BaseRpHitableObject sliderHitObject;

        public SliderBody(BaseRpHitableObject s)
        {
            sliderHitObject = s;

            slider = new Slider();
            //�C���������W
            //slider.Position = -path.PositionInBoundingBox(sliderHitObject.Curve.PositionAt(0) - sliderHitObject[0]);
            slider.Position = -sliderHitObject.Curve.PositionAt(0);
            Children = new Drawable[]
            {
                slider
            };
        }

        /// <summary>
        ///     �n��粋��X�V�����͚�
        /// </summary>
        /// <param name="progress">0~1</param>
        /// <param name="repeat">�����a�ݐ�0</param>
        public void UpdateProgress(double progress, double endProgress = 1)
        {
            var start = progress;
            var end = endProgress;
            var currentCurve = new List<Vector2>();
            if (start > end)
                MathHelper.Swap(ref start, ref end);
            sliderHitObject.Curve.GetPathToProgress(currentCurve, start, end);
            slider.SetRange(currentCurve);
        }
    }
}
