using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class MakePose : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 50f; // 旋转速度
    public float backSpeed = 50f;//返回速度
    private float targetRotation = 0f; // 目标旋转角度
    private float currentRotation = 0f; // 当前旋转角度

    public delegate bool OnSpaced(int a);//委托
    public static event OnSpaced posed;//事件
    public enum sorryList {  sorry0, sorry1, sorry2 , sorry3 , sorry4  };//枚举每种道歉状态
    Queue<sorryList> order;
    public sorryList sl;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //长按鞠躬角度逐渐变大
        // 检查空格键是否按下
        if (Input.GetKey(KeyCode.Space))
        {
            targetRotation = 180f; // 如果按下空格，目标旋转角度是 180 度
            speed = rotationSpeed;
        }
        else
        {
            targetRotation = 0f; // 松开空格时，目标旋转角度回到 0
            speed = backSpeed;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (360 - transform.localEulerAngles.z)
            {
                case float n when (n > 0 && n < 45):
                    sl = sorryList.sorry1;
                    posed.Invoke((int)sl);
                    Debug.Log("すみません"); break;
                case float n when (n > 45 && n < 90):
                    sl = sorryList.sorry2;
                    posed.Invoke((int)sl);
                    Debug.Log("本当にすみません"); break;
                case float n when (n > 90 && n < 135):
                    sl = sorryList.sorry3;
                    posed.Invoke((int)sl);
                    Debug.Log("申し訳ありません"); break;
                case float n when (n > 135 && n < 180):
                    sl = sorryList.sorry4;
                    posed.Invoke((int)sl);
                    Debug.Log("申し訳ございません"); break;
                default:
                    Debug.Log(Mathf.Abs(transform.localEulerAngles.z)); break;
            }
        }

        // 平滑旋转物体
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * speed);

        // 应用旋转到物体
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);
        }

}
