using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // �������ֵ���Ƶ����
    private AudioSource audioSource;

    private static AudioManager instance;

    void Awake()
    {
        // ȷ����Ƶ������ֻ��һ��ʵ��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ��ֹ�ڳ����л�ʱ����
        }
        else
        {
            Destroy(gameObject);  // ����Ѵ���ʵ���������ٵ�ǰ��AudioManager
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // ���ű�������
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;  // ���ñ�������ѭ������
            audioSource.Play();
        }
    }

    // ��ѡ���ֹͣ�������ֵĹ���
    public void StopBackgroundMusic()
    {
        audioSource.Stop();
    }
}
