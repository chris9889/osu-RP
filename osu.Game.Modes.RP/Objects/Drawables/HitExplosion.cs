//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Modes.RP.Objects.Drawables.HitEffectTemplate;
using osu.Game.Modes.RP.ScoreProcessor;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables
{
    /// <summary>
    ///     打擊會產生的特效
    /// </summary>
    public class HitExplosion : FillFlowContainer
    {
        /// <summary>
        ///     打擊判定
        /// </summary>
        private readonly RpJudgement judgement;

        /// <summary>
        ///     顯示特效
        /// </summary>
        private readonly BaseHitEffectTemplate _hitEffect;

        public HitExplosion(RpJudgement judgement, BaseRpObject h = null)
        {
            if (h is BaseHitObject)
            {
                this.judgement = judgement;
                AutoSizeAxes = Axes.Both;
                Origin = Anchor.Centre;

                Direction = FillDirection.Vertical;
                Spacing = new Vector2(0, 2);
                //Position = (h?.Position ?? Vector2.Zero) + judgement.PositionOffset;

                if (judgement.HitExplosionPosition.Count > 0)
                    Position = judgement.HitExplosionPosition[0];

                //根據物件去顯示成績
                switch (judgement.Score)
                {
                    case RPScoreResult.Sad:
                        _hitEffect = new SadHitEffectTemplate();
                        break;
                    case RPScoreResult.Safe:
                        _hitEffect = new SafeHitEffectTemplate();
                        break;
                    case RPScoreResult.Fine:
                        _hitEffect = new FineHitEffectTemplate();
                        break;
                    case RPScoreResult.Cool:
                        _hitEffect = new CoolHitEffectTemplate();
                        break;
                    case RPScoreResult.Slider:
                        _hitEffect = new SlideHitEffectTemplate();
                        break;
                }

                //
                //_hitEffect = new FineHitEffectTemplate();
                //Position = PositionManager.GetPosition(h);

                //把物件增加上去
                Children = new Drawable[]
                {
                    _hitEffect
                };
            }
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();


            Delay(600);

            //開始顯示特效
            _hitEffect.StartEffect();

            Expire();
        }
    }
}
