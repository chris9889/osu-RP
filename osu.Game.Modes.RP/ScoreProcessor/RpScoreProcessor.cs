//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Modes.Judgements;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Objects;
using System;
using osu.Game.Modes.UI;

namespace osu.Game.Modes.RP.ScoreProcessor
{
    /// <summary>
    /// 簡單來說用來計算成績
    /// </summary>
    class RpScoreProcessor : Modes.ScoreProcessor<BaseRpObject, RPJudgementInfo>
    {
        public RpScoreProcessor()
        {

        }

        public RpScoreProcessor(HitRenderer<BaseRpObject, RPJudgementInfo> hitRenderer): base(hitRenderer)
        {

        }

        protected override void Reset()
        {
            base.Reset();

            Health.Value = 1;
            Accuracy.Value = 1;
        }

        protected override void UpdateCalculations(RPJudgementInfo judgement)
        {
            if (judgement != null)
            {
                switch (judgement.Result)
                {
                    case HitResult.Hit:
                        Combo.Value++;
                        Health.Value += 0.1f;
                        break;
                    case HitResult.Miss:
                        Combo.Value = 0;
                        Health.Value -= 0.2f;
                        break;
                }
            }

            //成績
            int score = 0;
            //最大成績
            int maxScore = 0;

            foreach (RPJudgementInfo j in Judgements)
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
                score += j.additionalPlusScore;
            }

            TotalScore.Value = score;
            //命中率
            Accuracy.Value = (double)score / maxScore;
        }
    }
}
