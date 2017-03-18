// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Transforms;
using osu.Game.Modes.RP.Objects.Drawables;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectConnector
{
    public class FollowPoint : Container
    {
        public double StartTime;
        public double EndTime;
        public Vector2 EndPosition;

        const float width = 8;

        public FollowPoint()
        {
            Origin = Anchor.Centre;
            Alpha = 0;

            Masking = true;
            AutoSizeAxes = Axes.Both;
            CornerRadius = width / 2;
            EdgeEffect = new EdgeEffect
            {
                Type = EdgeEffectType.Glow,
                Colour = Color4.White.Opacity(0.2f),
                Radius = 4,
            };
            
            Children = new Drawable[]
            {
                new Box
                {
                    Size = new Vector2(width),
                    BlendingMode = BlendingMode.Additive,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    Alpha = 0.5f,
                },
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            Delay(StartTime);
            FadeIn(DrawableRpHitObject.TIME_FADEIN_Connector);
            ScaleTo(1.5f);
            ScaleTo(1, DrawableRpHitObject.TIME_FADEIN_Connector, EasingTypes.Out);
            MoveTo(EndPosition, DrawableRpHitObject.TIME_FADEIN_Connector, EasingTypes.Out);

            Delay(EndTime - StartTime);
            FadeOut(DrawableRpHitObject.TIME_FADEIN_Connector);

            Delay(DrawableRpHitObject.TIME_FADEIN_Connector);
            Expire(true);
        }
    }
}