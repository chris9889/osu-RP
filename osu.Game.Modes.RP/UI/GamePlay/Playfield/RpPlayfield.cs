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
    ///     遊戲物件顯示
    /// </summary>
    public class RpPlayfield : Playfield<BaseRpObject, RpJudgement>
    {
        /// <summary>
        ///     顯示大小，估計會根據視窗大小調整
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
        ///     顯示背景
        /// </summary>
        private readonly ContainerBackgroundLayout containerBackgroundLayout;

        /// <summary>
        ///     用來顯示打擊物件的 Layout
        /// </summary>
        private readonly HitObjectLayout _rpObjectLayout;

        /// <summary>
        ///     連接多個物件用來畫線的
        /// </summary>
        private readonly ConnectionRenderer<DrawableBaseHitObject> _hitObjectConnector;

        /// <summary>
        ///     用來判斷打擊的 Layout
        /// </summary>
        private readonly JudgementLayout _judgementLayer;

        /// <summary>
        ///     顯示前方指針，和一些特殊物件
        /// </summary>
        private KeySoundLayout keySoundLayout;

        /// <summary>
        ///     遊玩區域
        /// </summary>
        public RpPlayfield()
            : base(512)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.Both;
            Size = new Vector2(0.75f);

            Add(new Drawable[]
            {
                _coopHintLayout=new CoopHintLayout
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 3
                },
                containerBackgroundLayout = new ContainerBackgroundLayout //背景
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 2
                },
                _rpObjectLayout = new HitObjectLayout //物件放置，用來做取得用
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1,
                    ContainerBackgroundLayout = containerBackgroundLayout
                },
                _hitObjectConnector = new HitObjectConnector //物件連線
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1
                    //HitObjectLayout=_rpObjectLayout,
                },
                keySoundLayout = new KeySoundLayout //打擊時要有聲音
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -1
                },
                _judgementLayer = new JudgementLayout //打擊特效
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -2
                }
            });
            Depth = 1;
        }


        /// <summary>
        ///     會把要顯示的物件逐一加進來
        /// </summary>
        /// <param name="h"></param>
        public override void Add(DrawableHitObject<BaseRpObject, RpJudgement> hitObject)
        {
            hitObject.Depth = (float)hitObject.HitObject.StartTime;

            //IDrawableHitObjectWithProxiedApproach c = hitObject as IDrawableHitObjectWithProxiedApproach;


            if (hitObject is DrawableContainer)
            {
                //增加背景物件
                containerBackgroundLayout.AddContainer(hitObject as DrawableContainer);
                //
                //keySoundLayout.Add(containerBackgroundLayout.CreateProxy());
            }
            else
            {
                base.Add(hitObject);
                //增加物件
                _rpObjectLayout.AddDrawObject(hitObject as DrawableBaseHitObject);
            }
        }


        public override void PostProcess()
        {
            //order by time
            _hitObjectConnector.HitObjects = HitObjects.Children.Select(d => (DrawableBaseHitObject)d).OrderBy(h => h.HitObject.StartTime);
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
