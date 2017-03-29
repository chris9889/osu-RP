using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Printing;
using osu.Framework.Input;
using osu.Game.Modes.Judgements;
using osu.Game.Modes.Objects;
using osu.Game.Modes.RP.KeyManager;
using OpenTK;
using OpenTK.Input;

namespace osu.Game.Modes.RP.Objects.Drawables.Calculator.DrawableDetectPress
{
    /// <summary>
    /// 用來偵測有沒有按下去，還有放開
    /// 用在所有RP物件上面
    /// </summary>
    public class DetectPress : Framework.Graphics.Containers.Container
    {
        //RP物件
        BaseHitObject _baseRPObject;

        //按下去的事件
        public Func<bool> Hit;

        //放開的事件
        public Func<bool> Release;

        /// <summary>
        /// 可以配對的按鍵
        /// </summary>
        protected List<Key> _compareKey;

        //目前按下配對的按鍵
        private Key _nowPressMatchKey = Key.Unknown;

        //目前按下去的按鍵是不是有效的
        private bool _pressValid = false;

        public double PressDownDelayTime = 0;

        public double PressUpDelayTime = 0;

        public bool IsPress
        {
            get { return (_nowPressMatchKey != Key.Unknown); }
        }

        public DetectPress(BaseHitObject baseRpObject, Judgement judgement)
        {
            _baseRPObject = baseRpObject;
            //預先取得那些按鍵按了會有作用
            _compareKey= RpKeyManager.GetListKey(baseRpObject);
        }
       
        /// <summary>
        /// 如果鍵盤有按下去
        /// 如果時間差在 可以接受範圍內就回傳true
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            double pressDelay = Math.Abs(Time.Current - _baseRPObject.StartTime);
            //Hit at the time
            if (pressDelay < _baseRPObject.hit50 && _nowPressMatchKey==Key.Unknown)
            {
                //目前符合的key
                List<Key> pressKeyList = FilterMatchKey(state);

                //如果過濾後發現沒有Key
                if (pressKeyList.Count == 0)
                {
                    return false;
                }
                else
                {
                    PressDownDelayTime = pressDelay;
                    _nowPressMatchKey = pressKeyList[0];
                    _pressValid = true;
                    return Hit?.Invoke() ?? false;
                }
            }  
            else if (false)//如果不在時間點內有符合的按鍵進來，要記錄起來，等放開後release
            {

            }
            return false;
        }

        /// <summary>
        /// 鍵盤放開
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnKeyUp(InputState state, KeyUpEventArgs args)
        {
            double pressDelay = Math.Abs(Time.Current - _baseRPObject.EndTime);
            //Hit at the time
            if (pressDelay < _baseRPObject.hit50 && _nowPressMatchKey != Key.Unknown)
            {
                //目前符合的key
                List<Key> pressKeyList = FilterMatchKey(state);

                //如果過濾後發現沒有Key
                if (pressKeyList.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (Key singleKey in pressKeyList)
                    {
                        if (singleKey == _nowPressMatchKey)
                        {
                            PressUpDelayTime = pressDelay;
                            _nowPressMatchKey = Key.Unknown;
                            return Release?.Invoke() ?? false;
                        }
                    }
                }
            }
            else if(false)
            {
                
            }
            return false;
        }

        /// <summary>
        /// 把跟上一次重複的key過濾掉
        /// </summary>
        /// <returns></returns>
        List<Key> FilterMatchKey(InputState state)
        {
            List<Key> nowKeyStateList = new List<Key>();
            //all
            foreach (Key single in state.Keyboard.Keys)
            {
                if (_compareKey.Contains(single))
                    nowKeyStateList.Add(single);
            }
            return nowKeyStateList;
        }

    }
}
