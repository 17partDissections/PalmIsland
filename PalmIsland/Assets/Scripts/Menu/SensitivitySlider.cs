using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Q17pD.PalmIsland
{
    public class SensitivitySlider : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _handleValue;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.value = PlayerPrefs.GetFloat("SensitivitySliderValue");
        }
        public void ChangeValue() { _handleValue.text = (Math.Round((_slider.value * 100), 0)).ToString(); }
        public void Save() { PlayerPrefs.SetFloat("SensitivitySliderValue", _slider.value); }
        public void Revert() { _slider.value = PlayerPrefs.GetFloat("SensitivitySliderValue"); }
    }
}
