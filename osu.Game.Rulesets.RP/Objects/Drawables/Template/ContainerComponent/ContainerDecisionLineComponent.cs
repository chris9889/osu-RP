// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component
{
    /// <summary>
    /// </summary>
    internal class ContainerDecisionLine : ComponentBaseContainer, IChangeableContainerComponent, IComponentHasStartTime, IComponentHasEndTime ,IComponentBase
    {
        /// <summary>
        ///     �����
        /// </summary>
        private ImagePicec _containerDecisionLineComponent;

        /// <summary>
        /// </summary>
        public ContainerDecisionLine(RpContainerLineGroup hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        ///     �X�V����
        /// </summary>
        /// <param name="time"></param>
        public void UpdateTime(double time)
        {
            //�v�Z�w�j�ʒu 
            _containerDecisionLineComponent.Position = CalculatePosition(time - HitObject.StartTime);
        }

        /// <summary>
        ///     �C���������x
        /// </summary>
        /// <param name="newHeight"></param>
        public void ChangeHeight(float newHeight)
        {
        }


        protected override void InitialObject(int layerCount = 1)
        {
            //�w�W
            _containerDecisionLineComponent = new ImagePicec(RpTexturePathManager.GetDecisionLineTexture())
            {
                Position = new Vector2(0, 0),
                Scale = new Vector2(1f, 1f * layerCount)
            };
        }


        protected override void InitialChild()
        {
            var listDrawable = new List<Container>();
            listDrawable.Add(_containerDecisionLineComponent);
            Children = listDrawable;
        }


        public void SetStartTime(double startTime)
        {
            throw new NotImplementedException();
        }

        public void SetEndTime(double time)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        void UpdateMovingTransform()
        {
        }

        public void FadeIn(double time = 0)
        {
            //throw new NotImplementedException();
        }

        public void FadeOut(double time = 0)
        {
            //throw new NotImplementedException();
        }
    }
}
