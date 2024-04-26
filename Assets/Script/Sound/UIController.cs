using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    float musicVolume, sfxVolume;
    public Toggle toggleMusicButton, toggleSFXButton;

    private void Start()
    {
        // Save music setting for further use 
        ApplyMusicVolume(); // Start music volume as playerprefs
        ApplySFXVolume(); // Start sfx volume as playerprefs
        // Load toggle button state from PlayerPrefs
        bool isMusicMuted = PlayerPrefs.GetInt("IsMusicMuted", 0) == 1;
        // Set toggle button state based on PlayerPrefs value
        toggleMusicButton.isOn = isMusicMuted;
        bool isSFXMuted = PlayerPrefs.GetInt("IsSFXMuted", 0) == 1;
        // Set toggle button state based on PlayerPrefs value
        toggleSFXButton.isOn = isSFXMuted;
    }

    public void ToggleMusic()
    {
        bool isMutedMusic = toggleMusicButton.isOn; // Get the current state of the toggle button
        AudioManager.Instance.ToggleMusic(); // Mute or unmute music volume
        // Save the toggle button state to PlayerPrefs
        PlayerPrefs.SetInt("IsMusicMuted", isMutedMusic ? 1 : 0);
        // Apply changes
        PlayerPrefs.Save();
        
    }

    public void ToggleSFX()
    {
        bool isMutedSFX = toggleSFXButton.isOn; // Get the current state of the toggle button
        AudioManager.Instance.ToggleSFX(); // Mute or unmute sfx volume
        // Save the toggle button state to PlayerPrefs
        PlayerPrefs.SetInt("isSFXMuted", isMutedSFX ? 1 : 0);
        // Apply changes
        PlayerPrefs.Save();

    }

    public void MusicVolume()
    {
        musicVolume = _musicSlider.value;
        AudioManager.Instance.MusicVolume(musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // save the updated value to the playerPrefs
    }

    public void SFXVolume()
    {
        sfxVolume = _sfxSlider.value;
        AudioManager.Instance.SFXVolume(sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume); // save the updated value to the playerPrefs
    }

    private void ApplyMusicVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.1f); // take music volume from playerprefs if its not exist take default value
        _musicSlider.value = musicVolume; // update slider value
        AudioManager.Instance.MusicVolume(musicVolume); // update MusicVolume on audioManager
    }

    private void ApplySFXVolume()
    {
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.1f); // take music volume from playerprefs if its not exist take default value
        _sfxSlider.value = sfxVolume; // update slider value
        AudioManager.Instance.SFXVolume(sfxVolume); // update SFXVolume on audioManager
    }
}