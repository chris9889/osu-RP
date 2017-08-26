// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Input;

namespace osu.Game.Rulesets.RP.Objects
{
    public class RpHitObject : BaseRpHitableObject
    {
        //ObjectType
        public override ObjectType ObjectType => ObjectType.Hit;

        //Direction
        public Direction Direction { get; set; }

        //constructure
        public RpHitObject(RpContainerLine parent, double startTime)
            : base(parent, startTime)
        {
        }

       
        public override bool CanHitBy(RpAction action)
        {
            //isMatch
            bool left = false;
            bool right = false;

            switch (Direction)
            {
                case Direction.Up:
                    left = action == RpAction.Left_Up;
                    right = action == RpAction.Right_Up;
                    break;
                case Direction.Down:
                    left = action == RpAction.Left_Down;
                    right = action == RpAction.Right_Down;
                    break;
                case Direction.Left:
                    left = action == RpAction.Left_Down;
                    right = action == RpAction.Right_Down;
                    break;
                case Direction.Right:
                    left = action == RpAction.Left_Down;
                    right = action == RpAction.Right_Down;
                    break;
            }

            if (Coop == Coop.LeftOnly)
                return left;
            if (Coop == Coop.RightOnly)
                return right;

            return left && right;
        }

        //InitialDefaultValue
        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }
    }

    public enum Direction
    {
        Up = 1, //up
        Down = 2, //down
        Left = 4, //left
        Right = 8, //right
    }
}
