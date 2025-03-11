using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // 背景音乐的音频剪辑
    private AudioSource audioSource;

    private static AudioManager instance;

    void Awake()
    {
        // 确保音频管理器只有一个实例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 防止在场景切换时销毁
        }
        else
        {
            Destroy(gameObject);  // 如果已存在实例，则销毁当前的AudioManager
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 播放背景音乐
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;  // 设置背景音乐循环播放
            audioSource.Play();
        }
    }

    // 可选择的停止背景音乐的功能
    public void StopBackgroundMusic()
    {
        audioSource.Stop();
    }
}
