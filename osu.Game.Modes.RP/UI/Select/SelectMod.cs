using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Modes.RP.Mods;
using osu.Game.Modes.Mods;

namespace osu.Game.Modes.RP.UI.Select
{
    /// <summary>
    /// 目前選擇模式
    /// </summary>
    class SelectMod : IEnumerable<Mod>
    {
        ModType _type;

        public SelectMod(ModType type)
        {
            _type = type;
        }

        IEnumerator<Mod> IEnumerable<Mod>.GetEnumerator()
        {
            switch (_type)
            {
                case ModType.DifficultyReduction:
                    yield return new RpModEasy();
                    yield return new RpModNoFail();
                    yield return new RpModHalfTime();

                    break;
                case ModType.DifficultyIncrease:
                    yield return new RpModHardRock();
                    yield return new MultiMod
                    {
                        Mods = new Mod[]
                            {
                                new RpModSuddenDeath(),
                                new RpModPerfect(),
                            },
                    };
                    yield return new MultiMod
                    {
                        Mods = new Mod[]
                           {
                                new RpModDoubleTime(),
                                new RpModNightcore(),
                           },
                    };
                    yield return new RpModHidden();
                    yield return new RpModFlashlight();
                    break;
                case ModType.Special:
                    //yield return new RpModRelax();
                    yield return new RpModContainerHitObjectPressOut();
                    yield return new RpModShapeHitObjectCoco();
                    yield return new RpModContainerHitObjectCoco();
                    yield return new MultiMod
                    {
                        Mods = new Mod[]
                            {
                                new RpModAutoplay(),
                                new RpModRelax(),
                            },
                    };
                    break;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
