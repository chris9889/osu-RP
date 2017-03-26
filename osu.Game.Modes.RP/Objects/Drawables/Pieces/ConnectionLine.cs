// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Component;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Pieces
{
    /// <summary>
    /// the line that for connection two Vector
    /// </summary>
    class ConnectionLine : Slider
    {
        public Vector2 StartPosition;

        public Vector2 EndPosition;

        /// <summary>
        /// 更新位置，
        /// </summary>
        public void UpdateConnectionLine()
        {
            List<Vector2> listPosition = new List<Vector2>();
            listPosition.Add(StartPosition);
            listPosition.Add(EndPosition);
            SetRange(listPosition);
        }
    }
}