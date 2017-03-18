using OpenTK;
using osu.Framework.Graphics.Transforms;
using osu.Game.Modes.RP.Objects.MovingPath;
using osu.Game.Modes.RP.Objects.type;
using osu.Game.Modes.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Beatmaps;
using OpenTK.Graphics;
using SliderCurve = osu.Game.Modes.RP.Objects.MovingPath.SliderCurve;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    /// 目前所有RP物件共通都會出現的
    /// 包括打擊物件和Container(乘載RP物件的地方)
    /// </summary>
    public abstract class BaseRpObject : HitObject
    {
        /// <summary>
        /// Type
        /// </summary>
        public RpBaseHitObjectType.ObjectType ObjectType ;

        //物件出現需要花的時間
        public float TIME_FADEIN = 200;
        //物件在打擊多久前提早出現
        public float TIME_PREEMPT = 1500;
        //打擊過後多久會消失
        public float TIME_FADEOUT = 100;

        public Color4 Colour;

        public virtual double EndTime => StartTime;

        public double Duration => EndTime - StartTime;

        /// <summary>
        /// 移動速度
        /// </summary>
        public double Velocity;

        public float Scale { get; set; } = 1;

        public void SetDefaultsFromBeatmap(Beatmap beatmap)
        {
            //Scale = (1.0f - 0.7f * (beatmap.BeatmapInfo.Difficulty.CircleSize - 5) / 5) / 2;
            Scale = (1.0f - 0.7f * (beatmap.BeatmapInfo.Difficulty.CircleSize - 5) / 5) /4*3;
            //Velocity = 100 / beatmap.BeatLengthAt(StartTime) * beatmap.BeatmapInfo.BaseDifficulty.SliderMultiplier;
            Velocity = 100 / beatmap.SliderVelocityAt(StartTime) * beatmap.BeatmapInfo.Difficulty.SliderMultiplier;

            Scale = 1;
        }

        public BaseRpObject()
        {
            InitialDefaultValue();
        }

        /// <summary>
        /// 初始化預設物件
        /// </summary>
        public virtual void InitialDefaultValue()
        {
            CurveEasingTypes = EasingTypes.InSine;
            ObjectType = RpBaseHitObjectType.ObjectType.Undefined;
        }

        /// <summary>
        /// 移動曲線
        /// </summary>
        public SliderCurve Curve = new SliderCurve()
        {
            ControlPoints = new List<OpenTK.Vector2>(),
            Length = 0,
            CurveType = RpBaseHitObjectType.CurveTypes.Bezier
        };

        /// <summary>
        /// 設定移動軌跡的曲線
        /// </summary>
        public EasingTypes CurveEasingTypes = EasingTypes.None;

        /// <summary>
        /// 特殊曲線佔的百分比(0~1)
        /// </summary>
        public double CurveEasingTypesPrecentage = 0.5;

        /// <summary>
        /// 結束位置
        /// </summary>
        public Vector2 EndPosition => Curve.EndPosition;

        //物件位置
        public Vector2 Position
        {
            get
            {
                return Curve.StartPosition;
            }
            set
            {
                Curve.StartPosition = value;
            }
        }
    }
}
