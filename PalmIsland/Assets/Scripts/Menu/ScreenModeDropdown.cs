using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Q17pD.PalmIsland.Menu
{
    public class ScreenModeDropdown : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;
        private List<FullScreenMode> _windowModes;

        void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _windowModes = new List<FullScreenMode>
            {
                FullScreenMode.Windowed,
                FullScreenMode.FullScreenWindow,
                FullScreenMode.ExclusiveFullScreen,
                FullScreenMode.MaximizedWindow
            };
            _dropdown.value = PlayerPrefs.GetInt("ScreenModeDropdownValue");
            SetWindowMode(_dropdown.value);
        }
        public void ChangeValue() { SetWindowMode(_dropdown.value); }
        public void Save() { PlayerPrefs.SetInt("ScreenModeDropdownValue", _dropdown.value); }
        public void Revert()
        {
            int value = PlayerPrefs.GetInt("ScreenModeDropdownValue");
            _dropdown.value = value;
            SetWindowMode(value);
        }
        private void SetWindowMode(int index) { Screen.fullScreenMode = _windowModes[index]; }
    }
}