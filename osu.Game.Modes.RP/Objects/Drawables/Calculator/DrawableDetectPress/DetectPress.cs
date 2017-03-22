using System;
using System.Collections.Generic;
using System.Diagnostics;
using osu.Framework.Input;
using osu.Game.Modes.Judgements;
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

        //判斷
        JudgementInfo _judgement;

        //按下去的事件
        public Func<bool> Hit;
        //放開的事件
        public Func<bool> Release;

        /// <summary>
        /// 可以配對的按鍵
        /// </summary>
        protected List<Key> _compareKey;

        public void SetListKey(List<Key> listkey)
        {
            _compareKey = listkey;
        }

        public DetectPress(BaseHitObject baseRPObject, JudgementInfo judgement)
        {
            _judgement = judgement;
            _baseRPObject = baseRPObject;
            //Masking = true;
            //CornerRadius = DrawSize.X / 2;

           // Anchor = Anchor.Centre;
            //Origin = Anchor.Centre;
        }

        private InputState lastState = new InputState();
       
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
            if (pressDelay > _baseRPObject.hit50 || - pressDelay > _baseRPObject.hit50)
            {
                

                lastState = state;
                return false;
            }
            else
            {
                


                //目前這次的Key
                List<Key> pressKeyList = FilterKey(state);
                string debug_str="";
                foreach (Key single in pressKeyList)
                {
                    debug_str = debug_str + " " + single.ToString();
                }

                Debug.Print(_judgement.TimeOffset.ToString() + " "+ debug_str);

                //如果過濾後發現沒有Key
                if (pressKeyList.Count == 0)
                    return false;

                if(DetectSameKey(pressKeyList)== KeyState.match)
                {
                    //return true;
                    bool value = Hit?.Invoke() ?? false;
                    lastState = state;
                    return true;
                }

               
                lastState = state;
                return false;
            }
        }

        /// <summary>
        /// 鍵盤放開
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnKeyUp(InputState state, KeyUpEventArgs args)
        {

            lastState = state;

            if (_judgement.TimeOffset < - _baseRPObject.hit50)
            {
                return false;
            }
            else
            {
                //return true;
                bool value = Release?.Invoke() ?? false;
                lastState = state;
                Tracking = false;
                return true;
            }
            
        }

        /// <summary>
        /// 把跟上一次重複的key過濾掉
        /// </summary>
        /// <returns></returns>
        List<Key> FilterKey(InputState state)
        {
            List<Key> nowKeyStateList = new List<Key>();
            foreach (Key single in state.Keyboard.Keys)
            {
                nowKeyStateList.Add(single);
            }

            if (lastState.Keyboard != null)
            {
                List<Key> lastKeyStateList = new List<Key>();
                //上次的
                foreach (Key single in lastState.Keyboard.Keys)
                {
                    nowKeyStateList.Add(single);
                }

                //如果兩邊key數量相同，就預先擋掉
                //if (nowKeyStateList.Count == lastKeyStateList.Count)
                //    return new List<Key>();

                List<Key> returnKeyStateList = new List<Key>();
                foreach (Key single in state.Keyboard.Keys)
                {
                    if(!lastKeyStateList.Contains(single))
                        returnKeyStateList.Add(single);
                }

                return returnKeyStateList;
            }

            return nowKeyStateList;
        }

        /// <summary>
        /// 會根據目前RP物件和按下去的按鍵
        /// 去回傳目前物件
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private KeyState DetectSameKey(List<Key> listkey)
        {
            foreach (Key singleKey in listkey)
            {
                if (_compareKey.Contains(singleKey))
                    return KeyState.match;
                    
            }
            return KeyState.notsame;
        }

        

        bool tracking;
        public bool Tracking
        {
            get { return tracking; }
            set
            {
                if (value == tracking) return;
                tracking = value;
            }
        }

        /// <summary>
        /// 按鈕狀態
        /// </summary>
        enum KeyState
        {
            match,//有按下正確的按鍵
            notsame,//這個按鍵是屬於其他物件的
            coco//配對錯誤
        }
        
    }
}
