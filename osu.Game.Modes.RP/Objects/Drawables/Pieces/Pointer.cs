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
using osu.Game.Modes.RP.SkinManager;

namespace osu.Game.Modes.RP.Objects.Drawables.Pieces
{
    /// <summary>
    /// RP指針
    /// </summary>
    public class Pointer : Container
    {
        public readonly float TIME_FADEIN = 100;
        public readonly float TIME_PREEMPT = 2000;
        public readonly float TIME_FADEOUT = 100;

        BaseRpObject _baseRPObject;


        private Sprite approachCircle;

        public Pointer(BaseRpObject baseRPObject)
        {
            _baseRPObject = baseRPObject;

            TIME_FADEIN = _baseRPObject.TIME_FADEIN;
            TIME_PREEMPT = _baseRPObject.TIME_PREEMPT;
            TIME_FADEOUT = _baseRPObject.TIME_FADEOUT;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            AutoSizeAxes = Axes.Both;

            Children = new Drawable[]
            {
                approachCircle = new Sprite()
            };
        }

        /// <summary>
        /// 載入物件
        /// </summary>
        /// <param name="textures"></param>
        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            string textureName = RpTexturePathManager.RPPointer;
            approachCircle.Texture = textures.Get(textureName);
        }

        /// <summary>
        /// 初始化顯示
        /// </summary>
        public void Initial()
        {
            this.Alpha = 1;
            //this.Scale = new Vector2(1);
        }

        /// <summary>
        /// 開始特效
        /// </summary>
        public void StartEffect()
        {
            this.FadeIn(Math.Min(TIME_FADEIN * 2, TIME_PREEMPT));
            //轉一圈
            this.RotateTo(360.0f, TIME_PREEMPT);
        }

        /// <summary>
        /// 結束
        /// </summary>
        public void FadeOut()
        {
            base.FadeOut();
        }
    }
}