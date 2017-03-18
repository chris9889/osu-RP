using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.MovePiece;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.StillPiece;
using osu.Game.Modes.RP.Objects.Drawables.Pieces;
using osu.Game.Modes.RP.Objects.type;
using osu.Game.Modes.RP.SkinManager;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Template.HitObject
{
    /// <summary>
    /// 所以打擊物件
    /// 這邊會共同繼承 : 
    /// Approach Circle
    /// DrawLine (定點和飄移物件)
    /// </summary>
    class RpDrawHitObjectTemplate : RpDrawBaseObjectTemplate
    {

        private GetMovePiece GetMovePiecen = new GetMovePiece();
        private GetStillPiece GetStillPiece = new GetStillPiece();


        /// <summary>
        /// 開始物件
        /// </summary>
        private BaseMovePicec BaseMovePicec;

        /// <summary>
        /// 結束物件
        /// </summary>
        private BaseStillPiece BaseStillPiece;

        /// <summary>
        /// 物件
        /// </summary>
        protected new BaseHitObject _hitObject;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hitObject"></param>
        public RpDrawHitObjectTemplate(BaseRpObject hitObject) : base(hitObject)
        {
            _hitObject = (BaseHitObject)hitObject;
            InitialApproachHitPicec();
            InitialChild();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void InitialApproachHitPicec()
        {
            UpdateApproachType();
            base.Initial();
            BaseMovePicec.Initial();
            BaseStillPiece.Initial();
        }

        //初始化Child
        protected void InitialChild()
        {
            //不會動的容器
            StartObjectContainer = BaseStillPiece;

            //開始物件
            Children = new Drawable[]
            {
                LoadEffect,
                StartObjectContainer,
                BaseMovePicec,
            };
            //結束物件增加打擊物件
            Components.Add(BaseMovePicec);
        }

        /// <summary>
        /// 淡入(開始顯示物件)
        /// </summary>
        /// <param name="time"></param>
        public override void FadeIn(double time = 0)
        {
            BaseMovePicec.FadeIn(time);
            BaseStillPiece.FadeIn(time);
            base.FadeIn(time);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        public override void FadeOut(double time = 0)
        {
            BaseMovePicec.FadeOut(time);
            BaseStillPiece.FadeOut(time);
            base.FadeOut(time);
        }

        /// <summary>
        /// 進行選擇
        /// </summary>
        protected virtual void UpdateApproachType()
        {
            BaseMovePicec = GetMovePiecen.GetPicec(_hitObject);
            BaseStillPiece = GetStillPiece.GetPicec(_hitObject);
        }
    }
}
