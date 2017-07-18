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

            RpContainerLine Object = new RpContainerLine(CreateRpContainerLineGroup(position, startTime, endTime));
            return Object;
        }

        public RpContainerLineGroup CreateRpContainerLineGroup(Vector2 position, Double startTime, Double endTime)
        {
            RpContainerLineGroup rpContainerLineGroup = new RpContainerLineGroup(startTime);
            rpContainerLineGroup.Position = position;
            rpContainerLineGroup.EndTime = endTime;
            return rpContainerLineGroup;
        }

        public RpContainerLineHoldObject CreateRpContainerLineHoldObject(Vector2 position, Double startTime, Double endTime)
        {
            RpContainerLineHoldObject rpContainerLineHoldObject = new RpContainerLineHoldObject();
            rpContainerLineHoldObject.Position = position;
            rpContainerLineHoldObject.StartTime = startTime;
            rpContainerLineHoldObject.EndTime = endTime;
            return rpContainerLineHoldObject;
        }

        public RpHitObject CreateRpHitObject(Vector2 position, Double startTime)
        {
            RpHitObject rpHitObject = new RpHitObject();
            rpHitObject.Position = position;
            rpHitObject.StartTime = startTime;
            return rpHitObject;
        }

        public RpHoldObject CreateRpHoldObject(Vector2 position, Double startTime, Double endTime)
        {
            RpHoldObject rpHoldObject = new RpHoldObject();
            rpHoldObject.Position = position;
            rpHoldObject.StartTime = startTime;
            //RpHoldObject.EndTime = endTime;

            return rpHoldObject;
        }
    }
}
