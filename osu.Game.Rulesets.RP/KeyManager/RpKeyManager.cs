using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.type;
using osu.Game.Rulesets.RP.Saving;
using OpenTK.Input;

namespace osu.Game.Rulesets.RP.KeyManager
{
    /// <summary>
    ///     RP按鍵配置取用
    /// </summary>
    public static class RpKeyManager
    {
        /// <summary>
        ///     取得目前那些按鍵有效
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static List<Key> GetListKey(BaseRpHitObject baseHitObject)
        {
            var output = new List<Key>();
            var divaKeyLayoutConfig = new RpKeyLayoutConfig();
            //取得目前的使用排版
            var config = divaKeyLayoutConfig.GetDefaultLayLayout();

            foreach (var single in config.KeyDictionary)
                if (single.Type == baseHitObject.Shape)
                    if (baseHitObject.Coop == RpBaseHitObjectType.Coop.Both) //如果是通用
                        output.Add(single.Key);
                    else if (baseHitObject.Coop == single.Coop) //或是左右屬性符吁E
                        output.Add(single.Key);


            return output;
        }

        /// <summary>
        ///     取得目前排刁E
        /// </summary>
        /// <returns></returns>
        public static RpKeyLayoutConfig.SingleRpKeyLayoutConfig GetCurrentKeyConfig()
        {
            var divaKeyLayoutConfig = new RpKeyLayoutConfig();
            return divaKeyLayoutConfig.GetDefaultLayLayout();
        }

        /// <summary>
        ///     把目前RP皁E��鍵設定儲存回去
        /// </summary>
        /// <param name="listKey"></param>
        /// <param name="keyLayout"></param>
        /// <param name="settingIndex"></param>
        /// <returns></returns>
        public static bool SeveKeyConfig(List<Key> listKey, RpKeyLayoutConfig.KeyLayout keyLayout, int settingIndex)
        {
            return false;
        }
    }
}
