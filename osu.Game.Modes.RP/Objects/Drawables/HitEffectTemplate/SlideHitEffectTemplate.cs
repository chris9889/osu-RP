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
    class SlideHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        /// 目前結果
        /// </summary>
        protected new RPScoreResult RPScoreResult = RPScoreResult.Slider;

        /// <summary>
        /// 白色十字
        /// </summary>
        ImagePicec _effectPicec;

        /// <summary>
        /// 有音樂形狀那個icon
        /// </summary>
        ImagePicec _onpuPicec;

        public SlideHitEffectTemplate()
        {

            Children = new Drawable[]
            {
                _effectPicec= new ImagePicec(SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult, "Slide_effect"))
                {
                    Position=new Vector2(0,0),
                },
                _onpuPicec = new ImagePicec(SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult, "RP"))
                {
                    Position=new Vector2(0,0),
                },
            };
        }

        public override void StartEffect()
        {
            //透明度
            _effectPicec.FadeTo(1.0f, 0);
            _effectPicec.FadeTo(0.8f, 200);
            _effectPicec.FadeTo(0f, 300);
            //scale
            _effectPicec.Scale = new Vector2(0.4f);
            _effectPicec.ScaleTo(2.0f, 200);
            _effectPicec.ScaleTo(2.2f, 220);

            //透明度
            _onpuPicec.FadeTo(0.7f, 0);
            _onpuPicec.FadeTo(0.7f, 250);
            _onpuPicec.FadeTo(0f, 300);
            //scale
            _onpuPicec.Scale = new Vector2(1f);
            _onpuPicec.ScaleTo(1.8f, 200);
            _onpuPicec.ScaleTo(1.8f, 220);
        }
    }
}
