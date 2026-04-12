using UnityEngine;
using UnityEngine.UI;

namespace Q17pD.PalmIsland.Menu
{
    public class SubtitlesToggle : MonoBehaviour
    {
        private Toggle _toggle;
        [SerializeField] private GameObject _subtitles; //not necessary. only for game scene
        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.isOn = PlayerPrefs.GetInt("SubtitlesToggleValue") == 1;
        }
        public void ChangeValue() { if (_subtitles != null) _subtitles.SetActive(_toggle.isOn); }
        public void Save() { PlayerPrefs.SetInt("SubtitlesToggleValue", _toggle.isOn ? 1 : 0); }
        public void Revert() { _toggle.isOn = PlayerPrefs.GetInt("SubtitlesToggleValue") == 1 ? true : false; }
    }
}
