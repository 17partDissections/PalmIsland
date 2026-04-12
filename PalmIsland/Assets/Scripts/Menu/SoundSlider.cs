using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Q17pD.PalmIsland
{
    public class SoundSlider : MonoBehaviour
    {
        [SerializeField] private SoundType _sliderType;
        [SerializeField] private TextMeshProUGUI _handleValue;
        [SerializeField] private AudioHandler _audioHandler;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            string key = _sliderType == SoundType.Music ? "MusicSliderValue" : "SFXSliderValue";
            _slider.value = PlayerPrefs.GetFloat(key);
        }
        public void ChangeValue()
        {
            if (_sliderType == SoundType.Music) _audioHandler.SetMusicVolumeFromSlider(_slider.value);
            else _audioHandler.SetSFXVolumeFromSlider(_slider.value);
            _handleValue.text = (Math.Round((_slider.value * 100), 0)).ToString();
        }
        public void Save()
        {
            string key = _sliderType == SoundType.Music ? "MusicSliderValue" : "SFXSliderValue";
            PlayerPrefs.SetFloat(key, _slider.value);
            _audioHandler.Save();
        }
        public void Revert()
        {
            _slider.value = PlayerPrefs.GetFloat(_sliderType == SoundType.Music ? "MusicSliderValue" : "SFXSliderValue");
            _audioHandler.Revert();
        }
    }
}

