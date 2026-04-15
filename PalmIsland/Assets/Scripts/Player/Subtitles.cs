using DFTGames.Localization;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Q17pD.PalmIsland.Player
{
    public class Subtitles : MonoBehaviour
    {
        private LocalizeTMPro _text;
        private UIHighlight _bgHighlight, _textHighlight;
        private bool _busy;
        private WaitForSeconds _cooldown;

        public void Start() 
        {
            _bgHighlight = GetComponentInChildren<Image>().GetComponent<UIHighlight>();
            _text = GetComponentInChildren<LocalizeTMPro>(); _textHighlight = _text.GetComponent<UIHighlight>();
            _cooldown = new WaitForSeconds(0.5f);
        }
        public bool Subtitle(string key, float time = 3)
        {
            if (_busy) return false;
            _busy = true;
            StartCoroutine(SubtitleCoroutine(key, new WaitForSeconds(time)));
            return true;
        }
        private IEnumerator SubtitleCoroutine(string key, WaitForSeconds sleep)
        {
            _text.localizationKey = key; _text.UpdateLocale();
            _bgHighlight.HighlightImage(0.58f); _textHighlight.HighlightTMP();
            yield return sleep;
            _bgHighlight.UnHighlightImage(); _textHighlight.UnHighlightTMP();
            yield return _cooldown;
            _busy = false;
        }
    }
}
