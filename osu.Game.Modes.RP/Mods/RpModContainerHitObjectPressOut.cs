using System;
using osu.Game.Graphics;

namespace osu.Game.Modes.RP.Mods
{
    /// <summary>
    ///RP : ”wŒiˆÂšØ“I•¨Œ˜ğ©“®Š®¬
    /// </summary>
    public class RpModContainerHitObjectPressOut : Modes.Mod
    {
        public override string Name => "SpunOut";
        public override FontAwesome Icon => FontAwesome.fa_osu_mod_spunout;
        public override string Description => @"Background HitObject will be automatically completed";
        public override double ScoreMultiplier => 0.9;
        public override bool Ranked => true;

        public override Type[] IncompatibleMods => new Type[] { typeof(ModAutoplay), typeof(ModCinema), typeof(ModAutoplay), };
    }
}