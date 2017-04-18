//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.Objects.Drawables;
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
        public RpHitRenderer(WorkingBeatmap beatmap): base(beatmap)
        {
        }

        /// <summary>
        /// Creates the score processor.
        /// </summary>
        /// <returns>The score processor.</returns>
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
        ///     get all the rp keys 
        /// </summary>
        /// <param name="replay"></param>
        /// <returns></returns>
        ///protected override FramedReplayInputHandler CreateReplayInputHandler(Replay replay) => new RpReplayInputHandler(replay);

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
            if (h is RpHitObject)
                return new DrawableRpHitObject((RpHitObject)h);
            if (h is RpSliderObject)
                return new DrawableRpSliderObject((RpSliderObject)h);
            if (h is RpContainerPress)
                return new DrawableRpLongPress((RpContainerPress)h);
            if (h is RpContainer)
                return new DrawableRpContainer((RpContainer)h);
            return null;
        }
    }
}
