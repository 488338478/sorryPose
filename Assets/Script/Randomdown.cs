using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyLogic;



public class Randomdown : MonoBehaviour
{
    // Start is called before the first frame update


    public MakePose makePose;
    public MakePose.sorryList sl;

    public Num n;

    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;

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
        ref int a  = ref n.GetNumRef();
        switch (a)
        {
            case 1:
                spriteRenderer.sprite = Sprite1;

                break;
            case 2:
                spriteRenderer.sprite = Sprite2;
                break;

            case 3:
                spriteRenderer.sprite = Sprite3;
                break;

            case 4:
                spriteRenderer.sprite = Sprite4;
                break;
        }
    }




}
