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
    /// 顯示棒狀用的物件
    /// 有 上 中 下 三塊
    /// 使用方式是設定解析度(長 寬)
    /// 
    /// </summary>
    class BarPiece : Container
    {
        public float Width=100f;
        public float Height=100f;

        //中間物件
        public string Resource;
        private Sprite _middleSpirit;

        //上面物件
        public string UpResource;
        private Sprite _upSpirit;

        //下面物件
        public string DownResource;
        private Sprite _downSpirit;

        /// <summary>
        /// 設定初始的長，寬
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public BarPiece(float width, float height)
        {
            //設定目前寬度
            Width = width;
            Height = height;

            Size = new Vector2(144);
            //Masking = true;
            CornerRadius = DrawSize.X / 2;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            //Child物件
            Children = new Drawable[]
            {
                //中間物件位置
                _middleSpirit = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale=new Vector2(2),
                    Position=new Vector2(0,0),
                },
                //下面
                 _downSpirit = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale=new Vector2(2),
                    Position=new Vector2(0,Height/2),
                },
                //上面
                _upSpirit = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale=new Vector2(2),
                    Position=new Vector2(0,-Height/2),
                },
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            _upSpirit.Texture = textures.Get(UpResource);
            _downSpirit.Texture = textures.Get(DownResource);
            _middleSpirit.Texture = textures.Get(Resource);
        }
    }
}
