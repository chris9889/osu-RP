// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Transforms;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectConnector
{
    /// <summary>
    /// DrawConnectionLine
    /// </summary>
    public class RpHitMulitpleObjectConnectionLine : Container
    {
        private float TIME_FADEIN = 200;

        public double StartTime;
        public double EndTime;

        private List<Vector2> _listVertex=new List<Vector2>();

        private Slider slider = new Slider();

        public RpHitMulitpleObjectConnectionLine()
        {
            this.Children = new Drawable[]
            {
                slider,
            };
        }

        public void SetListLine(List<Vector2> listVertex)
        {
            _listVertex = listVertex;
            slider.SetRange(_listVertex);
            slider.PathWidth = 3;
        }


        protected override void LoadComplete()
        {
            base.LoadComplete();

            Delay(StartTime);
            FadeIn(TIME_FADEIN);
            //ScaleTo(1.5f);
            //ScaleTo(1,TIME_FADEIN, EasingTypes.Out);
            //MoveTo(EndPosition, DrawableOsuHitObject.TIME_FADEIN, EasingTypes.Out);
            Delay(EndTime - StartTime);
            FadeOut(TIME_FADEIN);

            Delay(TIME_FADEIN);
            Expire(true);
        }
    }
}