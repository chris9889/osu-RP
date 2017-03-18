//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input;
using OpenTK;
using osu.Game.Modes.RP.Objects.type;
using osu.Game.Modes.RP.SkinManager;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;

namespace osu.Game.Modes.RP.Objects.Drawables.Pieces
{
    /// <summary>
    /// 負責用來載入圖片元素的
    /// </summary>
    class ImagePicec : Container
    {
        private string _resource;
        public Sprite disc;

        public ImagePicec(String resource)
        {
            _resource = resource;
            Size = new Vector2(100);

            //Masking = true;
            //CornerRadius = DrawSize.X / 2; //在mask的時候會變成圓形或是增加圓形角用

            //RelativeSizeAxes = Axes.Both; //物件會顯示不出來
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                disc = new Sprite
                {
                    
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Fit,

                    Scale=new Vector2(1),
                },
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            disc.Texture = textures.Get(_resource);
        }
    }
}
