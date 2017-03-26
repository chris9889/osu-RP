using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using osu.Game.Modes.RP.SkinManager;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common
{
    /// <summary>
    /// 載入效果
    /// </summary>
    class LoadEffect : BaseComponent
    {
        
        /// <summary>
        /// 外框
        /// </summary>
        private ImagePicec _effectPicec;


        /// <summary>
        /// 建構
        /// </summary>
        public LoadEffect(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                _effectPicec=new ImagePicec(RpTexturePathManager.GetRPLoadEffect())
                {
                    Scale=new Vector2(1,1),
                    Alpha=0,
                },
            };
        }

        /// <summary>
        /// 初始化顯示
        /// </summary>
        public override void Initial()
        {

        }

        /// <summary>
        /// 開始特效
        /// </summary>
        public override void FadeIn(double time = 0)
        {
            _effectPicec.FadeTo(0.9f, Delay);
            _effectPicec.ScaleTo(2.5f, Delay + 100);
            _effectPicec.FadeTo(0.7f, Delay + 150);
            _effectPicec.FadeTo(0, Delay + 200);
        }

        /// <summary>
        /// 結束
        /// </summary>
        public override void FadeOut(double time = 0)
        {

        }
    }
}
