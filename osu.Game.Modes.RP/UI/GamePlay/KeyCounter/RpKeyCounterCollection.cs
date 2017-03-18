using OpenTK.Input;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Screens.Play;
using static osu.Game.Modes.RP.Saving.RpKeyLayoutConfig;
using static osu.Game.Modes.RP.UI.GamePlay.KeyCounter.RpKeyCounterKeyboard;

namespace osu.Game.Modes.RP.UI.GamePlay.KeyCounter
{
    /// <summary>
    /// RP專用的計數器
    /// </summary>
    class RpKeyCounterCollection : Screens.Play.KeyCounterCollection
    {
        public List<KeyCounterKeyboard> ListKey = new List<KeyCounterKeyboard>();

        SingleRpKeyLayoutConfig _singleLayout;

        public RpKeyCounterCollection(SingleRpKeyLayoutConfig singleLayout)
        {
            _singleLayout = singleLayout;
            Direction = FillDirection.Horizontal;
            AutoSizeAxes = Axes.Both;
            GeneratorKey();
        }

        /// <summary>
        /// 產生按鍵出來
        /// </summary>
        private void GeneratorKey()
        {
            for (int i = 0; i < _singleLayout.KeyDictionary.Count; i++)
            {
                RpKeyCounterKeyboard rpKeyCounterKeyboard = new RpKeyCounterKeyboard(_singleLayout.KeyDictionary[i].Key.ToString(), _singleLayout.KeyDictionary[i], SingleKeyLayout.KeyIcon_Count);
                //增加有
                this.Add(rpKeyCounterKeyboard);
                ListKey.Add(rpKeyCounterKeyboard);
            }
        }

        
    }
}
