using osu.Framework.Graphics;
using osu.Game.Modes.RP.SkinManager;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.HitEffectTemplate
{
    internal class SafeHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected new RpScoreResult RPScoreResult = RpScoreResult.Safe;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _noonpuPicec;

        public SafeHitEffectTemplate()
        {
            Children = new Drawable[]
            {
                _noonpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RPScoreResult, "RP"))
                {
                    //Colour = osuObject.Colour,
                    Scale = new Vector2(1, 1),
                    Position = new Vector2(0, 0)
                }
            };
        }

        public override void StartEffect()
        {
            //透明度
            _noonpuPicec.FadeTo(0.8f, 0);
            _noonpuPicec.FadeTo(0.8f, 350);
            _noonpuPicec.FadeTo(0f, 400);
            //scale
            _noonpuPicec.Scale = new Vector2(0.5f);
            _noonpuPicec.ScaleTo(0.8f, 200);
            _noonpuPicec.ScaleTo(0.8f, 220);
        }
    }
}
