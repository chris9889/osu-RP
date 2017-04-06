//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Component.CommonInterface;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common
{
    /// <summary>
    ///     繪製拉感
    /// </summary>
    internal class SliderBody : BaseComponent, IComponentSliderProgress
    {
        public float PathWidth
        {
            get { return slider.PathWidth; }
            set { slider.PathWidth = value; }
        }

        private readonly Slider slider;

        private readonly BaseHitObject sliderHitObject;

        public SliderBody(BaseHitObject s)
        {
            sliderHitObject = s;

            slider = new Slider();
            //修正顯示座標
            //slider.Position = -path.PositionInBoundingBox(sliderHitObject.Curve.PositionAt(0) - sliderHitObject[0]);
            slider.Position = -sliderHitObject.Curve.PositionAt(0);
            Children = new Drawable[]
            {
                slider
            };
        }

        /// <summary>
        ///     從這邊去更新顯示範圍
        /// </summary>
        /// <param name="progress">0~1</param>
        /// <param name="repeat">這裡預設是0</param>
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
