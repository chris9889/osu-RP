using osu.Game.Modes.RP.Objects.type;
using OpenTK.Graphics;
using osu.Game.Modes.Objects.Types;
using System;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    ///     陬｡髱｢譛・┫蟄俶園譛芽ｩｲ蝨ｨ荳企擇逧・黄莉ｶ
    /// </summary>
    public class RpContainerLayout : BaseRpObject, IHasEndTime
    {
        /// <summary>
        ///     逕ｨ萓・ｾ槫次譛ｬ逧Гontainer陬｡髱｢蜿門ｾ嶺ｸ莠幄ｳ・ｨ・
        /// </summary>
        public RpContainer ObjectContainer;

        /// <summary>
        ///     邨先據譎る俣・悟庄莉･莉ｻ諢剰ｨｭ螳・
        /// </summary>
        public double EndTime;

        /// <summary>
        ///     迚ｩ莉ｶ髟ｷ蠎ｦ
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
        ///     蛻晏ｧ句喧迚ｩ莉ｶ蜿・丙
        /// </summary>
        public override void InitialDefaultValue()
        {
            TIME_FADEIN = 300;

            //謠先掠螟壻ｹ・・迴ｾ・碁壼ｸｸ譏ｯ蟒ｶ蠕・-逧・
            TIME_PREEMPT = 0;
            TIME_FADEOUT = 300;

            //鬘剰牡
            Colour = new Color4(100, 100, 100, 255);
        }

        /// <summary>
        ///     譖ｴ譁ｰ陬｡髱｢逧・ｳ・ｨ・
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
