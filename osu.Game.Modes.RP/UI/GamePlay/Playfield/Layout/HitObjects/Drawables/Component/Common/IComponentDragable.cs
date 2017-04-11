using System;

namespace osu.Game.Modes.RP
{
    public interface IComponentDragable
    {
        /// <summary>
        /// when the object is Drag by mouse and not drag out of the field
        /// </summary>
        void OnGragHold();

        //The Object is dragging and not decide where to place
        void OnGrag();

        //Object that has a place can be place
        void OnDragDecidePlace();

        //Grag release and the object is set
        void DragDown();
    }
}
