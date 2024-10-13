using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public Slider volumeSlider; // 슬라이더 UI 연결
    public AudioSource audioSource; // 오디오 소스 연결

    void Start()
    {
        // 슬라이더 값 초기화 (0 ~ 1)
        volumeSlider.value = audioSource.volume;
        
        // 슬라이더 값이 변경될 때마다 오디오 볼륨 변경
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        audioSource.volume = value; // 오디오 소스의 볼륨 조절
    }
}
