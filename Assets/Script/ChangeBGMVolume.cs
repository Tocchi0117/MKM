using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class ChangeBGMVolume : MonoBehaviour
{
    public Slider slider;
    AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("BGM_Volume");
        slider.value = PlayerPrefs.GetFloat("BGM_Volume");
    }
    public void SoundSliderOnValueChange(float newSliderValue)
    {
        audioSource.volume = newSliderValue / slider.maxValue;
        PlayerPrefs.SetFloat("BGM_Volume", newSliderValue);
        PlayerPrefs.Save();
    }







}
