namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type.Shape
{
    class RpShapeGenerator
    {
        /*
        //生產器
        protected CalRPBeat _calRPBeat; //計算打擊
        protected RPMultipleHitCalculator _multipleHitCalculator; //取的開頭和結尾數量，目前是兩拍為單位，因為比較好處理
        protected RPClickObjectTypeGenerator _clickObjectTypeGenerator; //取得形狀
        protected RPShapeAppearRuleTable _ruleTable; //形狀順序
        protected RPTypeGenerator _divaTypeGenerator; //這邊會決定是普通還是加分模式

        //參數
        int _nowProcessIndex;
        //丟進來的參數
        List<ConvertParameter> _scannParameter;
        //返回參數
        List<List<ConvertParameter>> _returnParameter;

        public RPShapeGenerator()
        {
            _multipleHitCalculator = new RPMultipleHitCalculator();
            _clickObjectTypeGenerator = new RPClickObjectTypeGenerator();
            _ruleTable = new RPShapeAppearRuleTable();
            _calRPBeat = new CalRPBeat();
            _divaTypeGenerator = new RPTypeGenerator();
        }

        /// <summary>
        /// 參數
        /// </summary>
        /// <param name="lastComponent"></param>
        public void SetParameter(List<ComvertParameter> scannParameter)
        {
            _scannParameter = scannParameter;

            _calRPBeat.SetParameter(_scannParameter);
            _multipleHitCalculator.SetParameter(_scannParameter);
            _ruleTable.SetParameter(_scannParameter);
            _calRPBeat.SetParameter(_scannParameter);
            _divaTypeGenerator.SetParameter(_scannParameter);
        }

        /// <summary>
        /// 處理全部
        /// </summary>
        public void Process()
        {
            _returnParameter = new List<List<ConvertParameter>>();

            _calRPBeat.SetComvertedParameter(_scannParameter);
            _multipleHitCalculator.SetComvertedParameter(_scannParameter);
            _ruleTable.SetComvertedParameter(_scannParameter);
            _calRPBeat.SetComvertedParameter(_scannParameter);
            _divaTypeGenerator.SetComvertedParameter(_scannParameter);

            for (int i = 0; i < _scannParameter.Count; i++)
            {
                _returnParameter[i].AddRange(GetListRPObjectType(i));
            }
        }

        public List<List<ComvertParameter>> GetResult()
        {
            return _returnParameter;
        }

        /// <summary>
        /// 取得目前產生結果
        /// </summary>
        /// <returns></returns>
        protected List<ConvertParameter> GetListRPObjectType(int index)
        {
            //節拍
            ProcessBeat(index);
            //目前數量
            ProcessNumber(index);
            //目前形狀排列
            ProcessShape(index);
            //更新排列順序表
            ProcessRPShapeAppearRuleTable(index);
            //返回結果
            return ProcessReturnGesult(index);
        }

        /// <summary>
        /// 處理節拍問題
        /// </summary>
        private void ProcessBeat(int index)
        {
            _calRPBeat.SetIndex(index);
            _calRPBeat.Process();
        }

        /// <summary>
        /// 先取的目前這一拍同時有多少物件要被打擊
        /// 1~4個，通常是一個
        /// </summary>
        private void ProcessNumber(int index)
        {
            _multipleHitCalculator.SetIndex(index);
            _multipleHitCalculator.IsMulti(_calRPBeat.IsMulti());
            _multipleHitCalculator.UpdateBeatNumber(_calRPBeat.GetBeatNumber());

            if (_calRPBeat.GetNewCombo())
            {
                //表示要重新計算
                _multipleHitCalculator.ReCalculate();
            }
            else
            {
                //繼續
                _multipleHitCalculator.UpdateStep();
            }
        }

        /// <summary>
        /// 更新形狀代號
        /// </summary>
        private void ProcessShape(int index)
        {
            _ruleTable.SetIndex(index);
            //表示要重新計算
            if (_calRPBeat.GetNewCombo())
            {
                //重新計算規律
                _ruleTable.SetBeatParameter(_calRPBeat.GetBeatNumber(), _calRPBeat.nowBeat());
                _ruleTable.ReCalculate();
            }
            else
            {
                _ruleTable.UpdateState();
            }
        }


        /// <summary>
        /// 更新排列順序表
        /// </summary>
        private void ProcessRPShapeAppearRuleTable(int index)
        {
            _clickObjectTypeGenerator.SetIndex(index);

            //如果是newConbo 或是 不規律模式，都要重算
            if (_calRPBeat.GetNewCombo() || !_calRPBeat.IsRegular())
            {
                //重新計算不同數字代表意思
                _clickObjectTypeGenerator.ReCalculate();
            }
            else
            {
                //目前好像沒動作
            }
        }

        /// <summary>
        /// 生產結果後傳回來
        /// </summary>
        /// <returns></returns>
        List<ConvertParameter> ProcessReturnGesult(int index)
        {
            List<ConvertParameter> _listType = new List<ConvertParameter>();

            //目前這個節拍上有多少物件?
            int nowAppearNumber = _multipleHitCalculator.GetNowBeatNoteNumber();

            if (nowAppearNumber > 0)
            {
                for (int i = 0; i < nowAppearNumber; i++)
                {
                    ComvertParameter type = _scannParameter[index].Clone();
                    type.OsuComvertToRPArcadeRulesetComponent.RPObjectType.RP_ObjectClickType = GetRPObjectClickType(nowAppearNumber);//更新是單點壓還是多點
                    type.OsuComvertToRPArcadeRulesetComponent.RPObjectType.RP_ClickObjectType = GetRPClickObjectShape(i);
                    type.OsuComvertToRPArcadeRulesetComponent.RPObjectType.RP_Type = _divaTypeGenerator.GetResult();

                    //
                    _listType.Add(type);
                }
            }

            return _listType;
        }

        /// <summary>
        /// 更新目前是單點壓還是多點
        /// </summary>
        /// <returns></returns>
        protected RPObjectClickType GetRPObjectClickType(int nowAppearNumber)
        {
            if (nowAppearNumber == 1)
            {
                return RPType.SingleClick;
            }
            else
            {
                return RPObjectClickType.Multi;
            }
        }

        /// <summary>
        /// 取得目前形狀index，對應第幾個生產的物件index
        /// 例如 4 代表 _clickObjectTypeGenerator 裡面的 X
        /// </summary>
        /// <returns></returns>
        protected RPClickObjectType GetRPClickObjectShape(int index)
        {
            //目前物件順序對應的index
            int shapeIndex = _ruleTable.GetIndexTable()[index];
            return _clickObjectTypeGenerator.GetResult()[shapeIndex];
        }
        */
    }
}
