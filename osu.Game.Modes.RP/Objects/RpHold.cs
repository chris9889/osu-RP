using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    ///     按住可以持續加分
    /// </summary>
    internal class RpHold : BaseHitObject
    {
        /// <summary>
        ///     壓住增加分數
        /// </summary>
        public int HoldInsreaseScoreParBeat = 100;

        /// <summary>
        ///     是不是按了可以累積加分?
        /// </summary>
        public bool isLoop = false;


        /// <summary>
        ///     初始化預設物件
        /// </summary>
        public override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
            ObjectType = RpBaseObjectType.ObjectType.Hold;
        }
    }
}
