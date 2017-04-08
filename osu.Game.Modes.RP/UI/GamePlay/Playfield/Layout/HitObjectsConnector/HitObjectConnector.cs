using System.Collections.Generic;
using System.Linq;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using OpenTK;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectsConnector
{
    /// <summary>
    ///     用來連接物件的線
    /// </summary>
    internal class HitObjectConnector : ConnectionRenderer<DrawableBaseHitObject>
    {
        /// <summary>
        ///     Determines how much space there is between points.
        /// </summary>
        public int PointDistance
        {
            get { return pointDistance; }
            set
            {
                if (pointDistance == value) return;
                pointDistance = value;
                update();
            }
        }

        /// <summary>
        ///     Follow points to the next hitobject start appearing for this many milliseconds before an hitobject's end time.
        /// </summary>
        public int PreEmpt
        {
            get { return preEmpt; }
            set
            {
                if (preEmpt == value) return;
                preEmpt = value;
                update();
            }
        }

        public override IEnumerable<DrawableBaseHitObject> HitObjects
        {
            get { return hitObjects; }
            set
            {
                hitObjects = value;
                update();
            }
        }

        /// <summary>
        /// </summary>
        private int pointDistance = 32;

        /// <summary>
        ///     will scan when the beatmap converted Finish
        ///     add all the same time's HitObject's Tuple will place in there
        /// </summary>
        private readonly List<List<DrawableBaseHitObject>> ListTuple = new List<List<DrawableBaseHitObject>>();

        private int preEmpt = 800;

        private IEnumerable<DrawableBaseHitObject> hitObjects;

        /// <summary>
        ///     Add all the same time's HitObject's Tuple will place in there
        /// </summary>
        public override void ScanSameTuple()
        {
            DrawableBaseHitObject lastObjectTime = null;
            ListTuple.Clear();

            foreach (var currHitObject in hitObjects)
            {
                if (lastObjectTime != null && currHitObject.HitObject.StartTime == lastObjectTime.HitObject.StartTime)
                {
                    if (ListTuple.Count > 0 && ListTuple[ListTuple.Count - 1][0].HitObject.StartTime == lastObjectTime.HitObject.StartTime) //exist tuple
                    {
                        ListTuple[ListTuple.Count - 1].Add(currHitObject);
                    }
                    else //new tuple
                    {
                        var sligleTuple = new List<DrawableBaseHitObject>();
                        sligleTuple.Add(lastObjectTime);
                        sligleTuple.Add(currHitObject);
                        ListTuple.Add(sligleTuple);
                    }
                }
                lastObjectTime = currHitObject;
            }

            update();
        }


        /// <summary>
        ///     Find the same time HitObject
        ///     ///
        /// </summary>
        private void update()
        {
            Clear();
            if (hitObjects == null)
                return;

            for (var i = 0; i < ListTuple.Count(); i++)
            {
                var listPosition = new List<Vector2>();
                for (var j = 0; j < ListTuple[i].Count; j++)
                    listPosition.Add(ListTuple[i][j].Position);
                var startTime = ListTuple[i][0].HitObject.StartTime - ListTuple[i][0].TIME_PREEMPT;
                var endTime = ListTuple[i][0].HitObject.StartTime;
                AddLine(listPosition, startTime, endTime);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        private void AddLine(List<Vector2> listPositoin, double startTime, double endTime)
        {
            var rpHitMulitpleObjectConnectionLine = new RpHitMulitpleObjectConnectionLine();
            rpHitMulitpleObjectConnectionLine.SetListLine(listPositoin);
            rpHitMulitpleObjectConnectionLine.StartTime = startTime;
            rpHitMulitpleObjectConnectionLine.EndTime = endTime;
            Add(rpHitMulitpleObjectConnectionLine);
        }
    }
}
