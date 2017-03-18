//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace osu.Game.Modes.RP.Objects.Drawables.Pieces
{
    /// <summary>
    /// 中間那個環
    /// </summary>
    public class RingPiece : Container
    {
        private RpHitObject _rpObject;
        private Sprite ring;

        public RingPiece(RpHitObject rpObject)
        {

            _rpObject = rpObject;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                ring = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            ring.Texture = textures.Get(@"Play/osu/ring@2x");
        }
    }
}