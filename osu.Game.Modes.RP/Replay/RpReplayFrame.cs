// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Modes.Replays;
using osu.Game.Modes.RP.KeyManager;
using osu.Game.Modes.RP.Saving;
using OpenTK.Input;

namespace osu.Game.Modes.RP.Replay
{
    /// <summary>
    /// 要實作key的部分
    /// </summary>
    public class RpReplayFrame : ReplayFrame
    {
        /// <summary>
        /// list keys
        /// </summary>
        private List<Key> _listPressKeys = new List<Key>();

        /// <summary>
        /// list keys
        /// </summary>
        public List<Key> ListPressKeys
        {
            get { return _listPressKeys; }
            set { _listPressKeys = value; }
        }

        public RpReplayFrame(double time, float posX, float posY, ReplayButtonState buttonState) : base(time, posX, posY, buttonState)
        {
            //Convert position to keys;
            _listPressKeys = convertMouseAnixXToKeyList((int)MouseX);
        }

        /// <summary>
        /// use this to add the frame
        /// </summary>
        /// <param name="time"></param>
        /// <param name="listPressKeys"></param>
        /// <param name="posY"></param>
        /// <param name="buttonState"></param>
        public RpReplayFrame(double time, List<Key> listPressKeys, float posY, ReplayButtonState buttonState) : base(time, 0, posY, buttonState)
        {
            //Convert position to keys;
            _listPressKeys = listPressKeys;
        }

        public RpReplayFrame(double time, Key key, float posY, ReplayButtonState buttonState) : base(time, 0, posY, buttonState)
        {
            _listPressKeys.Clear();
            _listPressKeys.Add(key);
        }

        /// <summary>
        /// Convert mouse position To key list
        /// </summary>
        /// <returns></returns>
        private List<Key> convertMouseAnixXToKeyList(int positionX)
        {
            List<Key> listKey = new List<Key>();
            if (positionX > 0)
            {
                RpKeyLayoutConfig.SingleRpKeyLayoutConfig currentConfig = RpKeyManager.GetCurrentKeyConfig();
                for (int i = 0; i < 10; i++)
                {
                    if (Math.Ceiling(positionX / Math.Pow(2, i)) % 2 == 1)
                    {
                        listKey.Add(currentConfig.KeyDictionary[i].Key);
                    }
                }
            }
            return listKey;
        }

        /// <summary>
        /// convert list Keys to mouse position
        /// </summary>
        /// <returns></returns>
        public int ConvertRpKeysToMouseAnixX(List<Key> listStorageKeys)
        {
            RpKeyLayoutConfig.SingleRpKeyLayoutConfig currentConfig = RpKeyManager.GetCurrentKeyConfig();
            int returnValue = 0;
            for (int i = 0; i < currentConfig.KeyDictionary.Count; i++)
            {
                if (listStorageKeys.Contains(currentConfig.KeyDictionary[i].Key))
                {
                    returnValue = returnValue + (int)Math.Pow(2, i);
                }
            }
            return returnValue;
        }

        public override string ToString()
        {
            MouseX = ConvertRpKeysToMouseAnixX(_listPressKeys);
            return base.ToString();
        }
    }
}