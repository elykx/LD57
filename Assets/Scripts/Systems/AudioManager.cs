using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider scrollbar;

    private void Start()
    {
        audioMixer.GetFloat("Volume", out var value);
        Debug.Log(value);
        scrollbar.value = Mathf.InverseLerp(-80f, 0f, value);

        scrollbar.onValueChanged.AddListener(SetVolume);

    }

    public void SetVolume(float value)
    {
        float volume = Mathf.Lerp(-80f, 0f, value);
        audioMixer.SetFloat("Volume", volume);
    }
}