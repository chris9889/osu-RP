//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Lines;
using osu.Framework.Graphics.OpenGL.Textures;
using osu.Framework.Graphics.Textures;
using osu.Game.Configuration;
using osu.Game.Modes.RP.Objects.Drawables.Component.Common;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using OpenTK;
using OpenTK.Graphics.ES30;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common
{
    /// <summary>
    /// 繪製拉感
    /// </summary>
    class SliderBody : BaseComponent, ISliderProgress
    {
        private Slider slider;

        private BaseHitObject sliderHitObject;

        public float PathWidth
        {
            get { return slider.PathWidth; }
            set { slider.PathWidth = value; }
        }

        public SliderBody(BaseHitObject s)
        {
            sliderHitObject = s;

            slider = new Slider();
            //修正顯示座標
            //slider.Position = -path.PositionInBoundingBox(sliderHitObject.Curve.PositionAt(0) - sliderHitObject[0]);
            slider.Position = -(sliderHitObject.Curve.PositionAt(0));
            Children = new Drawable[]
            {
                slider,
            };

        }

        /// <summary>
        /// 從這邊去更新顯示範圍
        /// </summary>
        /// <param name="progress">0~1</param>
        /// <param name="repeat">這裡預設是0</param>
        public void UpdateProgress(double progress, double endProgress = 1)
        {
            double start = progress;
            double end = endProgress;
            List<Vector2> currentCurve = new List<Vector2>();
            if (start > end)
                MathHelper.Swap(ref start, ref end);
            sliderHitObject.Curve.GetPathToProgress(currentCurve, start, end);
            slider.SetRange(currentCurve);
        }
    }
}