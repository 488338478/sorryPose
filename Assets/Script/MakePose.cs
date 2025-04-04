using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class MakePose : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 50f; // 傴廬堀業
    public float backSpeed = 50f;//卦指堀業
    private float targetRotation = 0f; // 朕炎傴廬叔業
    private float currentRotation = 0f; // 輝念傴廬叔業

    public delegate bool OnSpaced(int a);//溜熔
    public static event OnSpaced posed;//並周
    public static event OnSpaced audio;//並周
    public enum sorryList {  sorry0, sorry1, sorry2 , sorry3 , sorry4  };//旦訟耽嶽祇埜彜蓑
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
            speed = rotationSpeed;
        }
        else
        {
            targetRotation = 0f; // 防蝕腎鯉扮��朕炎傴廬叔業指欺 0
            speed = backSpeed;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (360 - transform.localEulerAngles.z)
            {
                case float n when (n > 0 && n < 45):
                    sl = sorryList.sorry1;
                    audio.Invoke((int)sl);
                    posed.Invoke((int)sl);
                    Debug.Log("すみません"); break;
                case float n when (n > 45 && n < 90):
                    sl = sorryList.sorry2;
                    audio.Invoke((int)sl);
                    posed.Invoke((int)sl);
                    Debug.Log("云輝にすみません"); break;
                case float n when (n > 90 && n < 135):
                    sl = sorryList.sorry3;
                    audio.Invoke((int)sl);
                    posed.Invoke((int)sl);
                    Debug.Log("賦し�Uありません"); break;
                case float n when (n > 135 && n < 180):
                    sl = sorryList.sorry4;
                    audio.Invoke((int)sl);
                    posed.Invoke((int)sl);
                    Debug.Log("賦し�Uございません"); break;
                default:
                    Debug.Log(Mathf.Abs(transform.localEulerAngles.z)); break;
            }
        }

        // 峠錆傴廬麗悶
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * speed);

        // 哘喘傴廬欺麗悶
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
        }

}
