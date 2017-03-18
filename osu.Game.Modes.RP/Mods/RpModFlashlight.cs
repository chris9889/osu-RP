using System;

namespace osu.Game.Modes.RP.Mods
{
    /// <summary>
    /// 只有判定線附近會發亮
    /// </summary>
    public class RpModFlashlight : ModFlashlight
    {
        public override double ScoreMultiplier => 1.12;
        public override Type[] IncompatibleMods => new Type[] { };
    }
}