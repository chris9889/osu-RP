using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Screens.Play;
using static osu.Game.Modes.RP.Saving.RpKeyLayoutConfig;
using static osu.Game.Modes.RP.UI.GamePlay.KeyCounter.RpKeyCounterKeyboard;

namespace osu.Game.Modes.RP.UI.GamePlay.KeyCounter
{
    /// <summary>
    ///     RP專用的計數器
    /// </summary>
    internal class RpKeyCounterCollection : KeyCounterCollection
    {
        public List<KeyCounterKeyboard> ListKey = new List<KeyCounterKeyboard>();

        private readonly SingleRpKeyLayoutConfig _singleLayout;

        public RpKeyCounterCollection(SingleRpKeyLayoutConfig singleLayout)
        {
            _singleLayout = singleLayout;
            Direction = FillDirection.Horizontal;
            AutoSizeAxes = Axes.Both;
            GeneratorKey();
        }

        /// <summary>
        ///     產生按鍵出來
        /// </summary>
        private void GeneratorKey()
        {
            for (var i = 0; i < _singleLayout.KeyDictionary.Count; i++)
            {
                var rpKeyCounterKeyboard = new RpKeyCounterKeyboard(_singleLayout.KeyDictionary[i].Key.ToString(), _singleLayout.KeyDictionary[i], SingleKeyLayout.KeyIcon_Count);
                //增加有
                Add(rpKeyCounterKeyboard);
                ListKey.Add(rpKeyCounterKeyboard);
            }
        }
    }
}
