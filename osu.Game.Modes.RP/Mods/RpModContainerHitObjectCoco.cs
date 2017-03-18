using System;
using osu.Game.Graphics;

namespace osu.Game.Modes.RP.Mods
{
    /// <summary>
    /// Container Press Coco，會把單手的 Mode 變成雙手的
    /// 會參考譜面設定做調整
    /// </summary>
    public class RpModContainerHitObjectCoco : Modes.Mod
    {
        public override string Name => "KeyCoop";
        public override FontAwesome Icon => FontAwesome.fa_osu_mod_target;
        public override string Description => @"RP Background Object all become co-co mode";
        public override double ScoreMultiplier => 1;
        public override bool Ranked => true;
        public override Type[] IncompatibleMods => new Type[] { };
    }
}