using System.Collections.Generic;
using System.ComponentModel;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.Attribute;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     目前所有RP物件共通都會出現的
    ///     包括打擊物件和Container(乘載RP物件的地方)
    /// </summary>
    public abstract class BaseRpObject : HitObject, IHasPosition
    {
        //this Object is Editable
        public bool Editable = false;

        //List attributer
        public BindingList<BaseRpObjectAttribute> ListAttrobutes=new BindingList<BaseRpObjectAttribute>();

        //EndTime
        public virtual double EndTime
        {
            get { return StartTime; }
            set { }
        }

        //Duration
        public virtual double Duration => EndTime - StartTime;

        public float X => Position.X;

        public float Y => Position.Y;
        //position
        public Vector2 Position { get; set; }

        //EndPosition
        public virtual Vector2 EndPosition => Position;

        //Object type
        public RpBaseObjectType.ObjectType ObjectType;

        //before startTime
        public float PreemptTime = 1500;

        public float FadeSpeedMultiple = 1;

        //Fade Out time after PreemptTime
        public virtual float FadeInTime => 200 * FadeSpeedMultiple;
        
        //Fade Out time after EndTime 
        public virtual float FadeOutTime => 300 * FadeSpeedMultiple;

        //Color
        public Color4 Colour;

        //Velocity
        public double Velocity;

        //設定移動軌跡的曲線 will be remove
        public EasingTypes CurveEasingTypes = EasingTypes.None;

        // 特殊曲線佔的百分比(0~1) will be remove
        public double CurveEasingTypesPrecentage = 0.5;

        //scale
        public float Scale = 1;

        /// <summary>
        ///     移動曲線
        /// </summary>
        public MovingPath.SliderCurve Curve = new MovingPath.SliderCurve
        {
            ControlPoints = new List<Vector2>(),
            Length = 0,
            CurveType = RpBaseObjectType.CurveTypes.Bezier
        };

        //Construct
        public BaseRpObject()
        {
            InitialDefaultValue();
        }

        /// <summary>
        ///     初始化預設物件
        /// </summary>
        public virtual void InitialDefaultValue()
        {
            CurveEasingTypes = EasingTypes.InSine;
            ObjectType = RpBaseObjectType.ObjectType.Undefined;
            Scale = 1;
        }

       
    }
}
