using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Framework.Graphics;
using osu.Game.Modes.Objects.Types;
using osu.Game.Modes.RP.Objects;
using OpenTK;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectConnector
{
    /// <summary>
    /// 用來連接物件的線
    /// </summary>
    class HitObjectConnector : ConnectionRenderer<BaseHitObject>
    {

        /// <summary>
        /// 
        /// </summary>
        private int pointDistance = 32;

        /// <summary>
        /// will scan when the beatmap converted Finish
        /// add all the same time's HitObject's Tuple will place in there
        /// </summary>
        private List<List<BaseHitObject>> ListTuple = new List<List<BaseHitObject>>();

        /// <summary>
        /// Determines how much space there is between points.
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

        private int preEmpt = 800;

        /// <summary>
        /// Follow points to the next hitobject start appearing for this many milliseconds before an hitobject's end time.
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

        private IEnumerable<BaseHitObject> hitObjects;
        public override IEnumerable<BaseHitObject> HitObjects
        {
            get { return hitObjects; }
            set
            {
                hitObjects = value;
                update();
            }
        }

        /// <summary>
        /// Add all the same time's HitObject's Tuple will place in there
        /// </summary>
        public override void ScanSameTuple()
        {
            BaseHitObject lastObjectTime = null;
            ListTuple.Clear();

            foreach (var currHitObject in hitObjects)
            {
                if (lastObjectTime!=null && currHitObject.StartTime == lastObjectTime.StartTime)
                {
                    if (ListTuple.Count > 0 && ListTuple[ListTuple.Count - 1][0].StartTime == lastObjectTime.StartTime)//exist tuple
                    {
                        ListTuple[ListTuple.Count - 1].Add(currHitObject);
                    }
                    else//new tuple
                    {
                        List<BaseHitObject> sligleTuple = new List<BaseHitObject>();
                        sligleTuple.Add(lastObjectTime);
                        sligleTuple.Add(currHitObject);
                        ListTuple.Add(sligleTuple);

                    }
                }
                else
                {
                    
                }
                lastObjectTime = currHitObject;
            }

            update();
        }


        /// <summary>
        /// Find the same time HitObject
        ///         
        /// /// </summary>
        private void update()
        {
            Clear();
            if (hitObjects == null)
                return;

            for(int i=0;i< ListTuple.Count();i++)
            {
                List<Vector2> listPosition = new List<Vector2>();
                for (int j = 0; j < ListTuple[i].Count; j++)
                {
                    listPosition.Add(ListTuple[i][j].Position);
                }
                double startTime = ListTuple[i][0].StartTime - ListTuple[i][0].TIME_PREEMPT;
                double endTime = ListTuple[i][0].StartTime;
                AddLine(listPosition, startTime, endTime);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        void AddLine(List<Vector2> listPositoin,Double startTime,Double endTime)
        {
            RpHitMulitpleObjectConnectionLine rpHitMulitpleObjectConnectionLine = new RpHitMulitpleObjectConnectionLine();
            rpHitMulitpleObjectConnectionLine.SetListLine(listPositoin);
            rpHitMulitpleObjectConnectionLine.StartTime = startTime;
            rpHitMulitpleObjectConnectionLine.EndTime = endTime;
            this.Add(rpHitMulitpleObjectConnectionLine);
        }

        void UpdateBackup()
        {
            Clear();
            if (hitObjects == null)
                return;

            BaseRpObject prevHitObject = null;
            foreach (var currHitObject in hitObjects)
            {
                //if (prevHitObject != null && !currHitObject.NewCombo && !(prevHitObject is ObjectContainer) )//&& !(currHitObject is ObjectContainer))
                if (prevHitObject != null && !(prevHitObject is ObjectContainer))//&& !(currHitObject is ObjectContainer))
                {
                    Vector2 startPosition = prevHitObject.Position;
                    Vector2 endPosition = currHitObject.Position;
                    double startTime = prevHitObject.EndTime;
                    double endTime = currHitObject.StartTime;

                    Vector2 distanceVector = endPosition - startPosition;
                    int distance = (int)distanceVector.Length;
                    float rotation = (float)Math.Atan2(distanceVector.Y, distanceVector.X);
                    double duration = endTime - startTime;

                    for (int d = (int)(PointDistance * 1.5); d < distance - PointDistance; d += PointDistance)
                    {
                        float fraction = ((float)d / distance);
                        Vector2 pointStartPosition = startPosition + (fraction - 0.1f) * distanceVector;
                        Vector2 pointEndPosition = startPosition + fraction * distanceVector;
                        double fadeOutTime = startTime + fraction * duration;
                        double fadeInTime = fadeOutTime - PreEmpt;

                        //Add(new FollowPoint()
                        //{
                        //    StartTime = fadeInTime,
                        //    EndTime = fadeOutTime,
                        //    Position = pointStartPosition,
                        //    EndPosition = pointEndPosition,
                        //    Rotation = rotation,
                        //});
                    }
                }
                prevHitObject = currHitObject;
            }

        }

    }
}
