//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.Replays;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap;
using osu.Game.Modes.RP.Beatmaps.RPBeatmap;
using osu.Game.Modes.RP.KeyManager;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Replay;
using osu.Game.Modes.RP.ScoreProcessor;
using osu.Game.Modes.RP.UI.GamePlay.Playfield;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using osu.Game.Modes.UI;
using osu.Game.Screens.Play;

namespace osu.Game.Modes.RP.UI.GamePlay.HitRenderer
{
    public class RpHitRenderer : HitRenderer<BaseRpObject, RpJudgement>
    {
        public RpHitRenderer(WorkingBeatmap beatmap)
            : base(beatmap)
        {
        }

        public override Scoring.ScoreProcessor CreateScoreProcessor() => new RpScoreProcessor(this);


        /// <summary>
        ///     the beatmap that convert from other beatmap
        /// </summary>
        /// <returns></returns>
        protected override IBeatmapConverter<BaseRpObject> CreateBeatmapConverter() => new BeatmapConvertor();

        //protected override IBeatmapConverter<BaseRpObject> CreateBeatmapConverter() => new RpBeatmapConvertor();

        /// <summary>
        ///     RP format beatmap
        /// </summary>
        /// <returns></returns>
        protected override IBeatmapProcessor<BaseRpObject> CreateBeatmapProcessor() => new RpBeatmapProcessor();

        /// <summary>
        ///     get all the rp keys 
        /// </summary>
        /// <param name="replay"></param>
        /// <returns></returns>
        protected override FramedReplayInputHandler CreateReplayInputHandler(Replays.Replay replay) => new RpReplayInputHandler(replay);

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
