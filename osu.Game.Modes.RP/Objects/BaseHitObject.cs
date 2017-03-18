//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.RP.Objects.type;
using System.Collections.Generic;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    /// 所有打擊物件都會繼承這裡
    /// </summary>
    public abstract class BaseHitObject : BaseRpObject
    {
        //判定
        public double hit50 = 150;
        public double hit100 = 120;
        public double hit300 = 100;

        /// <summary>
        /// 是裝在哪個Container裡面
        /// </summary>
        public int ContainerIndex = 0;


        public double EndTime => StartTime;
        public double Duration => EndTime - StartTime;

        /// <summary>
        /// 是在哪一個index上面
        /// </summary>
        public int LayoutIndex = 0;

       

        public BaseHitObject() : base()
        {

        }


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
        /// 初始化預設物件
        /// </summary>
        public override void InitialDefaultValue()
        {
            ObjectType = RpBaseHitObjectType.ObjectType.HitObject;
        }

        /// <summary>
        /// 畫線的順序
        /// </summary>
        public List<BaseHitObject> _drawLinePriority;

        /// <summary>
        /// 設定類型
        /// </summary>
        public RpBaseHitObjectType.Shape Shape = RpBaseHitObjectType.Shape.Circle;

        /// <summary>
        /// 設定類型
        /// </summary>
        public RpBaseHitObjectType.Special Special = RpBaseHitObjectType.Special.Normal;

        /// <summary>
        /// 設定類型，哪一種生成方式
        /// </summary>
        public RpBaseHitObjectType.CurveGenerate CurveGenerate = RpBaseHitObjectType.CurveGenerate.Auto;

        /// <summary>
        /// 設定類型
        /// </summary>
        public RpBaseHitObjectType.Multi Multi = RpBaseHitObjectType.Multi.SingleClick;

        /// <summary>
        /// 設定類型
        /// </summary>
        public RpBaseHitObjectType.Comvert Comvert = RpBaseHitObjectType.Comvert.Original;

        /// <summary>
        /// 用不同落下方式當判定點
        /// </summary>
        public RpBaseHitObjectType.ApproachType ApproachType= RpBaseHitObjectType.ApproachType.flow;
    }
}
