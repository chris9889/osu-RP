using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.SkinManager;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.HitObject.Common.ShapePiece
{
    /// <summary>
    ///     ������������
    ///     �ڑO��ܕ�� : �����I�󕨌�
    /// </summary>
    internal class HitObjectAnyShapePiece : BaseHitObjectShapePiece
    {
        public bool IsFirst = true;

        /// <summary>
        ///     �O�y
        /// </summary>
        private readonly ImagePicec _borderImagePicec;

        /// <summary>
        ///     Mask
        /// </summary>
        private ImagePicec _maskImagePicec;

        /// <summary>
        ///     Mask �ꉺ�I�w�i����
        /// </summary>
        private ImagePicec _startBackgroundImagePicec;


        /// <summary>
        ///     ���\
        /// </summary>
        public HitObjectAnyShapePiece(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                //�w�i�C����masking
                _startBackgroundImagePicec = new ImagePicec("") //(RPSkinManager.GetStartObjectBackgroundByType(HitObject as BaseHitObject))
                {
                    Colour = RpTextureColorManager.GetKeyLayoutButtonShage(((BaseRpHitObject)HitObject).Shape),
                    Scale = new Vector2(0.5f),
                    CornerRadius = DrawSize.X / 2,
                    Masking = true
                },

                ////�ڑO���wmask���L�p�r
                _maskImagePicec = new ImagePicec("") //RPSkinManager.GetStartObjectMaskByType(HitObject as BaseHitObject))
                {
                    //Colour = osuObject.Colour,
                    Scale = new Vector2(0.5f),
                    Masking = true
                },

                //�O�y�g�p
                _borderImagePicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(HitObject as BaseRpHitObject))
                {
                    Colour = RpTextureColorManager.GetKeyLayoutButtonShage(((BaseRpHitObject)HitObject).Shape),
                    Scale = new Vector2(0.5f)
                }
            };
        }

        /// <summary>
        ///     ���n������
        /// </summary>
        public override void Initial()
        {
        }

        /// <summary>
        ///     �J�n����
        /// </summary>
        public override void FadeIn(double time = 0)
        {
        }

        /// <summary>
        ///     ����
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
