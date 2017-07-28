// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component
{
    public class BaseContainerComponent : BaseComponent
    {
        /// <summary>
        /// </summary>
        public new RpContainerLineGroup HitObject
        {
            get { return(RpContainerLineGroup)base.HitObject; }
            set { base.HitObject = value; }
        }

        /// <summary>
        ///     ���ӌv�Z�����ݎ����y�Y�L�I�ʒu
        /// </summary>
        protected readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        public BaseContainerComponent(RpContainerLineGroup hitObject)
        {
            HitObject = hitObject;
            InitialObject();
            InitialChild();
        }

        /// <summary>
        ///     �X�V�V�I Layout�ɗ�
        /// </summary>
        /// <param name="newLayerNumber"></param>
        public virtual void UpdateLayerNumber()
        {
            //�����n ParentObject ����椎�
        }

        /// <summary>
        ///     �@�ʍX�V���J�n���������I����
        /// </summary>
        public virtual void UpdateTime()
        {
        }


        /// <summary>
        ///     ���n�����L��������
        /// </summary>
        protected virtual void InitialObject(int layerCount = 1)
        {
        }

        /// <summary>
        ///     ���n�����L��������
        /// </summary>
        protected virtual void InitialChild()
        {
        }

        /// <summary>
        ///     ���������y�v�Z�����ʒu
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        protected Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time, HitObject.Velocity), 0);
        }

        /// <summary>
        ///     �擾�Ԋu����
        /// </summary>
        /// <returns></returns>
        protected double GetDeltaBeatTime()
        {
            return 1000 * 60 / HitObject.BPM;
        }
    }
}
