using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield
{
    /// <summary>
    /// edit field
    /// </summary>
    internal class RpEditPlayfield : RpPlayfield
    {

        public RpEditPlayfield()
            : base()
        {

        }

        /// <summary>
        /// when saving, will RegenerateObjectID first
        /// </summary>
        public void RegenerateObjectID()
        {
            //generate object id by time
            int containerGroupNumber = ContainerBackgroundLayer.ContainerGroupList.Count;
            for (int i = 0; i < containerGroupNumber; i++)
            {
                ContainerBackgroundLayer.ContainerGroupList[i].HitObject.ID = i;
                foreach (var single in ContainerBackgroundLayer.ContainerGroupList[i].Template.ListContainObject)
                {
                    //TODO L change ref id
                    //single.HitObject.
                }
            }
        }

        public override void InitialPlayFieldLayer()
        {
            AddRange(new Drawable[]
            {
                //CoopHintLayer, //EditMode does not need this
                ContainerBackgroundLayer,
                RpObjectLayer,
                HitObjectConnectorLayer,
                KeySoundLayer,
                JudgementLayer,
            });
        }
    }
}
