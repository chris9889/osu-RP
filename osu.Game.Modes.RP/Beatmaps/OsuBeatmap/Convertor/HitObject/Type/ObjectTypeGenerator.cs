using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type.Shape;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type
{
    /// <summary>
    /// 建構 RPObjectType
    /// </summary>
    class ObjectTypeGenerator
    {

        //丟進來的參數
        List<HitObjectConvertParameter> _scannParameter = new List<HitObjectConvertParameter>();

        //生產器
        protected RpShapeGenerator _shapeGenerator; //形狀


        /// <summary>
        /// 回傳完成生產的物件
        /// </summary>
        /// <returns></returns>
        public List<HitObjectConvertParameter> Convert(List<HitObjectConvertParameter> scannerResult)
        {
            _scannParameter = scannerResult;
            //設定參數
            /*
            _shapeGenerator.SetParameter(_scannParameter);
            _shapeGenerator.Process();

            //處理完所有的形狀
            _scannParameter = _shapeGenerator.GetResult();

            //全部都設定成位置auto
            foreach (List<ConvertParameter> tuple in _scannParameter)
            {
                foreach (ConvertParameter singleType in tuple)
                    singleType.OsuComvertToRPArcadeRulesetComponent.RPObjectType.RP_AppearMode = RPAppearMode.Auto;
            }
            */
            //還有更新物件是click Slider 還是 Hold
            return _scannParameter;
        }
    }
}
