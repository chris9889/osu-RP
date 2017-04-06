using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using osu.Game.Modes.RP.SkinManager;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.HitEffectTemplate
{
    /// <summary>
    ///     如果是Cool的打擊特效
    /// </summary>
    internal class CoolHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected new RpScoreResult RPScoreResult = RpScoreResult.Cool;

        /// <summary>
        ///     黃色光環
        /// </summary>
        private readonly ImagePicec _flarePicec;

        /// <summary>
        ///     白色圈圈
        /// </summary>
        private readonly ImagePicec _loopPicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _onpuPicec;

        public CoolHitEffectTemplate()
        {
            Children = new Drawable[]
            {
                _flarePicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RPScoreResult, "Flare"))
                {
                    Position = new Vector2(0, 0)
                },
                _loopPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RPScoreResult, "Loop"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0)
                },
                _onpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RPScoreResult, "RP"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0)
                }
            };
        }

        //開始特效
        public override void StartEffect()
        {
            //透明度
            _loopPicec.FadeTo(0.7f, 0);
            _loopPicec.FadeTo(0.7f, 250);
            _loopPicec.FadeTo(0f, 300);
            //scale
            _loopPicec.Scale = new Vector2(1.4f);
            _loopPicec.ScaleTo(3.0f, 200);
            _loopPicec.ScaleTo(3.0f, 220);

            //透明度
            _flarePicec.FadeTo(0.7f, 0);
            _flarePicec.FadeTo(0.7f, 250);
            _flarePicec.FadeTo(0f, 300);
            //scale
            _flarePicec.Scale = new Vector2(0.8f);
            _flarePicec.ScaleTo(1.6f, 50);
            _flarePicec.ScaleTo(1.6f, 150);

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
