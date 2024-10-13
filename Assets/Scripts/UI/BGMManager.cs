using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    public AudioSource sfxSource; // 효과음 전용 AudioSource
    public AudioSource BGMSource; // BGM 전용 AudioSource
    public AudioClip[] soundClips; // 사운드 클립 배열
    public Slider sfxVolumeSlider; // 슬라이더 UI 연결
    public Slider BGMVolumeSlider; // 슬라이더 UI 연결
    public static BGMManager Instance { get; private set;}
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // 슬라이더 값 초기화 (0 ~ 1)
        sfxVolumeSlider.value = sfxSource.volume;
        
        // 슬라이더 값이 변경될 때마다 오디오 볼륨 변경
        sfxVolumeSlider.onValueChanged.AddListener(SfxSetVolume);

        BGMVolumeSlider.value = BGMSource.volume;
        BGMVolumeSlider.onValueChanged.AddListener(BGMSetVolume);
    }

    void SfxSetVolume(float value)
    {
        sfxSource.volume = value;
    }

    void BGMSetVolume(float value)
    {
        BGMSource.volume = value; // 오디오 소스의 볼륨 조절
    }

    // 특정 사운드 클립 재생 함수
    public void PlaySound(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < soundClips.Length)
        {
            sfxSource.clip = soundClips[clipIndex]; // 해당 인덱스의 클립을 설정
            sfxSource.Play(); // 설정된 클립 재생
        }
        else
        {
            Debug.LogWarning("Invalid clip index: " + clipIndex);
        }
    }
}