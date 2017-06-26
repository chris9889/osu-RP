using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects;
using OpenTK;

namespace osu.Desktop.VisualTests.TestsScript.Beatmaps.HitObject
{
    public class RpHitObjectCreatorScript
    {

        private bool _editable = false;

        public void SetObjectEditable(bool editable)
        {
            _editable = editable;
        }

        public RpContainerLine CreateRpContainerLine(Vector2 position,Double startTime,Double endTime)
        {
            return null;
        }

        public RpContainerLineGroup CreateRpContainerLineGroup(Vector2 position, Double startTime, Double endTime)
        {
            return null;
        }

        public RpContainerLineHoldObject CreateRpContainerLineHoldObject(Vector2 position, Double startTime, Double endTime)
        {
            return null;
        }

        public RpHitObject CreateRpHitObject(Vector2 position, Double startTime)
        {
            return null;
        }

        public RpHoldObject CreateRpHoldObject(Vector2 position, Double startTime, Double endTime)
        {
            return null;
        }
    }
}
