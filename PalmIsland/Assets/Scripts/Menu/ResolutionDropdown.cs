using TMPro;
using UnityEngine;

namespace Q17pD.PalmIsland.Menu
{

    public class ResolutionDropdown : MonoBehaviour
    {
        [System.Serializable] private class ResolutionData { public int width; public int height; }
        [SerializeField] private ResolutionData[] _resolutions;
        private TMP_Dropdown _dropdown;

        void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.value = PlayerPrefs.GetInt("ResolutionDropdownValue");
            SetResolution(_dropdown.value);
        }
        public void ChangeValue() { SetResolution(_dropdown.value); }
        public void Save() { PlayerPrefs.SetInt("ResolutionDropdownValue", _dropdown.value); }
        public void Revert()
        {
            int value = PlayerPrefs.GetInt("ResolutionDropdownValue");
            _dropdown.value = value;
            SetResolution(value);
        }
        public void SetResolution(int index) { Screen.SetResolution(_resolutions[index].width, _resolutions[index].height, Screen.fullScreen); }
    }
}