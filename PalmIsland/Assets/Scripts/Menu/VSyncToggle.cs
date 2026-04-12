using UnityEngine;
using UnityEngine.UI;

namespace Q17pD.PalmIsland.Menu
{
    public class VSyncToggle : MonoBehaviour
    {
        private Toggle _toggle;
        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.isOn = PlayerPrefs.GetInt("VSyncToggleValue") == 1;
        }
        public void ChangeValue() { SetVSync(_toggle.isOn ? 1 : 0); }
        public void Save() { PlayerPrefs.SetInt("VSyncToggleValue", _toggle.isOn ? 1 : 0); }
        public void Revert()
        {
            int value = PlayerPrefs.GetInt("VSyncToggleValue");
            _toggle.isOn = value == 1 ? true : false;
            SetVSync(value);
        }
        private void SetVSync(int value) { QualitySettings.vSyncCount = value; }
    }
}
