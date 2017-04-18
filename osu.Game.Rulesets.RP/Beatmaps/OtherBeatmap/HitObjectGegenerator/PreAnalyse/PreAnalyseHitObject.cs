// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse
{
    public class PreAnalyseHitObject
    {
        //分析目前物件是否有combo的傾向
        private readonly AnaylseCombo AnaylseCombo = new AnaylseCombo();

        //目前同時有幾個物件按壓
        private readonly AnaylseMulti AnaylseMulti = new AnaylseMulti();

        public HitObjectConvertParameter Analyse(ConvertParameter single)
        {
            //打擊物件的參數
            var parameter = new HitObjectConvertParameter();

            for (var i = 0; i < single.ListRefrenceObject.Count; i++)
            {
                //單一參數
                var singleParameter = new SingleHitObjectConvertParameter();
                //有無combo
                singleParameter.IsCombo = AnaylseCombo.IsCombo(single, i);
                //出現物件數量
                singleParameter.MultiNumber = AnaylseMulti.GetMultiNumber(single, i);
                //開始時間
                singleParameter.StartTime = single.ListRefrenceObject[i].StartTime;
                //結束時間
                singleParameter.EndTime = single.ListRefrenceObject[i].StartTime;
                //增加物件
                parameter.ListSingleHitObjectConvertParameter.Add(singleParameter);
            }

            return parameter;
        }
    }
}
