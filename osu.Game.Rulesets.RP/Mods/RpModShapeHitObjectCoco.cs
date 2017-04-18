using System;
using osu.Game.Graphics;

namespace osu.Game.Modes.RP.Mods
{
    /// <summary>
    /// Shape Coco，會把單手的 Mode 變成雙手的
    /// 會參考預設譜面設定做調整
    /// </summary>
    public class RpModShapeHitObjectCoco : Modes.Mod
    {
        public override string Name => "KeyCoop";
        public override FontAwesome Icon => FontAwesome.fa_osu_mod_autopilot;
        public override string Description => @"RP Shape Object all become co-co mode";
        public override double ScoreMultiplier => 1;
        public override bool Ranked => true;
        public override Type[] IncompatibleMods => new Type[] { };
    }
}