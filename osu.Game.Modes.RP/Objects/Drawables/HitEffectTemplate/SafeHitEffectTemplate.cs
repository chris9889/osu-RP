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
    class SafeHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        /// 目前結果
        /// </summary>
        protected new RPScoreResult RPScoreResult = RPScoreResult.Safe;

        /// <summary>
        /// 有音樂形狀那個icon
        /// </summary>
        ImagePicec _noonpuPicec;

        public SafeHitEffectTemplate()
        {
            Children = new Drawable[]
            {
                 _noonpuPicec = new ImagePicec(SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult,"RP"))
                {
                    //Colour = osuObject.Colour,
                    Scale=new Vector2(1,1),
                    Position=new Vector2(0,0),
                },
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
