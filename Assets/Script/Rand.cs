using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyLogic;

public class Rand : MonoBehaviour
{
    // Start is called before the first frame update


    public MakePose makePose;
    public MakePose.sorryList sl;

    public Num n;
    public Num r;

    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;

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
                    spriteRenderer.sprite = Sprite5;
                break;

            case 3:
                if (b == 0)
                    spriteRenderer.sprite = Sprite3;
                else
                    spriteRenderer.sprite = Sprite5;
                break;

            case 4:
                if (b == 0)
                    spriteRenderer.sprite = Sprite4;
                else
                    spriteRenderer.sprite = Sprite5;
                break;
        }
    }
}
