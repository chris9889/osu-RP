﻿using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CoopHint
{
    public class CoopHintLayer : BaseGamePlayLayer
    {
        private readonly Component.CoopHint leftCoopHint;
        private readonly Component.CoopHint rightCoopHint;

        public CoopHintLayer()
        {
            //initial left
            leftCoopHint = new Component.CoopHint(RpBaseHitObjectType.Coop.LeftOnly)
            {
                Position = new Vector2(0 - 300, 192),
                Rotation = 15
            };

            //initial right
            rightCoopHint = new Component.CoopHint(RpBaseHitObjectType.Coop.RightOnly)
            {
                Position = new Vector2(512 + 300, 192),
                Rotation = 195
            };

            //add both of them
            Children = new Drawable[]
            {
                leftCoopHint,
                rightCoopHint
            };
        }
    }
}
