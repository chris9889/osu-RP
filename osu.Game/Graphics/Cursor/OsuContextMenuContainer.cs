// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics.Cursor;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Graphics.Cursor
{
    public class OsuContextMenuContainer : ContextMenuContainer
    {
        protected override ContextMenu<ContextMenuItem> CreateContextMenu() => new OsuContextMenu<ContextMenuItem>();
<<<<<<< HEAD

        public OsuContextMenuContainer(CursorContainer cursor) //: base(cursor)
        {
        }
=======
>>>>>>> 621a4e892ac7f224dc5da6ad2ad18f1ef41342a9
    }
}