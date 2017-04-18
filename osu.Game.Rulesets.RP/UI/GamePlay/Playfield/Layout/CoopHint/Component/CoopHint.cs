using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.type;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CoopHint.Component
{
    internal class CoopHint : Container
    {
        private readonly RpBaseHitObjectType.Coop _coop;

        private readonly RectanglePiece _rectangle;

        public CoopHint(RpBaseHitObjectType.Coop coop)
        {
            _coop = coop;
            _rectangle = new RectanglePiece(500, 1000)
            {
                Colour = RpTextureColorManager.GetCoopLayoutColor(_coop),
                Alpha = 0.5f
            };

            Children = new Drawable[]
            {
                _rectangle
            };
        }
    }
}
