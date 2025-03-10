using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyLogic;
using TMPro;



public class Howangry : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI howangry;
    public Num n;

    private void Start()
    {

    }
    private void Update()
    {
        ref int a = ref n.GetNumRef();
        switch (a)
        {
            case 1:
                howangry.text = "1";

                break;
            case 2:
                howangry.text = "2";
                break;

            case 3:
                howangry.text = "3";
                break;

            case 4:
                howangry.text = "4";
                break;
        }
    }

    }