using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class MakePose : MonoBehaviour
{
    public float rotationSpeed = 50f; // 傴廬堀業
    private float targetRotation = 0f; // 朕炎傴廬叔業
    private float currentRotation = 0f; // 輝念傴廬叔業

    public delegate bool OnSpaced(int a);//溜熔
    public static event OnSpaced posed;//並周
    public enum sorryList { sorry0 , sorry1, sorry2 , sorry3 , sorry4  };//旦訟耽嶽祇埜彜蓑
    Queue<sorryList> order;
    public sorryList sl;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //海梓章巧叔業幟愁延寄
        // 殊臥腎鯉囚頁倦梓和
        if (Input.GetKey(KeyCode.Space))
        {
            targetRotation = 180f; // 泌惚梓和腎鯉��朕炎傴廬叔業頁 180 業
        }
        else
        {
            targetRotation = 0f; // 防蝕腎鯉扮��朕炎傴廬叔業指欺 0

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (360 - transform.localEulerAngles.z)
            {
                case float n when (n > 0 && n < 30):
                    Debug.Log("ごめんなさい");
                    sl = sorryList.sorry0;
                    posed.Invoke((int)sl);
                    break;
                case float n when (n > 30 && n < 60):
                    sl = sorryList.sorry1;
                    posed.Invoke((int)sl);
                    Debug.Log("すみません"); break;
                case float n when (n > 60 && n < 90):
                    sl = sorryList.sorry2;
                    posed.Invoke((int)sl);
                    Debug.Log("云輝にすみません"); break;
                case float n when (n > 90 && n < 120):
                    sl = sorryList.sorry3;
                    posed.Invoke((int)sl);
                    Debug.Log("賦し�Uありません"); break;
                case float n when (n > 120 && n < 150):
                    sl = sorryList.sorry4;
                    posed.Invoke((int)sl);
                    Debug.Log("賦し�Uございません"); break;
                default:
                    Debug.Log(Mathf.Abs(transform.localEulerAngles.z)); break;
            }
        }

        // 峠錆傴廬麗悶
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);

        // 哘喘傴廬欺麗悶
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);




        }

    
}
