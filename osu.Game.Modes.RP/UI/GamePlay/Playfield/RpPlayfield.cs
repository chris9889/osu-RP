//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Background;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Front;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObject;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectConnector;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.RP.ScoreProcessor;
using OpenTK;
using osu.Game.Modes.UI;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield
{
    /// <summary>
    /// 遊戲物件顯示
    /// </summary>
    public class RpPlayfield : Playfield<BaseRpObject, RpJudgement>
    {
        /// <summary>
        /// 顯示背景
        /// </summary>
        private BackgroundLayout _backgroundLayout;

        /// <summary>
        /// 用來顯示打擊物件的 Layout
        /// </summary>
        private HitObjectLayout _rpObjectLayout;

        /// <summary>
        /// 
        /// </summary>
        private ConnectionRenderer<BaseHitObject> _hitObjectConnector;

        /// <summary>
        /// 用來判斷打擊的 Layout
        /// </summary>
        private Container _judgementLayer;

        /// <summary>
        /// 顯示前方指針，和一些特殊物件
        /// </summary>
        private FrontLayout _frontLayout;

        /// <summary>
        /// 顯示大小，估計會根據視窗大小調整
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
        /// 遊玩區域
        /// </summary>
        public RpPlayfield() : base(512)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.Both;
            Size = new Vector2(0.75f);

            Add(new Drawable[]
            {
               _backgroundLayout=new BackgroundLayout //背景
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 2,
                },
                _rpObjectLayout = new HitObjectLayout //物件放置，用來做取得用
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1,
                    _backgroundLayout=this._backgroundLayout
                },
                _hitObjectConnector = new HitObjectConnector //物件連線
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1,
                    //HitObjectLayout=_rpObjectLayout,
                },
                    _frontLayout = new FrontLayout //顯示判定點
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -1,
                },
                    _judgementLayer = new Container //打擊特效
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -2,
                },

            });
        }


        /// <summary>
        /// 會把要顯示的物件逐一加進來
        /// </summary>
        /// <param name="h"></param>
        public override void Add(DrawableHitObject<BaseRpObject, RpJudgement> hitObject)
        {
            
            hitObject.Depth = (float)hitObject.HitObject.StartTime;

            //IDrawableHitObjectWithProxiedApproach c = hitObject as IDrawableHitObjectWithProxiedApproach;


            if (hitObject is DrawableContainer)
            {
                _backgroundLayout.AddContainer(hitObject as DrawableContainer);
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
            _hitObjectConnector.HitObjects = HitObjects.Children.Select(d => (BaseHitObject)d.HitObject)
                .OrderBy(h => h.StartTime);
        }

        /// <summary>
        /// 增加打擊時的特效
        /// </summary>
        /// <param name="h"></param>
        /// <param name="j"></param>
        public override void OnJudgement(DrawableHitObject<BaseRpObject, RpJudgement> drawableHitObject)
        {
            HitExplosion explosion = new HitExplosion(drawableHitObject.Judgement, drawableHitObject.HitObject);

            _judgementLayer.Add(explosion);
        }
    }
}