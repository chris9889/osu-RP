﻿using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.Common
{
    /// <summary>
    ///     載入效果
    /// </summary>
    public class LoadEffect : BaseComponent
    {
        /// <summary>
        ///     外框
        /// </summary>
        private readonly ImagePicec _effectPicec;


        /// <summary>
        ///     建構
        /// </summary>
        public LoadEffect(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                _effectPicec = new ImagePicec(RpTexturePathManager.GetRPLoadEffect())
                {
                    Scale = new Vector2(1, 1),
                    Alpha = 0
                }
            };
        }

        /// <summary>
        ///     初始化顯示
        /// </summary>
        public override void Initial()
        {
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public override void FadeIn(double time = 0)
        {
            _effectPicec.FadeTo(0.9f, (float)Delay);
            _effectPicec.ScaleTo(2.5f, Delay + 100);
            _effectPicec.FadeTo(0.7f, Delay + 150);
            _effectPicec.FadeTo(0, Delay + 200);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public override void FadeOut(double time = 0)
        {
        }
    }
}
