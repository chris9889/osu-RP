﻿using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate
{
    internal class FineHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected new RpScoreResult RPScoreResult = RpScoreResult.Fine;

        /// <summary>
        ///     白色十字
        /// </summary>
        private readonly ImagePicec _crossPicec;

        /// <summary>
        ///     白色十字
        /// </summary>
        private readonly ImagePicec _effectPicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _onpuPicec;

        public FineHitEffectTemplate()
        {
            Children = new Drawable[]
            {
                _crossPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RPScoreResult, "Down"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0),
                    Scale = new Vector2(1, 1)
                },
                _effectPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RPScoreResult, "Slide_effect"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0),
                    Scale = new Vector2(1, 1)
                },
                _onpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RPScoreResult, "RP"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0),
                    Scale = new Vector2(1, 1)
                }
            };
        }

        public override void StartEffect()
        {
            //透明度
            _crossPicec.FadeTo(0.7f, 0);
            _crossPicec.FadeTo(0.7f, 250);
            _crossPicec.FadeTo(0f, 300);
            //scale
            _crossPicec.Scale = new Vector2(0.8f);
            _crossPicec.ScaleTo(1.6f, 200);
            _crossPicec.ScaleTo(1.6f, 220);

            _crossPicec.RotateTo(-30, 220);

            //透明度
            _effectPicec.FadeTo(0.7f, 0);
            _effectPicec.FadeTo(0.7f, 250);
            _effectPicec.FadeTo(0f, 300);
            //scale
            _effectPicec.Scale = new Vector2(0.8f);
            _effectPicec.ScaleTo(2f, 50);
            _effectPicec.ScaleTo(2f, 150);

            //透明度
            _onpuPicec.FadeTo(0.8f, 0);
            _onpuPicec.FadeTo(0.8f, 350);
            _onpuPicec.FadeTo(0f, 400);
            //scale
            _onpuPicec.Scale = new Vector2(1f);
            _onpuPicec.ScaleTo(1.8f, 200);
            _onpuPicec.ScaleTo(1.8f, 220);
        }
    }
}
