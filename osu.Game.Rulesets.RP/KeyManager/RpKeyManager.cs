// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects;
using OpenTK.Input;

namespace osu.Game.Rulesets.RP.KeyManager
{
    /// <summary>
    /// use to get which key is vaild for eaac RP Hitable Object
    /// </summary>
    public static class RpKeyManager
    {
        //get valid key list by RpHitableObject
        public static List<Key> GetListKey(BaseRpHitableObject baseHitObject)
        {
            var output = new List<Key>();
            var rpKeyLayoutConfig = new RpKeyLayoutConfig();

            //get now key config
            var config = rpKeyLayoutConfig.GetDefaultLayLayout();

            foreach (var single in config.KeyDictionary)
                if (single.Type == baseHitObject.Shape)
                    if (baseHitObject.Coop == Coop.Both) //如果是通用
                        output.Add(single.Key);
                    else if (baseHitObject.Coop == single.Coop) //或是左右屬性符吁E
                        output.Add(single.Key);


            return output;
        }

        //get 10K or 6K key config ?
        public static RpKeyLayoutConfig.SingleRpKeyLayoutConfig GetCurrentKeyConfig()
        {
            var rpKeyLayoutConfig = new RpKeyLayoutConfig();
            return rpKeyLayoutConfig.GetDefaultLayLayout();
        }

        //save key config to config file
        //TODO : will be merge to config manager ?
        public static bool SeveKeyConfig(List<Key> listKey, RpKeyLayoutConfig.KeyLayout keyLayout, int settingIndex)
        {
            return false;
        }
    }
}
