﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.Select.Detail
{
    internal class RpBeatmapDetailsBar : Container
    {
        public float Length
        {
            get { return length; }
            set
            {
                length = MathHelper.Clamp(value, 0, 1);
                updateBarLength();
            }
        }

        public SRGBColour BackgroundColour
        {
            get { return background.Colour; }
            set { background.Colour = value; }
        }

        public SRGBColour BarColour
        {
            get { return bar.Colour; }
            set { bar.Colour = value; }
        }

        public BarDirection Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                updateBarLength();
            }
        }

        private readonly Box background;
        private readonly Box bar;

        private const int resize_duration = 250;

        private const Easing easing = Easing.InOutCubic;

        private float length;

        private BarDirection direction = BarDirection.LeftToRight;

        public RpBeatmapDetailsBar()
        {
            Children = new[]
            {
                background = new Box
                {
                    RelativeSizeAxes = Axes.Both
                },
                bar = new Box
                {
                    RelativeSizeAxes = Axes.Both
                }
            };
        }

        private void updateBarLength()
        {
            switch (direction)
            {
                case BarDirection.LeftToRight:
                case BarDirection.RightToLeft:
                    bar.ResizeTo(new Vector2(length, 1), resize_duration, easing);
                    break;
                case BarDirection.TopToBottom:
                case BarDirection.BottomToTop:
                    bar.ResizeTo(new Vector2(1, length), resize_duration, easing);
                    break;
            }

            switch (direction)
            {
                case BarDirection.LeftToRight:
                case BarDirection.TopToBottom:
                    bar.Anchor = Anchor.TopLeft;
                    bar.Origin = Anchor.TopLeft;
                    break;
                case BarDirection.RightToLeft:
                case BarDirection.BottomToTop:
                    bar.Anchor = Anchor.BottomRight;
                    bar.Origin = Anchor.BottomRight;
                    break;
            }
        }
    }

    public enum BarDirection
    {
        LeftToRight,
        RightToLeft,
        TopToBottom,
        BottomToTop
    }
}
