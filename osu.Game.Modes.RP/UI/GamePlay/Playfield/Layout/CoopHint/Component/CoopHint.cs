

using System.Drawing;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using osu.Game.Modes.RP.Objects.type;
using osu.Game.Modes.RP.SkinManager;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.CoopHint.Component
{
    class CoopHint : Container
    {
        private RpBaseHitObjectType.Coop _coop;

        private RectanglePiece _rectangle;

        public CoopHint(RpBaseHitObjectType.Coop coop)
        {
            _coop = coop;
            _rectangle = new RectanglePiece(500, 1000)
            {
                Colour = RpTextureColorManager.GetCoopLayoutColor(_coop),
                Alpha = 0.5f,
            };

            Children = new Drawable[]
            {
                _rectangle,
            };
        }
    }
}
