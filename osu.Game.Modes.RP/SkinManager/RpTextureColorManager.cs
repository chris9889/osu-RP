// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Modes.RP.Objects.type;
using OpenTK.Graphics;

namespace osu.Game.Modes.RP.SkinManager
{
    /// <summary>
    ///     Manage all the Color in the skin that can be adjust in the skin config.
    /// </summary>
    public static class RpTextureColorManager
    {
        /// <summary>
        ///     按鈕顏色
        /// </summary>
        /// <returns></returns>
        public static Color4 GetKeyLayoutButtonShage(RpBaseHitObjectType.Shape type)
        {
            switch (type)
            {
                case RpBaseHitObjectType.Shape.Right:
                    return new Color4(226, 66, 54, 255);
                case RpBaseHitObjectType.Shape.Down:
                    return new Color4(54, 99, 226, 255);
                case RpBaseHitObjectType.Shape.Left:
                    return new Color4(226, 54, 177, 255);
                case RpBaseHitObjectType.Shape.Up:
                    return new Color4(131, 226, 54, 255);
                case RpBaseHitObjectType.Shape.ContainerPress:
                    return new Color4(169, 188, 185, 255);
            }
            return new Color4(255, 255, 255, 255);
        }
    }
}
