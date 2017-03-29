using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using osu.Game.Modes.RP.SkinManager;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common.ShapePiece
{
    /// <summary>
    ///     顯示結束物件
    ///     目前包含物體 : 結束的空物件
    /// </summary>
    internal class HitObjectAnyShapePiece : BaseHitObjectShapePiece
    {
        public bool IsFirst = true;

        /// <summary>
        ///     Mask
        /// </summary>
        private ImagePicec _maskImagePicec;

        /// <summary>
        ///     Mask 底下的背景物件
        /// </summary>
        private ImagePicec _startBackgroundImagePicec;

        /// <summary>
        ///     外框
        /// </summary>
        private readonly ImagePicec _borderImagePicec;


        /// <summary>
        ///     建構
        /// </summary>
        public HitObjectAnyShapePiece(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                //背景，自帶masking
                _startBackgroundImagePicec = new ImagePicec("") //(RPSkinManager.GetStartObjectBackgroundByType(HitObject as BaseHitObject))
                {
                    Colour = new Color4(100, 230, 17, 255),
                    Scale = new Vector2(0.5f),
                    CornerRadius = DrawSize.X / 2,
                    Masking = true
                },

                ////目前這層mask沒有用途
                _maskImagePicec = new ImagePicec("") //RPSkinManager.GetStartObjectMaskByType(HitObject as BaseHitObject))
                {
                    //Colour = osuObject.Colour,
                    Scale = new Vector2(0.5f),
                    Masking = true
                },

                //外框使用
                _borderImagePicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(HitObject as BaseHitObject))
                {
                    Colour = RpTextureColorManager.GetKeyLayoutButtonShage(((BaseHitObject)HitObject).Shape),
                    Scale = new Vector2(0.5f)
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
        }

        /// <summary>
        ///     結束
        /// </summary>
        public override void FadeOut(double time = 0)
        {
        }


        /// <summary>
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="repeat"></param>
        public void UpdateProgress(double progress, double endProgress = 1)
        {
            if (IsFirst)
                _borderImagePicec.Position = HitObject.Curve.PositionAt(progress) - HitObject.Position;
            else
                _borderImagePicec.Position = HitObject.Curve.PositionAt(endProgress) - HitObject.Position;
            Alpha = 1;
        }
    }
}
