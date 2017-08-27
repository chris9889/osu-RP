﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap;
using osu.Game.Rulesets.RP.Beatmaps.RPBeatmap;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.Replays;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer
{
    public class RpRulesetContainer : RulesetContainer<BaseRpObject, RpJudgement>
    {
        private readonly ModsProcessor.ModsProcessor _modProcessor;

        public RpRulesetContainer(Ruleset ruleset, WorkingBeatmap beatmap, bool isForCurrentRuleset)
            : base(ruleset, beatmap, isForCurrentRuleset)
        {
            _modProcessor = new ModsProcessor.ModsProcessor(beatmap.Mods.Value);
            _modProcessor.ProcessGameField(Playfield);
        }

        /// <summary>
        /// Creates the score _modProcessor.
        /// </summary>
        /// <returns>The score _modProcessor.</returns>
        public override ScoreProcessor CreateScoreProcessor() => new RpScoreProcessor(this);

        /// <summary>
        ///     the beatmap that convert from other beatmap
        /// </summary>
        /// <returns></returns>
        protected override BeatmapConverter<BaseRpObject> CreateBeatmapConverter() => new BeatmapConvertor();

        /// <summary>
        ///     RP format beatmap
        /// </summary>
        /// <returns></returns>
        protected override BeatmapProcessor<BaseRpObject> CreateBeatmapProcessor() => new RpBeatmapProcessor();

        /// <summary>
        ///     Create the play field
        /// </summary>
        /// <returns></returns>
        protected override Playfield<BaseRpObject, RpJudgement> CreatePlayfield() => new RpPlayfield();


        /// <summary>
        ///     didn't know what is it
        /// </summary>
        /// <returns></returns>
        public override PassThroughInputManager CreateInputManager() => new RpInputManager(Ruleset.RulesetInfo);

        /// <summary>
        ///     Change objects into drawable
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        protected override DrawableHitObject<BaseRpObject, RpJudgement> GetVisualRepresentation(BaseRpObject h)
        {
            DrawableHitObject<BaseRpObject, RpJudgement> returnObject = null;

            if (h is RpHitObject)
                return new DrawableRpHitObject((RpHitObject)h);
            if (h is RpHoldObject)
                return new DrawableRpHoldObject((RpHoldObject)h);
            if (h is RpContainerLineHoldObject)
                return new DrawableRpContainerLineHoldObject((RpContainerLineHoldObject)h);
            if (h is RpContainerLineGroup)
                return new DrawableRpContainerLineGroup((RpContainerLineGroup)h);

            return null;
        }

        /// <summary>
        /// if one keys equals to another keys ,use this
        /// </summary>
        /// <param name="replay"></param>
        /// <returns></returns>
        protected override FramedReplayInputHandler CreateReplayInputHandler(Replay replay) => new RpReplayInputHandler(replay);

        protected override Vector2 GetPlayfieldAspectAdjust() => new Vector2(0.75f);
    }
}
