//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Modes.Mods;
using osu.Game.Modes.RP.DifficultyCalculator;
using osu.Game.Modes.RP.KeyManager;
using osu.Game.Modes.RP.ScoreProcessor;
using osu.Game.Modes.RP.UI.GamePlay.HitRenderer;
using osu.Game.Modes.RP.UI.GamePlay.KeyCounter;
using osu.Game.Modes.RP.UI.Select.Info;
using osu.Game.Modes.RP.UI.Select.Mod;
using osu.Game.Modes.UI;
using osu.Game.Screens.Play;

namespace osu.Game.Modes.RP
{
    public class RpRuleset : Ruleset
    {
        /// <summary>
        ///     使用icon
        /// </summary>
        public override FontAwesome Icon => FontAwesome.fa_align_justify;

        /// <summary>
        ///     Description
        /// </summary>
        public override string Description => "osu!RP";

        /// <returns></returns>
        /// <summary>
        ///     遊玩模式
        /// </summary>
        protected override PlayMode PlayMode => PlayMode.RP;

        /// <summary>
        ///     RP物件會被轉換成可以顯示的物件
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public override HitRenderer CreateHitRendererWith(WorkingBeatmap beatmap) => new RpHitRenderer(beatmap);

        /// <summary>
        ///     beatmap的詳細資訊
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override IEnumerable<BeatmapStatistic> GetBeatmapStatistics(WorkingBeatmap beatmap) => new BeatmapStatistics(beatmap);

        /// <summary>
        ///     目前有那些模式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override IEnumerable<Mod> GetModsFor(ModType type) => new SelectMod(type);

        /// <summary>
        ///     計算難度
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override Game.Beatmaps.DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap) => new RpDifficultyCalculator(beatmap);

        /// <summary>
        ///     Score processor
        /// </summary>
        /// <returns></returns>
        public override Scoring.ScoreProcessor CreateScoreProcessor() => new RpScoreProcessor();

        /// <summary>
        ///     取得目前有哪些按鍵
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<KeyCounter> CreateGameplayKeys() => new RpKeyCounterCollection(RpKeyManager.GetCurrentKeyConfig()).ListKey;
    }
}
