//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.ScoreProcessor;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.ContainerBackground;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.CoopHint;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectsConnector;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Judgement;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.KeySound;
using osu.Game.Modes.UI;
using OpenTK;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield
{
    /// <summary>
    ///     驕頑梓迚ｩ莉ｶ鬘ｯ遉ｺ
    /// </summary>
    public class RpPlayfield : Playfield<BaseRpObject, RpJudgement>
    {
        /// <summary>
        ///     鬘ｯ遉ｺ螟ｧ蟆擾ｼ御ｼｰ險域怎譬ｹ謫夊ｦ也ｪ怜､ｧ蟆剰ｪｿ謨ｴ
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

        private readonly CoopHintLayout _coopHintLayout;

        /// <summary>
        ///     鬘ｯ遉ｺ閭梧勹
        /// </summary>
        private readonly ContainerBackgroundLayout containerBackgroundLayout;

        /// <summary>
        ///     逕ｨ萓・｡ｯ遉ｺ謇捺投迚ｩ莉ｶ逧・Layout
        /// </summary>
        private readonly HitObjectLayout _rpObjectLayout;

        /// <summary>
        ///     騾｣謗･螟壼狗黄莉ｶ逕ｨ萓・吻邱夂噪
        /// </summary>
        private readonly ConnectionRenderer<DrawableBaseRpHitObject> _hitObjectConnector;

        /// <summary>
        ///     逕ｨ萓・愛譁ｷ謇捺投逧・Layout
        /// </summary>
        private readonly JudgementLayout _judgementLayer;

        /// <summary>
        ///     鬘ｯ遉ｺ蜑肴婿謖・・・悟柱荳莠帷音谿顔黄莉ｶ
        /// </summary>
        private KeySoundLayout keySoundLayout;

        /// <summary>
        ///     驕顔自蜊蝓・
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
                containerBackgroundLayout = new ContainerBackgroundLayout //閭梧勹
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 2
                },
                _rpObjectLayout = new HitObjectLayout //迚ｩ莉ｶ謾ｾ鄂ｮ・檎畑萓・★蜿門ｾ礼畑
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1,
                    ContainerBackgroundLayout = containerBackgroundLayout
                },
                _hitObjectConnector = new HitObjectConnector //迚ｩ莉ｶ騾｣邱・
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1
                    //HitObjectLayout=_rpObjectLayout,
                },
                keySoundLayout = new KeySoundLayout //謇捺投譎りｦ∵怏閨ｲ髻ｳ
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -1
                },
                _judgementLayer = new JudgementLayout //謇捺投迚ｹ謨・
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -2
                }
            });
            Depth = 1;
        }


        /// <summary>
        ///     譛・滑隕・｡ｯ遉ｺ逧・黄莉ｶ騾蝉ｸ蜉騾ｲ萓・
        /// </summary>
        /// <param name="h"></param>
        public override void Add(DrawableHitObject<BaseRpObject, RpJudgement> hitObject)
        {
            hitObject.Depth = (float)hitObject.HitObject.StartTime;

            //IDrawableHitObjectWithProxiedApproach c = hitObject as IDrawableHitObjectWithProxiedApproach;


            if (hitObject is DrawableRpContainer)
            {
                //蠅槫刈閭梧勹迚ｩ莉ｶ
                containerBackgroundLayout.AddContainer(hitObject as DrawableRpContainer);
                //
                //keySoundLayout.Add(containerBackgroundLayout.CreateProxy());
            }
            else
            {
                base.Add(hitObject);
                //蠅槫刈迚ｩ莉ｶ
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
