// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component
{
    /// <summary>
    ///     �䔻���y�p
    /// </summary>
    internal class ContainerBeatLine : ComponentBaseContainer, IChangeableContainerComponent, IComponentHasStartTime, IComponentHasEndTime, IComponentHasBpm ,IComponentBase
    {
        /// <summary>
        ///     ���ԓI�ߔ�
        /// </summary>
        private readonly List<ImagePicec> _containerBeatDecisionLineComponent = new List<ImagePicec>();

        /// <summary>
        ///     �v�Z�����I��萍��x�aHeight�ʒu
        /// </summary>
        private ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        public ContainerBeatLine(RpContainerLineGroup hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        ///     �C���������x
        /// </summary>
        /// <param name="newHeight"></param>
        public void ChangeHeight(float newHeight)
        {
        }

        /// <summary>
        ///     ���n������
        /// </summary>
        protected override void InitialObject(int layerCount = 0)
        {
            InitialBeat();
        }


        protected override void InitialChild()
        {
            Children = _containerBeatDecisionLineComponent;
        }

        /// <summary>
        ///     ���n���ߔ��y
        /// </summary>
        private void InitialBeat()
        {
            for (var i = 0; i < 20; i++)
            {
                if (_positionCounter.GetPosition(i * GetDeltaBeatTime(), HitObject.Velocity) > _positionCounter.GetPosition((HitObject as RpContainerLineGroup).EndTime - HitObject.StartTime, HitObject.Velocity))
                    break;

                //����
                var line = new ImagePicec(RpTexturePathManager.GetBeatLineTexture());
                line.Scale = new Vector2(0.6f);
                //�ݒ�ʒu
                line.Position = CalculatePosition(i * GetDeltaBeatTime());
                //����
                _containerBeatDecisionLineComponent.Add(line);
            }
        }

        public void SetStartTime(double startTime)
        {
            throw new NotImplementedException();
        }

        public void SetEndTime(double time)
        {
            throw new NotImplementedException();
        }

        public void ChangeBPM(double newBpm)
        {
            throw new NotImplementedException();
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
