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
    ///     遊戲物件顯示
    /// </summary>
    public class RpPlayfield : Playfield<BaseRpObject, RpJudgement>
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
        private readonly CoopHintLayout _coopHintLayout;

        /// <summary>
        ///     RpContainer Object's layout
        /// </summary>
        private readonly ContainerBackgroundLayout containerBackgroundLayout;

        /// <summary>
        ///     RpHitObject's Layout
        ///     It only store on the list, not added to the Drawable Child
        /// </summary>
        private readonly HitObjectLayout _rpObjectLayout;

        /// <summary>
        ///     Draw the line connected to mulit Hit Object
        /// </summary>
        private readonly ConnectionRenderer<DrawableBaseRpHitObject> _hitObjectConnector;

        /// <summary>
        ///     Hit Effect Layer
        /// </summary>
        private readonly JudgementLayout _judgementLayer;

        /// <summary>
        ///     HitSound Layer
        /// </summary>
        private KeySoundLayout keySoundLayout;

        /// <summary>
        ///     Initial Play Field
        /// </summary>
        public RpPlayfield()
            : base(512)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Add(new Drawable[]
            {
                _coopHintLayout = new CoopHintLayout
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 3
                },
                containerBackgroundLayout = new ContainerBackgroundLayout 
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 2
                },
                _rpObjectLayout = new HitObjectLayout 
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1,
                    ContainerBackgroundLayout = containerBackgroundLayout
                },
                _hitObjectConnector = new HitObjectConnector
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1
                    //HitObjectLayout=_rpObjectLayout,
                },
                keySoundLayout = new KeySoundLayout 
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -1
                },
                _judgementLayer = new JudgementLayout 
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -2
                }
            });
            Depth = 1;
        }


        /// <summary>
        ///     Add the DrawableHitObject
        /// </summary>
        /// <param name="h"></param>
        public override void Add(DrawableHitObject<BaseRpObject, RpJudgement> hitObject)
        {
            hitObject.Depth = (float)hitObject.HitObject.StartTime;

            //IDrawableHitObjectWithProxiedApproach c = hitObject as IDrawableHitObjectWithProxiedApproach;


            if (hitObject is DrawableRpContainer)
            {
                //增加背景物件
                containerBackgroundLayout.AddContainer(hitObject as DrawableRpContainer);
                //
                //keySoundLayout.Add(containerBackgroundLayout.CreateProxy());
            }
            else
            {
                base.Add(hitObject);
                //增加物件
                _rpObjectLayout.AddDrawObject(hitObject as DrawableBaseRpHitObject);
            }
        }


        public override void PostProcess()
        {
            //order by time
            _hitObjectConnector.HitObjects = HitObjects.Children.Select(d => (DrawableBaseRpHitObject)d).OrderBy(h => h.HitObject.StartTime);
            _hitObjectConnector.ScanSameTuple();
        }

        /// <summary>
        ///     Create hit explosion effect;
        /// </summary>
        /// <param name="h"></param>
        /// <param name="j"></param>
        public override void OnJudgement(DrawableHitObject<BaseRpObject, RpJudgement> drawableHitObject)
        {
            _judgementLayer.AddHitEffect(drawableHitObject);
        }
    }
}
