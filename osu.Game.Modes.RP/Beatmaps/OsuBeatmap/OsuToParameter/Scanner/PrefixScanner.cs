using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.OsuToParameter.Scanner
{
    /// <summary>
    /// 預先處理出一些之後語法分析會用到的參數
    /// </summary>
    class PrefixScanner
    {

        NewComboScanner _newComboScanner;

        PrePositionDiffScanner _prePositionDiffScanner;

        PostPositionDiffScanner _postPositionDiffScanner;

        BeatPreDiffScanner _beatPreDiffGenerator;

        public PrefixScanner()
        {
            _newComboScanner = new NewComboScanner();
            _prePositionDiffScanner = new PrePositionDiffScanner();
            _postPositionDiffScanner = new PostPositionDiffScanner();
            _beatPreDiffGenerator = new BeatPreDiffScanner();
        }
        internal List<HitObjectConvertParameter> Convert(List<HitObjectConvertParameter> output)
        {
            SetInput(output);
            Process();
            SetResult(output);
            return output;
        }


        /// <summary>
        /// 丟入參數
        /// </summary>
        public void SetInput(List<HitObjectConvertParameter> listObject)
        {
            //
            _newComboScanner.SetInput(listObject);
            _prePositionDiffScanner.SetInput(listObject);
            _postPositionDiffScanner.SetInput(listObject);
            _beatPreDiffGenerator.SetInput(listObject);
        }

        /// <summary>
        /// 處理轉換問題
        /// </summary>
        public void Process()
        {
            _newComboScanner.Process();
            _prePositionDiffScanner.Process();
            _postPositionDiffScanner.Process();
            _beatPreDiffGenerator.Process();
        }

        /// <summary>
        /// 取得轉換過的結果
        /// </summary>
        /// <returns></returns>
        public void SetResult(List<HitObjectConvertParameter> output)
        {
            for (int i = 0; i < output.Count; i++)
            {
                ScanParameter result = new ScanParameter();
                result.NewComboScannerResult = _newComboScanner.GetResult()[i];
                result.ComboGroup = _newComboScanner.GetComboGroupResult()[i];
                result.PrePositionDiffScannerResult = _prePositionDiffScanner.GetResult()[i];
                result.PostPositionDiffScannerResult = _postPositionDiffScanner.GetResult()[i];
                result.BeatPreDiffScannerResult = _beatPreDiffGenerator.GetResult()[i];
                output[i].ScanParameter = result;
            }
        }


        /// <summary>
        /// 掃描combo
        /// 會在new Combo 那一個物件顯示之後有連續多少combo
        /// 例如 3 0 0 10 0 0 0 0 0 0 0 0.....
        ///            (New Combo)
        /// </summary>
        class NewComboScanner
        {
            /// <summary>
            /// 目前處理物件
            /// </summary>
            List<HitObjectConvertParameter> _listObject;

            /// <summary>
            /// 目前結果
            /// </summary>
            List<int> _listResult = new List<int>();

            /// <summary>
            /// 目前結果
            /// </summary>
            List<int> _comboGroup = new List<int>();

            public NewComboScanner()
            {

            }
            /// <summary>
            /// 丟入參數
            /// </summary>
            public void SetInput(List<HitObjectConvertParameter> listObject)
            {
                _listObject = listObject;
            }

            /// <summary>
            /// 處理轉換問題
            /// </summary>
            public void Process()
            {
                int comboGroup = 0;
                for (int i = 0; i < _listObject.Count; i++)
                {
                    if (_listObject[i].OsuHitObject.NewCombo)
                    {
                        int combo = 0;
                        for (int j = i + 1; j < _listObject.Count; j++)
                        {
                            combo++;
                            if (_listObject[j].OsuHitObject.NewCombo)
                                break;
                        }
                        _listResult.Add(combo);
                        comboGroup++;
                    }
                    else
                    {
                        _listResult.Add(0);
                    }
                    _comboGroup.Add(comboGroup);
                }
            }

            public List<int> GetResult()
            {
                return _listResult;
            }

            public List<int> GetComboGroupResult()
            {
                return _comboGroup;
            }
        }

        /// <summary>
        /// 掃描座標改變，和前面差異
        /// </summary>
        class PrePositionDiffScanner
        {
            /// <summary>
            /// 目前處理物件
            /// </summary>
            List<HitObjectConvertParameter> _listObject;

            List<Vector2> _listResult = new List<Vector2>();

            /// <summary>
            /// 丟入參數
            /// </summary>
            public void SetInput(List<HitObjectConvertParameter> listObject)
            {
                _listObject = listObject;
            }

            /// <summary>
            /// 處理轉換問題
            /// </summary>
            public void Process()
            {
                for (int i = 0; i < _listObject.Count; i++)
                {
                    if (i > 0)
                    {
                        _listResult.Add(_listObject[i].OsuHitObject.Position - _listObject[i - 1].OsuHitObject.Position);
                    }
                    else
                    {
                        _listResult.Add(new Vector2(0, 0));
                    }
                }
            }

            public List<Vector2> GetResult()
            {
                return _listResult;
            }
        }

        /// <summary>
        /// 掃描座標改變，和後面差異
        /// </summary>
        class PostPositionDiffScanner
        {
            /// <summary>
            /// 目前處理物件
            /// </summary>
            List<HitObjectConvertParameter> _listObject;

            List<Vector2> _listResult = new List<Vector2>();

            /// <summary>
            /// 丟入參數
            /// </summary>
            public void SetInput(List<HitObjectConvertParameter> listObject)
            {
                _listObject = listObject;
            }

            /// <summary>
            /// 處理轉換問題
            /// </summary>
            public void Process()
            {
                for (int i = 0; i < _listObject.Count; i++)
                {
                    if (i < _listObject.Count - 1)
                    {
                        _listResult.Add(_listObject[i + 1].OsuHitObject.Position - _listObject[i].OsuHitObject.Position);
                    }
                    else
                    {
                        _listResult.Add(new Vector2(0, 0));
                    }
                }
            }

            public List<Vector2> GetResult()
            {
                return _listResult;
            }
        }

        /// <summary>
        /// 和前方差距幾個節拍
        /// </summary>
        class BeatPreDiffScanner
        {
            /// <summary>
            /// 目前處理物件
            /// </summary>
            List<HitObjectConvertParameter> _listObject;

            /// <summary>
            /// 目前結果
            /// </summary>
            List<double> _listResult = new List<double>();

            /// <summary>
            /// 單位用毫秒計算
            /// </summary>
            /// 
            List<double> _diffBeat;

            /// <summary>
            /// 丟入參數
            /// </summary>
            public void SetInput(List<HitObjectConvertParameter> listObject)
            {
                _listObject = listObject;
            }

            /// <summary>
            /// 處理轉換問題
            /// </summary>
            public void Process()
            {
                for (int i = 0; i < _listObject.Count; i++)
                {
                    if (i < _listObject.Count - 1)
                    {
                        _listResult.Add(_listObject[i + 1].OsuHitObject.StartTime - _listObject[i].OsuHitObject.StartTime);
                    }
                    else
                    {
                        _listResult.Add(0);
                    }
                }
            }


            public List<double> GetResult()
            {
                return _listResult;
            }
        }

    }
}
