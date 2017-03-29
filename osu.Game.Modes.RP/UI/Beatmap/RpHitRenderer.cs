//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap;
using osu.Game.Modes.RP.Beatmaps.RPBeatmap;
using osu.Game.Modes.RP.KeyManager;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.RP.ScoreProcessor;
using osu.Game.Modes.RP.UI.GamePlay.Playfield;
using osu.Game.Modes.UI;
using osu.Game.Screens.Play;

namespace osu.Game.Modes.RP.UI.Beatmap
{
    public class RpHitRenderer : HitRenderer<BaseRpObject, RpJudgement>
    {
        public RpHitRenderer(WorkingBeatmap beatmap)
            : base(beatmap)
        {
        }

        public override Scoring.ScoreProcessor CreateScoreProcessor() => new RpScoreProcessor(this);


        /// <summary>
        ///     從其他譜面轉過來
        /// </summary>
        /// <returns></returns>
        protected override IBeatmapConverter<BaseRpObject> CreateBeatmapConverter() => new BeatmapConvertor();

        //protected override IBeatmapConverter<BaseRpObject> CreateBeatmapConverter() => new RpBeatmapConvertor();

        /// <summary>
        ///     RP 專用譜面
        /// </summary>
        /// <returns></returns>
        protected override IBeatmapProcessor<BaseRpObject> CreateBeatmapProcessor() => new RpBeatmapProcessor();


        /// <summary>
        ///     建立遊玩區域
        /// </summary>
        /// <returns></returns>
        protected override Playfield<BaseRpObject, RpJudgement> CreatePlayfield() => new RpPlayfield();

        /// <summary>
        ///     目前不知道用途
        /// </summary>
        /// <returns></returns>
        protected override KeyConversionInputManager CreateKeyConversionInputManager() => new RpKeyConversionInputManager();

        /// <summary>
        ///     把RP物件轉換成可以繪製的物件
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        protected override DrawableHitObject<BaseRpObject, RpJudgement> GetVisualRepresentation(BaseRpObject h)
        {
            if (h is RpHitObject)
                return new DrawableRpHitObject((RpHitObject)h);
            if (h is RpLongTailObject)
                return new DrawableSliderObject((RpLongTailObject)h);
            if (h is RpContainerPress)
                return new DrawableRpLongPress((RpContainerPress)h);
            if (h is ObjectContainer)
                return new DrawableContainer((ObjectContainer)h);
            return null;
        }
    }
}
