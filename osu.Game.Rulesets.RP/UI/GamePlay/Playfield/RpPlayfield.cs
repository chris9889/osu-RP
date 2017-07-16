//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CoopHint;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjectsConnector;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.KeySound;
using osu.Game.Rulesets.UI;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield
{
    /// <summary>
    ///    Playfield 
    /// </summary>
    internal class RpPlayfield : Playfield<BaseRpObject, RpJudgement>
    {
        /// <summary>
        ///     set the size
        ///     This Code maybe form osu mode
        /// </summary>
        public override Vector2 Size
        {
            get
            {
                var parentSize = Parent.DrawSize;
                var aspectSize = parentSize.X * 0.75f < parentSize.Y ? new Vector2(parentSize.X, parentSize.X * 0.75f) : new Vector2(parentSize.Y * 4f / 3f, parentSize.Y);

                return new Vector2(aspectSize.X / parentSize.X, aspectSize.Y / parentSize.Y) * base.Size;
            }
        }

        /// <summary>
        /// Show the co-op backgrounf
        /// </summary>
        protected readonly CoopHintLayer CoopHintLayer;

        /// <summary>
        ///     RpContainer Object's layout
        /// </summary>
        protected readonly ContainerBackgroundLayer ContainerBackgroundLayer;

        /// <summary>
        ///     RpHitObject's Layout
        ///     It only store on the list, not added to the Drawable Child
        /// </summary>
        protected readonly HitObjectLayer RpObjectLayer;

        /// <summary>
        ///     Draw the line connected to mulit Hit Object
        /// </summary>
        protected readonly ConnectionRendererLayer<DrawableBaseRpHitableObject> HitObjectConnectorLayer;

        /// <summary>
        ///     Hit Effect Layer
        /// </summary>
        protected readonly JudgementLayer JudgementLayer;

        /// <summary>
        ///     HitSound Layer
        /// </summary>
        protected KeySoundLayer KeySoundLayer;

        /// <summary>
        ///     Initial Play Field
        /// </summary>
        public RpPlayfield() : base(512)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            CoopHintLayer = new CoopHintLayer
            {
                RelativeSizeAxes = Axes.Both,
                Depth = 3
            };
            ContainerBackgroundLayer = new ContainerBackgroundLayer
            {
                RelativeSizeAxes = Axes.Both,
                Depth = 2
            };
            RpObjectLayer = new HitObjectLayer
            {
                RelativeSizeAxes = Axes.Both,
                Depth = 1,
                ContainerBackgroundLayer = ContainerBackgroundLayer
            };
            HitObjectConnectorLayer = new HitObjectConnectorLayer
            {
                RelativeSizeAxes = Axes.Both,
                Depth = 1
                //HitObjectLayer=_rpObjectLayout,
            };
            KeySoundLayer = new KeySoundLayer
            {
                RelativeSizeAxes = Axes.Both,
                Depth = -1
            };
            JudgementLayer = new JudgementLayer
            {
                RelativeSizeAxes = Axes.Both,
                Depth = -2
            };

            InitialPlayFieldLayer();

            Depth = 1;
        }

        public virtual void InitialPlayFieldLayer()
        {
            AddRange(new Drawable[]
            {
                CoopHintLayer,
                ContainerBackgroundLayer,
                RpObjectLayer,
                HitObjectConnectorLayer,
                KeySoundLayer,
                JudgementLayer,
            });
        }


        /// <summary>
        ///     Add the DrawableHitObject
        /// </summary>
        /// <param name="h"></param>
        public override void Add(DrawableHitObject<BaseRpObject, RpJudgement> hitObject)
        {
            hitObject.Depth = (float)hitObject.HitObject.StartTime;

            //IDrawableHitObjectWithProxiedApproach c = hitObject as IDrawableHitObjectWithProxiedApproach;


            if (hitObject is DrawableRpContainerLineGroup)
            {
                //繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽw繝ｻ・ｽi繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ
                ContainerBackgroundLayer.AddContainerLineGroup(hitObject as DrawableRpContainerLineGroup);
                //
                //keySoundLayout.Add(containerBackgroundLayout.CreateProxy());
            }
            else
            {
                base.Add(hitObject);
                //繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ繝ｻ・ｽ
                RpObjectLayer.AddDrawObject(hitObject as DrawableBaseRpHitableObject);
            }
        }


        public override void PostProcess()
        {
            //order by time
            HitObjectConnectorLayer.HitObjects = HitObjects.Children.Select(d => (DrawableBaseRpHitableObject)d).OrderBy(h => ((DrawableBaseRpObject)h).HitObject.StartTime);
            //
            HitObjectConnectorLayer.ScanSameTuple();
        }

        /// <summary>
        ///     Create hit explosion effect;
        /// </summary>
        /// <param name="h"></param>
        /// <param name="j"></param>
        public override void OnJudgement(DrawableHitObject<BaseRpObject, RpJudgement> drawableHitObject)
        {
            JudgementLayer.AddHitEffect(drawableHitObject);
        }
    }
}
