using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static EnemyLogic;
//thi
public class EnemyLogic : MonoBehaviour
{


    public MakePose makePose;
    public MakePose.sorryList sl;

    public Num n;
    public Num r;

    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;
    public Sprite Sprite7;
    public Sprite Sprite8;

    private SpriteRenderer spriteRenderer;


    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        ref int a = ref n.GetNumRef();
        ref int b = ref r.GetRRef();
        switch (a)
        {
            case 1:
                if (b == 0)
                    spriteRenderer.sprite = Sprite1;
                else
                    spriteRenderer.sprite = Sprite5;

                break;
            case 2:
                if (b == 0)
                    spriteRenderer.sprite = Sprite2;
                else
                    spriteRenderer.sprite = Sprite6;
                break;

            case 3:
                if (b == 0)
                    spriteRenderer.sprite = Sprite3;
                else
                    spriteRenderer.sprite = Sprite7;
                break;

            case 4:
                if (b == 0)
                    spriteRenderer.sprite = Sprite4;
                else
                    spriteRenderer.sprite = Sprite8;
                break;
        }
    }



}