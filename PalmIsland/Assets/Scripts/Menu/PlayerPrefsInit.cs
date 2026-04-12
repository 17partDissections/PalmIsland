using UnityEngine;

namespace Q17pD.PalmIsland.Menu
{
    public class PlayerPrefsInit : MonoBehaviour
    {
        //just an init for playerprefs vars if player ran a game in the first time
        //and also list of all playerprefs vars in PalmIsland namespace
        private void Start()
        {
            if(PlayerPrefs.GetInt("Inited") == 0)
            {
                PlayerPrefs.SetInt("LangIndex", 0);
                PlayerPrefs.SetInt("MusicVolume", 1);
                PlayerPrefs.SetInt("SFXVolume", 1);
                PlayerPrefs.SetInt("MusicSliderValue", 1);
                PlayerPrefs.SetInt("SFXSldierValue", 1);
                PlayerPrefs.SetInt("ResolutionDropdownValue", 0);
                PlayerPrefs.SetInt("ScreenModeDropdownValue", 1);
                PlayerPrefs.SetInt("VSyncToggleValue", 0);
                PlayerPrefs.SetInt("SubtitlesToggleValue", 1);
            }
        }
    }
}
