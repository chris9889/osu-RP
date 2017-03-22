// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Modes.RP.Objects.type;
using OpenTK;

namespace osu.Game.Modes.RP.SkinManager
{
    /// <summary>
    /// ManageAll the Color in the 
    /// </summary>
    public static class SkinColorManager
    {
        /// <summary>
        /// 按鈕顏色
        /// </summary>
        /// <returns></returns>
        public static Vector4 GetKeyLayoutButtonShage(RpBaseHitObjectType.Shape type)
        {
            switch (type)
            {
                case RpBaseHitObjectType.Shape.Right:
                    return new Vector4(255, 255, 255, 255);
                case RpBaseHitObjectType.Shape.Down:
                    return new Vector4(255, 255, 255, 255);
                case RpBaseHitObjectType.Shape.Left:
                    return new Vector4(255, 255, 255, 255);
                case RpBaseHitObjectType.Shape.Up:
                    return new Vector4(255, 255, 255, 255);
                case RpBaseHitObjectType.Shape.ContainerPress:
                    return new Vector4(255, 255, 255, 255);
            }
            return new Vector4(255, 255, 255, 255);
        }
    }
}