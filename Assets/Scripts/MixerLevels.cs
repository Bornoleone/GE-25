using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;

namespace AAR
{
    public class MixerLevels : MonoBehaviour
    {
        public Slider masterSlider;
		public Slider musicSlider;
		public Slider sfxSlider;

        public string textToParse = "Slider";

        public AudioMixer masterMixer;

		private void Start()
		{
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            masterMixer.SetFloat("MasterVolume", Mathf.Log10(masterSlider.value) * 20);
			masterMixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
			masterMixer.SetFloat("SFXVolume", Mathf.Log10(sfxSlider.value) * 20);

			print("sliderName: " + masterSlider.name + " volume:" + masterSlider.value);
		}

        public void SetAnyVolume(Slider slider)
        {
            float sliderVolume = Mathf.Log10(slider.value) * 20;
            string sliderName = slider.name.Substring(0,slider.name.Length-textToParse.Length); //Works only when your slider object name is ExposedParameterNameSlider (e.g. MusicVolumeSlider)
            print(sliderName);
            masterMixer.SetFloat(sliderName, sliderVolume);
			PlayerPrefs.SetFloat(sliderName, slider.value);
		}

		//public void SetMasterVolumeLevel(float volumeLevel)
  //      {
  //          masterMixer.SetFloat("MasterVolume", Mathf.Log10(volumeLevel)*20);
  //          PlayerPrefs.SetFloat("MasterVolume", volumeLevel);
  //      }

		public void SetMusicVolumeLevel(float volumeLevel)
		{
			masterMixer.SetFloat("MusicVolume", Mathf.Log10(volumeLevel) * 20);
			PlayerPrefs.SetFloat("MusicVolume", volumeLevel);
		}

		public void SetSFXVolumeLevel(float volumeLevel)
        {
            masterMixer.SetFloat("SFXVolume", Mathf.Log10(volumeLevel) * 20);
            PlayerPrefs.SetFloat("SFXVolume", volumeLevel);
        }

    }
}
