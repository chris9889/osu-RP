using osu.Framework.Input;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using static osu.Game.Modes.RP.Saving.RpKeyLayoutConfig;
using osu.Framework.Graphics.Textures;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using OpenTK;
using osu.Game.Screens.Play;

namespace osu.Game.Modes.RP.UI.GamePlay.KeyCounter
{
    /// <summary>
    /// RP專用計數器裡面的其中一個按鍵
    /// </summary>
    class RpKeyCounterKeyboard : KeyCounterKeyboard
    {
        

        SingleKeyLayout _layout;


        //顯示按鈕
        private Sprite _buttonIconSprite;
        //顯示按鍵名稱
        private SpriteText _textSprite;
        //
        SingleKey _singlekey;

        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="name"></param>
        public RpKeyCounterKeyboard(string name, SingleKey singlekey, SingleKeyLayout layout) : base(singlekey.Key)
        {
            _singlekey = singlekey;
            _layout = layout;
            IsCounting = true;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Children = new Drawable[]
           {
                buttonSprite = new Sprite
                {
                    Texture = textures.Get(@"KeyCounter/key-up"),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                },
                glowSprite = new Sprite
                {
                    Texture = textures.Get(@"KeyCounter/key-glow"),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Alpha = 0
                },
                textLayer = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        _textSprite = new SpriteText
                        {
                            Text = Name,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativePositionAxes = Axes.Both,
                            Position = new Vector2(0, -0.25f),
                            Colour = KeyUpTextColor
                        },
                        countSpriteText = new SpriteText
                        {
                            Text = Count.ToString(@"#,0"),
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativePositionAxes = Axes.Both,
                            Position = new Vector2(0, 0.25f),
                            Colour = KeyUpTextColor
                        },
                        _buttonIconSprite = new Sprite
                        {
                            Texture = textures.Get(SkinManager.RpTexturePathManager.GetKeyLayoutButtonIcon(_singlekey.Type)),
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Alpha = 1,
                            Scale=new Vector2(1.0f),
                            Position=new Vector2(0, -0.25f),
                        },
                    }
                },
            };
            //Set this manually because an element with Alpha=0 won't take it size to AutoSizeContainer,
            //so the size can be changing between buttonSprite and glowSprite.
            Height = buttonSprite.DrawHeight;
            Width = buttonSprite.DrawWidth;

            Vector2 fixPosition = new Vector2(0, -10f);
            Vector2 upperPosition = new Vector2(0, -0.25f);
            Vector2 lowerPosition = new Vector2(0, 0.25f);
            switch (_layout)
            {
                case SingleKeyLayout.KeyIcon_Code:
                    _buttonIconSprite.Position = upperPosition + fixPosition;
                    _textSprite.Position = lowerPosition;
                    countSpriteText.Alpha = 0;
                    break;
                case SingleKeyLayout.keyCount_Code:
                    _textSprite.Position = upperPosition;
                    countSpriteText.Position = lowerPosition;
                    _buttonIconSprite.Alpha = 0;
                    break;
                case SingleKeyLayout.KeyIcon_Count:
                    _buttonIconSprite.Position = upperPosition + fixPosition;
                    countSpriteText.Position = lowerPosition;
                    _textSprite.Alpha = 0;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            IsCounting = true;

            return base.OnKeyDown(state, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnKeyUp(InputState state, KeyUpEventArgs args)
        {
            return base.OnKeyUp(state, args);
        }

        public enum SingleKeyLayout
        {
            KeyIcon = 1,
            keyCode = 2,
            keyCount = 4,
            KeyIcon_Code = KeyIcon | keyCode,
            keyCount_Code = keyCode | keyCount,
            KeyIcon_Count = KeyIcon | keyCount
        }

    }
}
