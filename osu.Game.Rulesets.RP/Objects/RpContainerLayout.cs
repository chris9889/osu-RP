using System;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     裡面朁E��存所有該在上面皁E��件
    /// </summary>
    public class RpContainerLayout : BaseRpObject, IHasEndTime
    {
        /// <summary>
        ///     用侁E��原本的Container裡面取得一些賁E��E
        /// </summary>
        public RpContainer ObjectContainer;

        /// <summary>
        ///     結束時間�E�可以任意設宁E
        /// </summary>
        public double EndTime;

        /// <summary>
        ///     物件長度
        /// </summary>
        public float Lenght = 512;

        public RpBaseHitObjectType.Coop Coop = RpBaseHitObjectType.Coop.Both;

        public RpContainerLayout(RpContainer objectContainer)
        {
            UpdateContainerLayout(objectContainer);

            InitialDefaultValue();
        }

        public void SetEndTime(Double time)
        {

            EndTime = time;
        }

        /// <summary>
        ///     初始化物件叁E��
        /// </summary>
        public override void InitialDefaultValue()
        {
            TIME_FADEIN = 300;

            //提早多乁E�E現�E�通常是延征E-皁E
            TIME_PREEMPT = 0;
            TIME_FADEOUT = 300;

            //顏色
            Colour = new Color4(100, 100, 100, 255);
        }

        /// <summary>
        ///     更新裡面皁E��E��E
        /// </summary>
        /// <param name="objectContainer"></param>
        public void UpdateContainerLayout(RpContainer objectContainer)
        {
            ObjectContainer = objectContainer;
            StartTime = ObjectContainer.StartTime;
            Velocity = ObjectContainer.Velocity;
            EndTime = ObjectContainer.EndTime;
            Lenght = ObjectContainer.Lenght;
        }
    }
}
