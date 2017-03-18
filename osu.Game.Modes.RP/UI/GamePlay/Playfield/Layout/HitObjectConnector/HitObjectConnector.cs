using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Framework.Graphics;
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

        private void update()
        {
            Clear();
            if (hitObjects == null)
                return;

            BaseRpObject prevHitObject = null;
            foreach (var currHitObject in hitObjects)
            {
                //if (prevHitObject != null && !currHitObject.NewCombo && !(prevHitObject is ObjectContainer) )//&& !(currHitObject is ObjectContainer))
                if (prevHitObject != null && !(prevHitObject is ObjectContainer) )//&& !(currHitObject is ObjectContainer))
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

                        Add(new FollowPoint()
                        {
                            StartTime = fadeInTime,
                            EndTime = fadeOutTime,
                            Position = pointStartPosition,
                            EndPosition = pointEndPosition,
                            Rotation = rotation,
                        });
                    }
                }
                prevHitObject = currHitObject;
            }
        }
    }
}
