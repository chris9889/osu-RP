using OpenTK.Input;
using osu.Game.Modes.RP.Objects.type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static osu.Game.Modes.RP.Saving.RpKeyLayoutConfig.SingleRpKeyLayoutConfig;

namespace osu.Game.Modes.RP.Saving
{
    /// <summary>
    /// 用來儲存有關按鍵設定
    /// </summary>
    [Serializable]
    public partial class RpKeyLayoutConfig
    {
        //目前RP按鍵設置
        public List<SingleRpKeyLayoutConfig> ListKayConfig;
       
        //目前預設使用的index
        private int _defauleIndex = 0;
    }


    /// <summary>
    /// /定義方法
    /// </summary>
    public partial class RpKeyLayoutConfig
    {

        public RpKeyLayoutConfig()
        {
            if (ListKayConfig == null)
            {
                ListKayConfig = new List<SingleRpKeyLayoutConfig>();
                ListKayConfig.Add(CreateDefault10K());
                _defauleIndex =0;
            }
        }

        /// <summary>
        /// 取得目前設定索引
        /// </summary>
        /// <returns></returns>
        public SingleRpKeyLayoutConfig GetDefaultLayLayout()
        {
            return ListKayConfig[DefauleIndex];
        }

        /// <summary>
        /// 取得預設的索引
        /// </summary>
        public int DefauleIndex
        {
            get
            {
                //如果目前裡面是空的
                if (ListKayConfig.Count == 0)
                {
                    ListKayConfig.Add(CreateDefault10K());
                    _defauleIndex = 0;
                }
                //索引>陣列
                if (ListKayConfig.Count < _defauleIndex)
                {
                    _defauleIndex = ListKayConfig.Count - 1;
                }

                return _defauleIndex;
            }
            set
            {
                _defauleIndex = value;

                //如果目前沒有設定
                if (ListKayConfig.Count == 0)
                {
                    ListKayConfig.Add(CreateDefault10K());
                    _defauleIndex = 0;
                }

                //如果大於範圍
                if (ListKayConfig.Count < _defauleIndex)
                {
                    _defauleIndex = ListKayConfig.Count - 1;
                }

                //如果目前沒有範圍
                if (_defauleIndex < 0)
                    _defauleIndex = 0;

            }
        }

        /// <summary>
        /// 建構10K預設
        /// </summary>
        /// <returns></returns>
        private SingleRpKeyLayoutConfig10K CreateDefault10K()
        {
            SingleRpKeyLayoutConfig10K config10K = GenerateDefault10KPriority();
            config10K.KeyDictionary[0].Key = Key.A;
            config10K.KeyDictionary[1].Key = Key.E;
            config10K.KeyDictionary[2].Key = Key.D;
            config10K.KeyDictionary[3].Key = Key.S;
            config10K.KeyDictionary[4].Key = Key.F;//F;
            config10K.KeyDictionary[5].Key = Key.I;
            config10K.KeyDictionary[6].Key = Key.K;
            config10K.KeyDictionary[7].Key = Key.J;
            config10K.KeyDictionary[8].Key = Key.L;// L;
            config10K.KeyDictionary[9].Key = Key.Semicolon;
            return config10K;
        }

        /// <summary>
        /// 建構預設6K
        /// </summary>
        /// <returns></returns>
        private SingleRpKeyLayoutConfig6K CreateDefault6K()
        {
            SingleRpKeyLayoutConfig6K config6K = GenerateDefault6KPriority();
            config6K.KeyDictionary[0].Key = Key.A;
            config6K.KeyDictionary[1].Key = Key.D;
            config6K.KeyDictionary[2].Key = Key.F;
            config6K.KeyDictionary[3].Key = Key.J;
            config6K.KeyDictionary[4].Key = Key.K;
            config6K.KeyDictionary[5].Key = Key.L;
            return config6K;
        }

        /// <summary>
        /// 會先建立預設的優先順序
        /// </summary>
        public SingleRpKeyLayoutConfig10K GenerateDefault10KPriority()
        {
            SingleRpKeyLayoutConfig10K config10K = new SingleRpKeyLayoutConfig10K();
            RpBaseHitObjectType.LeftRight left = RpBaseHitObjectType.LeftRight.LeftOnly;
            RpBaseHitObjectType.LeftRight right = RpBaseHitObjectType.LeftRight.RightOnly;
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.ContainerPress, left, Key.Unknown ,KeyName10K.LeftSlide));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Triangle, left, Key.Unknown, KeyName10K.LeftTriangle));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Cross, left, Key.Unknown, KeyName10K.LeftCross));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Square, left, Key.Unknown, KeyName10K.LeftRectangle));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Circle, left, Key.Unknown, KeyName10K.LeftCircle));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Triangle, right, Key.Unknown, KeyName10K.RightTriangle));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Cross, right, Key.Unknown, KeyName10K.RightCross));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Square, right, Key.Unknown, KeyName10K.RightRectangle));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Circle, right, Key.Unknown, KeyName10K.RightCircle));
            config10K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.ContainerPress, right, Key.Unknown, KeyName10K.RightSlide));
            return config10K;
        }

        /// <summary>
        /// 會先建立預設的優先順序
        /// </summary>
        public SingleRpKeyLayoutConfig6K GenerateDefault6KPriority()
        {
            SingleRpKeyLayoutConfig6K config6K = new SingleRpKeyLayoutConfig6K();
            RpBaseHitObjectType.LeftRight both = RpBaseHitObjectType.LeftRight.Both;
            config6K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.ContainerPress, both, Key.Unknown, KeyName6K.LeftSlide));
            config6K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Triangle, both, Key.Unknown, KeyName6K.Triangle));
            config6K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Square, both, Key.Unknown, KeyName6K.Square));
            config6K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Cross, both, Key.Unknown, KeyName6K.Cross));
            config6K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.Circle, both, Key.Unknown, KeyName6K.Circle));
            config6K.KeyDictionary.Add( new SingleKey(RpBaseHitObjectType.Shape.ContainerPress, both, Key.Unknown, KeyName6K.RightSlide));
            return config6K;
        }
    }

    /// <summary>
    /// 定義物件
    /// </summary>
    public partial class RpKeyLayoutConfig
    {
        /// <summary>
        /// 按鍵配置設定，目前是6K還是10K
        /// </summary>
        public enum KeyLayout
        {
            Kay_NotConfig,
            Key_10K,
            Key_6K,
        }

        /// <summary>
        /// 其中一組Key Layout設置
        /// </summary>
        public class SingleRpKeyLayoutConfig
        {
            public KeyLayout KeyLayout = KeyLayout.Kay_NotConfig;
            public List<SingleKey> KeyDictionary = new List<SingleKey>();
            public String KeyLayoutName;

        }

        /// <summary>
        /// 10K設置
        /// </summary>
        public class SingleRpKeyLayoutConfig10K : SingleRpKeyLayoutConfig
        {
            public new KeyLayout KeyLayout = KeyLayout.Key_10K;
           
        }

        /// <summary>
        /// 6K設置
        /// </summary>
        public class SingleRpKeyLayoutConfig6K : SingleRpKeyLayoutConfig
        {
            public new KeyLayout KeyLayout = KeyLayout.Key_6K;
        }

        /// <summary>
        /// 
        /// </summary>
        public class SingleKey
        {
            public SingleKey(RpBaseHitObjectType.Shape type, RpBaseHitObjectType.LeftRight leftRight, Key key, string name)
            {
                Key = key;
                LeftRight = leftRight;
                Name = name;
                Type = type;
            }
            public Key Key;
            public string Name;
            public RpBaseHitObjectType.Shape Type;
            public RpBaseHitObjectType.LeftRight LeftRight;
        }

        /// <summary>
        /// 按鍵名稱
        /// </summary>
        public class KeyName
        {
            //按鍵設定
            public static string LeftSlide = "LeftSlide";
            public static string RightSlide = "RightSlide";
        }

        /// <summary>
        /// 按鍵名稱
        /// </summary>
        public class KeyName10K : KeyName
        {
            public static string LeftTriangle= "LeftTriangle";
            public static string LeftCross = "LeftCross";
            public static string LeftRectangle;
            public static string LeftCircle;

            public static string RightTriangle;
            public static string RightCross;
            public static string RightRectangle;
            public static string RightCircle;
        }

        /// <summary>
        /// 按鍵名稱
        /// </summary>
        public class KeyName6K : KeyName
        {
            public static string Triangle;
            public static string Cross;
            public static string Square;
            public static string Circle;
        }

    }
}
