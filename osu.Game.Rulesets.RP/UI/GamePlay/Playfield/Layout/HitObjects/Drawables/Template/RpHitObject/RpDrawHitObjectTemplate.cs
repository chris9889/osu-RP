﻿using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.MovePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpHitObject.StillPiece;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpHitObject
{
    /// <summary>
    ///     所以打擊物件
    ///     這邊會共同繼承 :
    ///     Approach Right
    ///     DrawLine (定點和飄移物件)
    /// </summary>
    internal class RpDrawHitObjectTemplate : RpDrawBaseObjectTemplate
    {
        /// <summary>
        ///     物件
        /// </summary>
        protected new BaseRpHitableObject _hitObject;

        private readonly GetMovePiece GetMovePiecen = new GetMovePiece();
        private readonly GetStillPiece GetStillPiece = new GetStillPiece();


        /// <summary>
        ///     開始物件
        /// </summary>
        private BaseMovePicec BaseMovePicec;

        /// <summary>
        ///     結束物件
        /// </summary>
        private BaseStillPiece BaseStillPiece;

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public RpDrawHitObjectTemplate(BaseRpObject hitObject)
            : base(hitObject)
        {
            _hitObject = (BaseRpHitableObject)hitObject;
            InitialApproachHitPicec();
            InitialChild();
        }

        /// <summary>
        ///     淡入(開始顯示物件)
        /// </summary>
        /// <param name="time"></param>
        public override void FadeIn(double time = 0)
        {
            BaseMovePicec.FadeIn(time);
            BaseStillPiece.FadeIn(time);
            base.FadeIn(time);
        }

        /// <summary>
        /// </summary>
        /// <param name="time"></param>
        public override void FadeOut(double time = 0)
        {
            BaseMovePicec.FadeOut(time);
            BaseStillPiece.FadeOut(time);
            base.FadeOut(time);
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
                BaseMovePicec
            };
            //結束物件增加打擊物件
            Components.Add(BaseMovePicec);
        }

        /// <summary>
        ///     進行選擇
        /// </summary>
        protected virtual void UpdateApproachType()
        {
            BaseMovePicec = GetMovePiecen.GetPicec(_hitObject);
            BaseStillPiece = GetStillPiece.GetPicec(_hitObject);
        }

        /// <summary>
        ///     初始化
        /// </summary>
        private void InitialApproachHitPicec()
        {
            UpdateApproachType();
            Initial();
            BaseMovePicec.Initial();
            BaseStillPiece.Initial();
        }
    }
}
