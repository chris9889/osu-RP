// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectConnector
{
    /// <summary>
    ///     DrawConnectionLine
    /// </summary>
    public class RpHitMulitpleObjectConnectionLine : Container
    {
        public double StartTime;
        public double EndTime;
        private readonly float TIME_FADEIN = 200;

        private readonly List<Vector2> _listVertex = new List<Vector2>();

        private readonly Slider slider;

        public RpHitMulitpleObjectConnectionLine()
        {
            slider = new Slider
            {
                Colour = new Color4(10, 10, 10, 255),
                PathWidth = 4f,
                Scale = new Vector2(0.5f)
            };

            Children = new Drawable[]
            {
                slider
            };
        }

        public void SetListLine(List<Vector2> listVertex)
        {
            _listVertex.Clear();
            for (var i = 0; i < listVertex.Count; i++)
                _listVertex.Add(listVertex[i] * 2);
            slider.SetRange(_listVertex);
            _listVertex.Sort((x, y) => x.X.CompareTo(y.X));
            _listVertex.Sort((x, y) => x.Y.CompareTo(y.Y));
            slider.Position = _listVertex[0] / 2;
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
