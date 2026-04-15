using UnityEngine;
using UnityEngine.UI;

namespace Q17pD.PalmIsland.Menu
{
    public class SubtitlesToggle : MonoBehaviour
    {
        [SerializeField] private string _key;
        private Toggle _toggle;
        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.isOn = PlayerPrefs.GetInt(_key) == 1;
        }
        public void Save() { PlayerPrefs.SetInt(_key, _toggle.isOn ? 1 : 0); }
        public void Revert() { _toggle.isOn = PlayerPrefs.GetInt(_key) == 1 ? true : false; }
    }
}
