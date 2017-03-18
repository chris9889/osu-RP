using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Modes.RP.SkinManager;
using OpenTK;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Front.DecisionLine
{
    class DecisionLine : Container
    {
        private Sprite disc;


        public DecisionLine()
        {
            Size = new Vector2(70);
            //Masking = true;
            CornerRadius = DrawSize.X / 2;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                disc = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale=new Vector2(0.5f,0.3f),
                },
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            string name = RPSkinManager.GetDecisionLineTexture();
            disc.Texture = textures.Get(name);
        }
    }
}
