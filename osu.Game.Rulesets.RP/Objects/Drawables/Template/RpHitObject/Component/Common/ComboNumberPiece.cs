// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common
{
    /// <summary>
    ///     顯示Combo數字
    /// </summary>
    internal class ComboNumberPiece : BaseComponent
    {
        private readonly Sprite number;

        public ComboNumberPiece()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new[]
            {
                number = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Alpha = 1
                }
            };
        }

        public void SetNumber()
        {
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            number.Texture = textures.Get(@"Play/osu/number@2x");
        }
    }
}
