using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundClips; // 사운드 클립 배열
    public Slider volumeSlider; // 슬라이더 UI 연결
    public static BGMManager Instance { get; private set;}

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

    // 특정 사운드 클립 재생 함수
    public void PlaySound(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < soundClips.Length)
        {
            audioSource.clip = soundClips[clipIndex]; // 해당 인덱스의 클립을 설정
            audioSource.Play(); // 설정된 클립 재생
        }
        else
        {
            Debug.LogWarning("Invalid clip index: " + clipIndex);
        }
    }
}