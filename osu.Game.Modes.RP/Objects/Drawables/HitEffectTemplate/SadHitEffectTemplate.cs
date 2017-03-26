using OpenTK;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Modes.RP.Objects.Drawables.HitEffectTemplate
{
    class SadHitEffectTemplate :BaseHitEffectTemplate
    {
        /// <summary>
        /// 目前結果
        /// </summary>
        protected new RPScoreResult RPScoreResult = RPScoreResult.Sad;


        /// <summary>
        /// 特效
        /// </summary>
        ImagePicec _diffusePicec;

        /// <summary>
        /// 有音樂形狀那個icon
        /// </summary>
        ImagePicec _noonpuPicec;

        public SadHitEffectTemplate()
        {
            //string diffusePicecPath = SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult, "Diffuse");


            Children = new Drawable[]
            {
                _diffusePicec = new ImagePicec(SkinManager.RpTexturePathManager.GetRPHitEffect(RPScoreResult, "Diffuse"))
                {
                    Position=new Vector2(0,0),
                },
                _noonpuPicec = new ImagePicec(SkinManager.RpTexturePathManager.GetRPHitEffect(RPScoreResult, "RP"))
                {
                    Position=new Vector2(0,0),
                },
            };
        }

        public override void StartEffect()
        {

            //透明度
            _diffusePicec.FadeTo(0.7f, 0);
            _diffusePicec.FadeTo(0.7f, 250);
            _diffusePicec.FadeTo(0f, 300);
            //scale
            _diffusePicec.Scale = new Vector2(0.8f);
            _diffusePicec.ScaleTo(2f, 50);
            _diffusePicec.ScaleTo(2f, 150);

            //透明度
            _noonpuPicec.FadeTo(0.8f, 0);
            _noonpuPicec.FadeTo(0.8f, 350);
            _noonpuPicec.FadeTo(0f, 400);
            //scale
            _noonpuPicec.Scale = new Vector2(1f);
            _noonpuPicec.ScaleTo(1.8f, 200);
            _noonpuPicec.ScaleTo(1.8f, 220);

        }
    }
}
