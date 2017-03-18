using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.GenerateObject;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject
{
    class HitObjectProcessor
    {
        /// <summary>
        /// 產生出實體物件
        /// </summary>
        RpObjectGenerator _rpObjectGenerator = new RpObjectGenerator();
        /// <summary>
        /// 類型生產器
        /// </summary>
        ObjectTypeGenerator _typeGenerator = new ObjectTypeGenerator();
        /// <summary>
        /// 位置生產器
        /// </summary>
        ObjectPositionGenerator _positionGenerator = new ObjectPositionGenerator();

        /// <summary>
        /// 主要轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<HitObjectConvertParameter> Convert(List<HitObjectConvertParameter> input)
        {
            //產生出實體物件
            input = _rpObjectGenerator.Convert(input);
            //先轉換類型，會接收到語意後做處理
            input = _typeGenerator.Convert(input);
            //轉換座標，會接收到語意後做處理
            input = _positionGenerator.Convert(input);
            //回傳
            return input;
        }
    }
}
