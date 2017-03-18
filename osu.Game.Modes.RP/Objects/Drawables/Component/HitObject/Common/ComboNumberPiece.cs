//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common
{
    /// <summary>
    /// 顯示Combo數字
    /// </summary>
    class ComboNumberPiece : BaseComponent
    {
        private Sprite number;

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

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            number.Texture = textures.Get(@"Play/osu/number@2x");
        }

        public void SetNumber()
        {

        }
    }
}