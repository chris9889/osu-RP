//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Audio;
using osu.Game.Modes.RP.Objects.type;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using osu.Game.Modes.Objects.Types;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    ///     all the hittable object will inherit it
    /// </summary>
    public abstract class BaseRpHitObject : BaseRpObject , IHasPosition
    {
        public override double EndTime => StartTime;

        public override double Duration => EndTime - StartTime;

        //Judge the point
        public double hit50 = 200;
        public double hit100 = 180;
        public double hit300 = 160;

        /// <summary>
        ///     the index of container ,will mapping on  HitRanderer
        /// </summary>
        public int ContainerIndex = 0;

        /// <summary>
        ///     the layout fo the index ,will mapping on  HitRanderer
        /// </summary>
        public int LayoutIndex = 0;

        /// <summary>
        ///     if mult ,set the draw line priority
        /// </summary>
        public int DrawLinePriority = 0;

        /// <summary>
        ///     set the shape type
        /// </summary>
        public RpBaseHitObjectType.Shape Shape = RpBaseHitObjectType.Shape.Right;

        /// <summary>
        ///     normal or special
        /// </summary>
        public RpBaseObjectType.Special Special = RpBaseObjectType.Special.Normal;

        /// <summary>
        ///     if converted for osu!beatmap,set to auto
        /// </summary>
        public RpBaseObjectType.CurveGenerate CurveGenerate = RpBaseObjectType.CurveGenerate.Auto;

        /// <summary>
        ///     sligle or multi
        /// </summary>
        public RpBaseHitObjectType.Multi Multi = RpBaseHitObjectType.Multi.SingleClick;

        /// <summary>
        ///     co-op or not
        /// </summary>
        public RpBaseHitObjectType.Coop Coop = RpBaseHitObjectType.Coop.Both;

        /// <summary>
        ///     if converted for osu!beatmap,set to Convert
        /// </summary>
        public RpBaseObjectType.Convert Convert = RpBaseObjectType.Convert.Original;

        /// <summary>
        ///     用不同落下方式當判定點
        /// </summary>
        public RpBaseHitObjectType.ApproachType ApproachType = RpBaseHitObjectType.ApproachType.ApproachCircle;

        public BaseRpHitObject()
        {
            Samples.Add(
                new SampleInfo
                {
                    Bank = "whistle",
                    Name = "soft"
                }
            );
        }

        /// <summary>
        ///     討延遲時間用
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public double HitWindowFor(RpScoreResult result)
        {
            switch (result)
            {
                default:
                    return 300;
                case RpScoreResult.Safe:
                    return 150;
                case RpScoreResult.Fine:
                    return 80;
                case RpScoreResult.Cool:
                    return 30;
            }
        }

        public RpScoreResult ScoreResultForOffset(double offset)
        {
            if (offset < HitWindowFor(RpScoreResult.Cool))
                return RpScoreResult.Cool;
            if (offset < HitWindowFor(RpScoreResult.Fine))
                return RpScoreResult.Fine;
            if (offset < HitWindowFor(RpScoreResult.Safe))
                return RpScoreResult.Safe;
            return RpScoreResult.Sad;
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
