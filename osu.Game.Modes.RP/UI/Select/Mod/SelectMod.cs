using System;
using System.Collections;
using System.Collections.Generic;
using osu.Game.Modes.Mods;
using osu.Game.Modes.RP.Mods;

namespace osu.Game.Modes.RP.UI.Select.Mod
{
    /// <summary>
    ///     not available mod for selection 
    /// </summary>
    internal class SelectMod : IEnumerable<Modes.Mods.Mod>
    {
        private readonly ModType _type;

        public SelectMod(ModType type)
        {
            _type = type;
        }

        IEnumerator<Modes.Mods.Mod> IEnumerable<Modes.Mods.Mod>.GetEnumerator()
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
                        Mods = new Modes.Mods.Mod[]
                        {
                            new RpModSuddenDeath(),
                            new RpModPerfect()
                        }
                    };
                    yield return new MultiMod
                    {
                        Mods = new Modes.Mods.Mod[]
                        {
                            new RpModDoubleTime(),
                            new RpModNightcore()
                        }
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
                        Mods = new Modes.Mods.Mod[]
                        {
                            new RpModAutoplay(),
                            new RpModRelax()
                        }
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
