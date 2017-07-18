using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Position;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpContainer
{
    public class BaseContainerComponent : BaseComponent
    {
        /// <summary>
        /// </summary>
        public new Objects.RpContainerLineGroup HitObject;

        /// <summary>
        ///     ���ӌv�Z�����ݎ����y�Y�L�I�ʒu
        /// </summary>
        protected readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        public BaseContainerComponent(Objects.RpContainerLineGroup hitObject)
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
            //�����n ObjectContainer ����椎�
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
