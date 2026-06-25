using System;

namespace WinFormsApp1
{
    public class HangulAutomata
    {
        private string _result = "";
        private int _cho = -1;
        private int _jung = -1;
        private int _jong = -1;

        static readonly string[] Chosung = { "ㄱ", "ㄲ", "ㄴ", "ㄷ", "ㄸ", "ㄹ", "ㅁ", "ㅂ", "ㅃ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
        static readonly string[] Jungsung = { "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ", "ㅕ", "ㅖ", "ㅗ", "ㅘ", "ㅙ", "ㅚ", "ㅛ", "ㅜ", "ㅝ", "ㅞ", "ㅟ", "ㅠ", "ㅡ", "ㅢ", "ㅣ" };
        static readonly string[] Jongsung = { "", "ㄱ", "ㄲ", "ㄳ", "ㄴ", "ㄵ", "ㄶ", "ㄷ", "ㄹ", "ㄺ", "ㄻ", "ㄼ", "ㄽ", "ㄾ", "ㄿ", "ㅀ", "ㅁ", "ㅂ", "ㅄ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };

        public string GetResult() => _result + GetCurrent();

        private string GetCurrent()
        {
            if (_cho == -1) return "";
            if (_jung == -1) return Chosung[_cho];
            int jong = (_jong == -1) ? 0 : _jong;
            int code = 0xAC00 + (_cho * 21 + _jung) * 28 + jong;
            return ((char)code).ToString();
        }

        public void Input(string ch)
        {
            int choIdx = Array.IndexOf(Chosung, ch);
            int jungIdx = Array.IndexOf(Jungsung, ch);

            if (jungIdx >= 0)
                HandleJungsung(jungIdx);
            else if (choIdx >= 0)
                HandleChosung(choIdx);
        }

        private void HandleChosung(int choIdx)
        {
            if (_cho == -1)
            {
                // 아무것도 없음 → 초성 시작
                _cho = choIdx;
            }
            else if (_jung == -1)
            {
                // 초성만 있음 → 이전 초성 확정, 새 초성 시작
                _result += Chosung[_cho];
                _cho = choIdx;
            }
            else if (_jong == -1)
            {
                // 초성+중성 → 종성으로
                _jong = Array.IndexOf(Jongsung, Chosung[choIdx]);
                if (_jong == -1)
                {
                    // 종성 불가능한 자음이면 글자 확정 후 새 초성
                    _result += GetCurrent();
                    _cho = choIdx;
                    _jung = -1;
                    _jong = -1;
                }
            }
            else
            {
                // 초성+중성+종성 → 글자 확정, 종성을 새 초성으로
                _result += GetCurrent();
                _cho = choIdx;
                _jung = -1;
                _jong = -1;
            }
        }

        private void HandleJungsung(int jungIdx)
        {
            if (_cho == -1)
            {
                // 초성 없이 모음만 → 단독 모음
                _result += Jungsung[jungIdx];
            }
            else if (_jung == -1)
            {
                // 초성만 있음 → 중성 붙이기
                _jung = jungIdx;
            }
            else if (_jong == -1)
            {
                // 초성+중성 → 새 글자 시작
                _result += GetCurrent();
                _cho = -1;
                _jung = jungIdx;
            }
            else
            {
                // 초성+중성+종성 → 종성을 다음 초성으로 넘기고 모음 붙임
                int prevJong = _jong;
                _jong = -1;
                _result += GetCurrent();

                _cho = Array.IndexOf(Chosung, Jongsung[prevJong]);
                _jung = jungIdx;
                _jong = -1;
            }
        }

        public void Delete()
        {
            if (_jong != -1)
            {
                _jong = -1;
            }
            else if (_jung != -1)
            {
                _jung = -1;
            }
            else if (_cho != -1)
            {
                _cho = -1;
            }
            else if (_result.Length > 0)
            {
                _result = _result.Substring(0, _result.Length - 1);
            }
        }

        public void Clear()
        {
            _result = "";
            _cho = -1;
            _jung = -1;
            _jong = -1;
        }
    }
}