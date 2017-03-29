using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Transforms;
using osu.Game.Beatmaps;
using osu.Game.Modes.Objects;
using osu.Game.Modes.RP.Objects.type;
using OpenTK;
using OpenTK.Graphics;
using SliderCurve = osu.Game.Modes.RP.Objects.MovingPath.SliderCurve;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    ///     目前所有RP物件共通都會出現的
    ///     包括打擊物件和Container(乘載RP物件的地方)
    /// </summary>
    public abstract class BaseRpObject : HitObject
    {
        public virtual double EndTime => StartTime;

        public virtual double Duration => EndTime - StartTime;

        /// <summary>
        ///     結束位置
        /// </summary>
        public Vector2 EndPosition => Curve.EndPosition;

        /// <summary>
        ///     Type
        /// </summary>
        public RpBaseObjectType.ObjectType ObjectType;

        //物件出現需要花的時間
        public float TIME_FADEIN = 200;
        //物件在打擊多久前提早出現
        public float TIME_PREEMPT = 1500;
        //打擊過後多久會消失
        public float TIME_FADEOUT = 100;

        public Color4 Colour;

        /// <summary>
        ///     移動速度
        /// </summary>
        public double Velocity;

        /// <summary>
        ///     移動曲線
        /// </summary>
        public SliderCurve Curve = new SliderCurve
        {
            ControlPoints = new List<Vector2>(),
            Length = 0,
            CurveType = RpBaseObjectType.CurveTypes.Bezier
        };

        /// <summary>
        ///     設定移動軌跡的曲線
        /// </summary>
        public EasingTypes CurveEasingTypes = EasingTypes.None;

        /// <summary>
        ///     特殊曲線佔的百分比(0~1)
        /// </summary>
        public double CurveEasingTypesPrecentage = 0.5;

        public float Scale { get; set; } = 1;

        //物件位置
        public Vector2 Position
        {
            get { return Curve.StartPosition; }
            set { Curve.StartPosition = value; }
        }

        public BaseRpObject()
        {
            InitialDefaultValue();
        }

        public void SetDefaultsFromBeatmap(Beatmap beatmap)
        {
            //Scale = (1.0f - 0.7f * (beatmap.BeatmapInfo.Difficulty.CircleSize - 5) / 5) / 2;
            Scale = (1.0f - 0.7f * (beatmap.BeatmapInfo.Difficulty.CircleSize - 5) / 5) / 4 * 3;
            //Velocity = 100 / beatmap.BeatLengthAt(StartTime) * beatmap.BeatmapInfo.BaseDifficulty.SliderMultiplier;
            //Velocity = 100 / beatmap.SliderVelocityAt(StartTime) * beatmap.BeatmapInfo.Difficulty.SliderMultiplier * 1.5;

            Scale = 1;
        }

        /// <summary>
        ///     初始化預設物件
        /// </summary>
        public virtual void InitialDefaultValue()
        {
            CurveEasingTypes = EasingTypes.InSine;
            ObjectType = RpBaseObjectType.ObjectType.Undefined;
        }
    }
}
