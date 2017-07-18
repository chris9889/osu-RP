using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using OpenTK.Input;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.DrawableDetectPress
{
    /// <summary>
    ///     it use to report press and release event
    /// </summary>
    public class DetectPress : Container
    {
        public bool IsPress
        {
            get { return _nowPressMatchKey != Key.Unknown; }
        }

        //Hit event
        public Func<bool> Hit;

        //release event
        public Func<bool> Release;

        public double PressDownDelayTime;

        public double PressUpDelayTime;

        /// <summary>
        ///     list compare ksy
        /// </summary>
        protected List<Key> _compareKey;

        //RP HitableObject
        private readonly BaseRpHitableObject _baseRPObject;

        //now Press Key
        private Key _nowPressMatchKey = Key.Unknown;

        //目前按下去皁E��鍵是不是有效皁E
        private bool _pressValid;

        public DetectPress(BaseRpHitableObject baseRpObject, RpJudgement judgement)
        {
            _baseRPObject = baseRpObject;
            //預�E取得那些按鍵按亁E��有作用
            _compareKey = RpKeyManager.GetListKey(baseRpObject);

            Children = new Drawable[]
            {
            };
        }

        /// <summary>
        ///     如果鍵盤有按下去
        ///     如果時間差在 可以接受篁E��內就回傳true
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
                    _nowPressMatchKey = pressKeyList[0];
                ;
            }
            return false;
        }

        /// <summary>
        ///     鍵盤放閁E
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
        ///     把跟上一次重褁E��key過濾掁E
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
