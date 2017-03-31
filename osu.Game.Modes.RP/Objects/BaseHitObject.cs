//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps.Samples;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    ///     所有打擊物件都會繼承這裡
    /// </summary>
    public abstract class BaseHitObject : BaseRpObject
    {
       
        public override double EndTime => StartTime;
        public override double Duration => EndTime - StartTime;
        //判定
        public double hit50 = 180;
        public double hit100 = 160;
        public double hit300 = 140;

        /// <summary>
        ///     是裝在哪個Container裡面
        /// </summary>
        public int ContainerIndex = 0;

        /// <summary>
        ///     是在哪一個index上面
        /// </summary>
        public int LayoutIndex = 0;

        /// <summary>
        ///     畫線的順序
        /// </summary>
        public int _drawLinePriority = 0;

        /// <summary>
        ///     設定類型
        /// </summary>
        public RpBaseHitObjectType.Shape Shape = RpBaseHitObjectType.Shape.Right;

        /// <summary>
        ///     設定類型
        /// </summary>
        public RpBaseObjectType.Special Special = RpBaseObjectType.Special.Normal;

        /// <summary>
        ///     設定類型，哪一種生成方式
        /// </summary>
        public RpBaseObjectType.CurveGenerate CurveGenerate = RpBaseObjectType.CurveGenerate.Auto;

        /// <summary>
        ///     設定類型
        /// </summary>
        public RpBaseHitObjectType.Multi Multi = RpBaseHitObjectType.Multi.SingleClick;

        /// <summary>
        ///     設定類型
        /// </summary>
        public RpBaseObjectType.Comvert Comvert = RpBaseObjectType.Comvert.Original;

        /// <summary>
        ///     用不同落下方式當判定點
        /// </summary>
        public RpBaseHitObjectType.ApproachType ApproachType = RpBaseHitObjectType.ApproachType.ApproachCircle;

        public BaseHitObject()
        {
            Sample = new HitSampleInfo();
            Sample.Set= SampleSet.Soft;
            Sample.Type = SampleType.Whistle;
        }

        /// <summary>
        /// 討延遲時間用
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public double HitWindowFor(RPScoreResult result)
        {
            switch (result)
            {
                default:
                    return 300;
                case RPScoreResult.Safe:
                    return 150;
                case RPScoreResult.Fine:
                    return 80;
                case RPScoreResult.Cool:
                    return 30;
            }
        }

        public RPScoreResult ScoreResultForOffset(double offset)
        {
            if (offset < HitWindowFor(RPScoreResult.Cool))
                return RPScoreResult.Cool;
            if (offset < HitWindowFor(RPScoreResult.Fine))
                return RPScoreResult.Fine;
            if (offset < HitWindowFor(RPScoreResult.Safe))
                return RPScoreResult.Safe;
            return RPScoreResult.Sad;
        }

        /// <summary>
        ///     初始化預設物件
        /// </summary>
        public override void InitialDefaultValue()
        {
            ObjectType = RpBaseObjectType.ObjectType.HitObject;
        }
    }
}
