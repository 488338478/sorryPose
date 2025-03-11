using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public MakePose mk;
    SpriteRenderer gb;
    public Sprite[] sp;
    public AudioClip[] ac;
    private AudioSource audiosou;
    int number=0;
    void Start()
    {
        MakePose.audio += AudioEffect;
        gb = mk.GetComponent<SpriteRenderer>();
        audiosou = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        MakePose.audio -= AudioEffect;
    }
    private bool AudioEffect(int a)

    {
        foreach(var i in sp)
        {
            if (i == gb.sprite)
            {
                break;
            }
            number++;
        }
        audiosou.PlayOneShot(ac[number]);
        number = 0;
        return true;
    }
}
