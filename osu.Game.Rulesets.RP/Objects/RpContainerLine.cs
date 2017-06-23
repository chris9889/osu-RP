using System;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     裡面朁E��存所有該在上面皁E��件
    /// </summary>
    public class RpContainerLine : BaseRpObject, IHasEndTime
    {
        /// <summary>
        ///     用侁E��原本的Container裡面取得一些賁E��E
        /// </summary>
        public RpContainerLineGroup ObjectContainer;

        /// <summary>
        ///     物件長度
        /// </summary>
        public float Lenght = 512;

        //Fade Out time after PreemptTime
        public override float FadeInTime => 300 * FadeSpeedMultiple;

        //Fade Out time after EndTime 
        public override float FadeOutTime => 300 * FadeSpeedMultiple;

        public RpBaseHitObjectType.Coop Coop = RpBaseHitObjectType.Coop.Both;

        public RpContainerLine(RpContainerLineGroup objectContainer)
        {
            UpdateContainerLayout(objectContainer);

            InitialDefaultValue();
        }

        /// <summary>
        ///     初始化物件叁E��
        /// </summary>
        public override void InitialDefaultValue()
        {
            //提早多乁E�E現�E�通常是延征E-皁E
            PreemptTime = 0;
            //顏色
            Colour = new Color4(100, 100, 100, 255);
        }

        /// <summary>
        ///     更新裡面皁E��E��E
        /// </summary>
        /// <param name="objectContainer"></param>
        public void UpdateContainerLayout(RpContainerLineGroup objectContainer)
        {
            ObjectContainer = objectContainer;
            StartTime = ObjectContainer.StartTime;
            Velocity = ObjectContainer.Velocity;
            EndTime = ObjectContainer.EndTime;
            Lenght = ObjectContainer.Lenght;
        }
    }
}
