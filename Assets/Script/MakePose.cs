using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class MakePose : MonoBehaviour
{
    public float rotationSpeed = 50f; // ��ת�ٶ�
    private float targetRotation = 0f; // Ŀ����ת�Ƕ�
    private float currentRotation = 0f; // ��ǰ��ת�Ƕ�

    public delegate bool OnSpaced(int a);//ί��
    public static event OnSpaced posed;//�¼�
    public enum sorryList { sorry0 , sorry1, sorry2 , sorry3 , sorry4  };//ö��ÿ�ֵ�Ǹ״̬
    Queue<sorryList> order;
    public sorryList sl;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //�����Ϲ��Ƕ��𽥱��
        // ���ո���Ƿ���
        if (Input.GetKey(KeyCode.Space))
        {
            targetRotation = 180f; // ������¿ո�Ŀ����ת�Ƕ��� 180 ��
        }
        else
        {
            targetRotation = 0f; // �ɿ��ո�ʱ��Ŀ����ת�ǶȻص� 0

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (360 - transform.localEulerAngles.z)
            {
                case float n when (n > 0 && n < 30):
                    Debug.Log("�����ʤ���");
                    sl = sorryList.sorry0;
                    posed.Invoke((int)sl);
                    break;
                case float n when (n > 30 && n < 60):
                    sl = sorryList.sorry1;
                    posed.Invoke((int)sl);
                    Debug.Log("���ߤޤ���"); break;
                case float n when (n > 60 && n < 90):
                    sl = sorryList.sorry2;
                    posed.Invoke((int)sl);
                    Debug.Log("�����ˤ��ߤޤ���"); break;
                case float n when (n > 90 && n < 120):
                    sl = sorryList.sorry3;
                    posed.Invoke((int)sl);
                    Debug.Log("�ꤷ�U����ޤ���"); break;
                case float n when (n > 120 && n < 150):
                    sl = sorryList.sorry4;
                    posed.Invoke((int)sl);
                    Debug.Log("�ꤷ�U�������ޤ���"); break;
                default:
                    Debug.Log(Mathf.Abs(transform.localEulerAngles.z)); break;
            }
        }

        // ƽ����ת����
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Ӧ����ת������
        transform.rotation = Quaternion.Euler(0, 0, -currentRotation);




        }

    
}
