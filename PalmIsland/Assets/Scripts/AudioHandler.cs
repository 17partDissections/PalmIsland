using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Q17pD
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private AudioSource _music;
        [SerializeField] private AudioSource _SFXAudioSourcePrefab;
        private List<AudioSource> _activeSFXSources = new List<AudioSource>();
        private List<AudioSource> _availableSFXSources = new List<AudioSource>();
        private int _tempMusicValue;
        private int _tempSFXValue;

        private void Start()
        {
            _audioMixerGroup.audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
            _audioMixerGroup.audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }
        private void Update()
        {
            for (int i = _activeSFXSources.Count - 1; i >= 0; i--) if (!_activeSFXSources[i].isPlaying) ReturnSourceToPool(_activeSFXSources[i]);
        }
        public AudioSource PlaySFX(AudioClip clip, float volume = 1f, bool loop = false)
        {
            if (clip == null) return null;

            AudioSource source = GetAvailableSFXSource();
            source.clip = clip;
            source.loop = loop;
            source.volume = volume > 0 ? volume : source.volume;

            source.Play();
            _activeSFXSources.Add(source);

            return source;
        }
        public AudioSource PlayMusic(AudioClip clip, float volume = 1f, bool loop = true)
        {
            if (clip == null) return null;

            _music.clip = clip;
            _music.loop = loop;
            if (volume > 0)
                _music.volume = volume;

            _music.Play();
            return _music;
        }
        public void StopSound(AudioSource source)
        {
            if (source != null && _activeSFXSources.Contains(source))
            {
                source.Stop();
                ReturnSourceToPool(source);
            }
        }
        public void StopAllSFX()
        {
            foreach (var source in _activeSFXSources.ToArray())
            {
                if (source != null)
                {
                    source.Stop();
                    ReturnSourceToPool(source);
                }
            }
        }
        public void StopAllMusic() { _music.Stop(); }
        private AudioSource GetAvailableSFXSource()
        {
            foreach (var source in _availableSFXSources)
            {
                if (source != null && !source.isPlaying)
                {
                    _availableSFXSources.Remove(source);
                    return source;
                }
            }
            AudioSource newSource = Instantiate(_SFXAudioSourcePrefab, transform);
            newSource.outputAudioMixerGroup = _audioMixerGroup;
            return newSource;
        }
        private void ReturnSourceToPool(AudioSource source)
        {
            if (source != null)
            {
                source.Stop();
                source.clip = null;
                _activeSFXSources.Remove(source);
                if (!_availableSFXSources.Contains(source)) _availableSFXSources.Add(source);
            }
        }
        public void OnMasterVolumeValueChanged(float percent) { _audioMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, percent)); }
        public void OnMusicVolumeValueChanged(float percent) { _audioMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, percent)); }
        public void OnSFXVolumeValueChanged(float percent) { _audioMixerGroup.audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 0, percent)); }
        public void OnMusicVolumeValueChangedBySlider(UnityEngine.UI.Slider slider)
        {
            var percent = slider.value;
            _audioMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, percent));
            PlayerPrefs.SetFloat("MusicSlider", percent);
        }
        public void OnSFXVolumeValueChangedBySlider(UnityEngine.UI.Slider slider)
        {
            var percent = slider.value;
            _audioMixerGroup.audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 0, percent));
            PlayerPrefs.SetFloat("SFXSlider", percent);
        }
        public void TempChangeMusicValue(int value) { _tempMusicValue = value; }
        public void TempChangeSFXValue(int value) { _tempSFXValue = value; }
        public void CompletelyChangeValues()
        {
            _audioMixerGroup.audioMixer.SetFloat("MusicVolume", _tempMusicValue);
            _audioMixerGroup.audioMixer.SetFloat("SFXVolume", _tempSFXValue);
            Save();
        }
        private void Save()
        {
            _audioMixerGroup.audioMixer.GetFloat("MusicVolume", out float mValue);
            PlayerPrefs.SetFloat("MusicVolume", mValue);
            _audioMixerGroup.audioMixer.GetFloat("SFXVolume", out float sfxValue);
            PlayerPrefs.SetFloat("SFXVolume", sfxValue);
        }
    }
}