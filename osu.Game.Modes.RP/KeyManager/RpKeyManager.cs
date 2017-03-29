using System.Collections.Generic;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Saving;
using OpenTK.Input;
using static osu.Game.Modes.RP.Saving.RpKeyLayoutConfig;

namespace osu.Game.Modes.RP.KeyManager
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
        public static List<Key> GetListKey(BaseHitObject baseHitObject)
        {
            var output = new List<Key>();
            var divaKeyLayoutConfig = new RpKeyLayoutConfig();
            //取得目前的使用排版
            var config = divaKeyLayoutConfig.GetDefaultLayLayout();

            foreach (var single in config.KeyDictionary)
                if (single.Type == baseHitObject.Shape)
                    output.Add(single.Key);

            return output;
        }

        /// <summary>
        ///     取得目前排列
        /// </summary>
        /// <returns></returns>
        public static SingleRpKeyLayoutConfig GetCurrentKeyConfig()
        {
            var divaKeyLayoutConfig = new RpKeyLayoutConfig();
            return divaKeyLayoutConfig.GetDefaultLayLayout();
        }

        /// <summary>
        ///     把目前RP的按鍵設定儲存回去
        /// </summary>
        /// <param name="listKey"></param>
        /// <param name="keyLayout"></param>
        /// <param name="settingIndex"></param>
        /// <returns></returns>
        public static bool SeveKeyConfig(List<Key> listKey, KeyLayout keyLayout, int settingIndex)
        {
            return false;
        }
    }
}
