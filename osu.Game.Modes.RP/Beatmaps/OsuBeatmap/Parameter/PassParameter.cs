using osu.Game.Modes.RP.Objects.type;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter
{
    /// <summary>
    /// 轉換時用的暫時參數
    /// </summary>
    class BasePassParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public RpBaseHitObjectType.ObjectType ObjectType = RpBaseHitObjectType.ObjectType.Undefined;

        /// <summary>
        /// 結束時間
        /// </summary>
        public double EndTime;

        /// <summary>
        /// 物件原本座標
        /// </summary>
        public Vector2 StartPosition;
    }

    class ContainerPassParameter : BasePassParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public new RpBaseHitObjectType.ObjectType ObjectType = RpBaseHitObjectType.ObjectType.Container;


    }

    class HitObjectPassParameter : BasePassParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public new RpBaseHitObjectType.ObjectType ObjectType = RpBaseHitObjectType.ObjectType.HitObject;


        /// <summary>
        /// 設定類型
        /// </summary>
        public RpBaseHitObjectType.ObjectType HitObjectType = RpBaseHitObjectType.ObjectType.Click;

       

        /// <summary>
        /// 參考對應的原本物件
        /// </summary>
        public int refrenceNote;

        

        /// <summary>
        /// 物件要從哪邊飄過來?
        /// </summary>
        public Vector2 FlowDirection;

        public Vector2 FlowPosition;

        /// <summary>
        /// 這段combo是不是多個物件
        /// </summary>
        /// <returns></returns>
        public bool IsMultiCombo = false;

        /// <summary>
        /// 這個note 時間點有另外幾個物件?(剩餘
        /// </summary>
        public int MultiRremainNumber;

        /// <summary>
        /// 這段時間點共有幾個物件
        /// </summary>
        public int MultiNumber;

        /// <summary>
        /// 複製
        /// </summary>
        /// <returns></returns>
        public BasePassParameter Clone()
        {
            BasePassParameter returnValue = new BasePassParameter();
            //returnValue.refrenceNote = refrenceNote;
            return returnValue;
        }
    }
}
