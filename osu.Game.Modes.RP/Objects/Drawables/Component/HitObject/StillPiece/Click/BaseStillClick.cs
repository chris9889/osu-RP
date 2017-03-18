using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.StillPiece.Click
{
    class BaseStillClick : BaseStillPiece
    {
        /// <summary>
        /// 開頭和結尾物件
        /// </summary>
        private EndPieces _endPiecesFirstObject;

        public BaseStillClick(BaseHitObject baseHitObject) : base(baseHitObject)
        {
            Children = new Drawable[]
           {
                //開頭物件
                _endPiecesFirstObject = new EndPieces(baseHitObject as BaseHitObject)//false
                {
                    Position = new Vector2(0, 0),
                    //Scale = new Vector2(_hitObject.Scale),
                    IsFirst = true,
                },
           };
        }

        /// <summary>
        /// 初始化顯示
        /// </summary>
        public override void Initial()
        {
            _endPiecesFirstObject.Alpha = 1;
        }

        /// <summary>
        /// 開始特效
        /// </summary>
        public override void FadeIn(double time = 0)
        {
            _endPiecesFirstObject.FadeIn(time);
        }

        /// <summary>
        /// 結束
        /// </summary>
        public override void FadeOut(double time = 0)
        {
            _endPiecesFirstObject.FadeOut(time);
        }
    }
}
