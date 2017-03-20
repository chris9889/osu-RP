//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.UI;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Modes.RP.UI.Select;
using System;
using osu.Game.Modes.Mods;
using osu.Game.Modes.RP.DifficultyCalculator;
using osu.Game.Modes.RP.KeyManager;
using osu.Game.Modes.RP.Saving;
using osu.Game.Modes.RP.ScoreProcessor;
using osu.Game.Modes.RP.UI.Beatmap;
using osu.Game.Modes.RP.UI.GamePlay.KeyCounter;
using osu.Game.Screens.Play;
using OpenTK.Input;

namespace osu.Game.Modes.RP
{
    public class RpRuleset : Ruleset
    {

        /// <summary>
        /// RP物件會被轉換成可以顯示的物件
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public override HitRenderer CreateHitRendererWith(WorkingBeatmap beatmap) => new RpHitRenderer(beatmap);

        /// <summary>
        /// 顯示場景計數物件
        /// </summary>
        /// <returns></returns>
        //public override ScoreOverlay CreateScoreOverlay() => new RpScoreOverlay();

        

        /// <summary>
        /// beatmap的詳細資訊
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override IEnumerable<BeatmapStatistic> GetBeatmapStatistics(WorkingBeatmap beatmap) => new BeatmapStatistics(beatmap);

        /// <summary>
        /// 目前有那些模式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override IEnumerable<Mod> GetModsFor(ModType type) => new SelectMod(type);

        /// <summary>
        /// 使用icon
        /// </summary>
        public override FontAwesome Icon => FontAwesome.fa_align_justify;

        /// <summary>
        /// 計算難度
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override osu.Game.Beatmaps.DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap) => new RpDifficultyCalculator(beatmap);

        /// <summary>
        /// RP譜面底下物件轉換器
        /// </summary>
        /// <returns></returns>
        //public override HitObjectParser CreateHitObjectParser() => new RpHitObjectParser();

        /// <summary>
        /// 打擊計算物件處理
        /// </summary>
        /// <param name="hitObjectCount"></param>
        /// <returns></returns>
        //public override osu.Game.Modes.ScoreProcessor CreateScoreProcessor(int hitObjectCount = 0) => new RpScoreProcessor(hitObjectCount);

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        //public override Score CreateAutoplayScore(Beatmap beatmap)
        //{
        //    var score = CreateScoreProcessor().GetScore();
        //    score.Replay = new RpAutoReplay(beatmap);
        //    return score;
        //}

        /// <summary>
        /// 遊玩模式
        /// </summary>
        protected override PlayMode PlayMode => PlayMode.RP;

        public override Modes.ScoreProcessor CreateScoreProcessor() => new RpScoreProcessor();


        public override string Description => "osu!RP";

        /// <summary>
        /// 取得目前有哪些按鍵
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<KeyCounter> CreateGameplayKeys() => new RpKeyCounterCollection(RpKeyManager.GetCurrentKeyConfig()).ListKey;
    }
}
