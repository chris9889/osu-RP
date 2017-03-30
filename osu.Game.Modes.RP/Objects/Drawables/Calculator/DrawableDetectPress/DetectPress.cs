using System;
using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input;
using osu.Game.Modes.Judgements;
using osu.Game.Modes.RP.KeyManager;
using OpenTK.Input;

namespace osu.Game.Modes.RP.Objects.Drawables.Calculator.DrawableDetectPress
{
    /// <summary>
    ///     用來偵測有沒有按下去，還有放開
    ///     用在所有RP物件上面
    /// </summary>
    public class DetectPress : Container
    {
        public bool IsPress
        {
            get { return _nowPressMatchKey != Key.Unknown; }
        }

        //按下去的事件
        public Func<bool> Hit;

        //放開的事件
        public Func<bool> Release;

        public double PressDownDelayTime;

        public double PressUpDelayTime;

        /// <summary>
        ///     可以配對的按鍵
        /// </summary>
        protected List<Key> _compareKey;

        //RP物件
        private readonly BaseHitObject _baseRPObject;

        //目前按下配對的按鍵
        private Key _nowPressMatchKey = Key.Unknown;

        //目前按下去的按鍵是不是有效的
        private bool _pressValid=false;

        public DetectPress(BaseHitObject baseRpObject, Judgement judgement)
        {
            _baseRPObject = baseRpObject;
            //預先取得那些按鍵按了會有作用
            _compareKey = RpKeyManager.GetListKey(baseRpObject);
        }

        /// <summary>
        ///     如果鍵盤有按下去
        ///     如果時間差在 可以接受範圍內就回傳true
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            if (args.Repeat)
                return false;

            var pressDelay = Math.Abs(Time.Current - _baseRPObject.StartTime);

            //Hit at the time
            if (pressDelay < _baseRPObject.hit50 && _nowPressMatchKey == Key.Unknown)
            {
                //目前符合的key
                var pressKeyList = FilterMatchKey(state);

                //如果過濾後發現沒有Key
                if (pressKeyList.Count > 0)
                {
                    PressDownDelayTime = pressDelay;
                    _nowPressMatchKey = pressKeyList[0];
                    _pressValid = true;
                    return Hit?.Invoke() ?? false;
                }
            }
            else if (false) //outside the time
            {
                //目前符合的key
                var pressKeyList = FilterMatchKey(state);

                //如果過濾後發現沒有Key
                if (pressKeyList.Count >= 0)
                    _nowPressMatchKey = pressKeyList[0];;
            }
            return false;
        }

        /// <summary>
        ///     鍵盤放開
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnKeyUp(InputState state, KeyUpEventArgs args)
        {
            var pressDelay = Math.Abs(Time.Current - _baseRPObject.EndTime);
            //Hit at the time
            if (pressDelay < _baseRPObject.hit50 && _nowPressMatchKey != Key.Unknown)
            {
                //目前符合的key
                var pressKeyList = FilterMatchKey(state);

                //如果過濾後發現沒有Key
                if (pressKeyList.Count == 0)
                    return false;
                foreach (var singleKey in pressKeyList)
                    if (singleKey == _nowPressMatchKey)
                    {
                        PressUpDelayTime = pressDelay;
                        _nowPressMatchKey = Key.Unknown;
                        return Release?.Invoke() ?? false;
                    }
            }
            else if (false)
            {

            }
            return false;
        }

        /// <summary>
        ///     把跟上一次重複的key過濾掉
        /// </summary>
        /// <returns></returns>
        private List<Key> FilterMatchKey(InputState state)
        {
            var nowKeyStateList = new List<Key>();
            //all
            foreach (var single in state.Keyboard.Keys)
                if (_compareKey.Contains(single))
                    nowKeyStateList.Add(single);
            return nowKeyStateList;
        }
    }
}
