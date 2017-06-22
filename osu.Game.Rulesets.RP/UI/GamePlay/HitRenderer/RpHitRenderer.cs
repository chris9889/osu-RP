//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Configuration;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.RP.BeatmapReplay;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap;
using osu.Game.Rulesets.RP.Beatmaps.RPBeatmap;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using osu.Game.Rulesets.UI;
using osu.Game.Screens.Play;

namespace osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer
{
    public class RpHitRenderer : HitRenderer<BaseRpObject, RpJudgement>
    {
        private readonly ModsProcessor.ModsProcessor _modProcessor;

        public RpHitRenderer(WorkingBeatmap beatmap, bool isForCurrentRuleset): base(beatmap,isForCurrentRuleset)
        {
            _modProcessor = new ModsProcessor.ModsProcessor(beatmap.Mods.Value);
            _modProcessor.ProcessGameField(Playfield);
        }

        /// <summary>
        /// Creates the score _modProcessor.
        /// </summary>
        /// <returns>The score _modProcessor.</returns>
        public override osu.Game.Rulesets.Scoring.ScoreProcessor CreateScoreProcessor() => new RpScoreProcessor(this);


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
        ///     set the keys and keyboard that can use as input when replay
        /// </summary>
        /// <param name="replay"></param>
        /// <returns></returns>
        protected override FramedReplayInputHandler CreateReplayInputHandler(Replay replay) => new RpReplayInputHandler(replay);

        /// <summary>
        ///     Create the play field
        /// </summary>
        /// <returns></returns>
        protected override Playfield<BaseRpObject, RpJudgement> CreatePlayfield() => new RpPlayfield();

        /// <summary>
        ///     didn't know what is it
        /// </summary>
        /// <returns></returns>
        protected override KeyConversionInputManager CreateKeyConversionInputManager() => new RpKeyConversionInputManager();

        /// <summary>
        ///     Change objects into drawable
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        protected override DrawableHitObject<BaseRpObject, RpJudgement> GetVisualRepresentation(BaseRpObject h)
        {
            DrawableHitObject<BaseRpObject, RpJudgement> returnObject = null;
            
            if (h is RpHitObject)
                returnObject= new DrawableRpHitObject((RpHitObject)h);
            if (h is RpHoldObject)
                returnObject= new DrawableRpHoldObject((RpHoldObject)h);
            if (h is RpContainerLineHoldObject)
                returnObject= new DrawableRpContainerLineHoldObject((RpContainerLineHoldObject)h);
            if (h is RpContainerLineGroup)
                returnObject= new DrawableRpContainerLineGroup((RpContainerLineGroup)h);

            //adding Mods
            _modProcessor.ProcessHitObject(returnObject);

            return returnObject;
        }
    }
}
