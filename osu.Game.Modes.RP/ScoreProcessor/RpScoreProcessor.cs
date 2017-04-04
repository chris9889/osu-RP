//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.Scoring;
using osu.Game.Modes.UI;

namespace osu.Game.Modes.RP.ScoreProcessor
{
    /// <summary>
    ///     簡單來說用來計算成績
    /// </summary>
    internal class RpScoreProcessor : ScoreProcessor<BaseRpObject, RpJudgement>
    {
        public RpScoreProcessor()
        {
        }

        public RpScoreProcessor(HitRenderer<BaseRpObject, RpJudgement> hitRenderer)
            : base(hitRenderer)
        {
        }

        protected override void Reset()
        {
            base.Reset();

            Health.Value = 1;
            Accuracy.Value = 1;
        }

        protected override void OnNewJudgement(RpJudgement judgement)
        {
            if (judgement != null)
                switch (judgement.Result)
                {
                    case HitResult.Hit:
                        Combo.Value++;
                        Health.Value += 0.1f;
                        break;
                    case HitResult.Miss:
                        Combo.Value = 0;
                        Health.Value -= 0.1f;
                        break;
                }

            //成績
            var score = 0;
            //最大成績
            var maxScore = 0;

            foreach (var j in Judgements)
            {
                switch (j.Score)
                {
                    case RPScoreResult.Sad:
                        maxScore += 300;
                        break;
                    case RPScoreResult.Safe:
                        score += 100;
                        maxScore += 300;
                        break;
                    case RPScoreResult.Fine:
                        score += 250;
                        maxScore += 300;
                        break;
                    case RPScoreResult.Cool:
                        score += 300;
                        maxScore += 300;
                        break;
                }
                //增加額外分數
                score += j.AdditionalPlusScore;
            }

            TotalScore.Value = score;
            //命中率
            Accuracy.Value = (double)score / maxScore;
        }
    }
}
