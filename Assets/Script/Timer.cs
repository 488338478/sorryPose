using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//��ʱ��
public class Timer : MonoBehaviour
{
    public GenerateEnemy ge;
    [SerializeField] private float timer = 30f;//��ʱ��ʱ��Ϊ30��

    public Text timerText;//���

    private bool isTimeOut = false;//ʱ���ǲ��ǵ���

    bool canCilck = false;//���¿�ʼ��ť�ܲ��ܵ�



    private void _Timer()//��ʱ��
    {
        if (isTimeOut == false)//���ʱ��û��
        {
            timer -= Time.deltaTime;//һֱ��ȥ���ŵ�ʱ��
            timerText.text = timer.ToString("F1");//��ʾʱ��
        }
        if (timer <= 0)//���ʱ�䵽��
        {
            isTimeOut = true;
            timerText.text = "0.0";//��ʾ0.0�����ټ�����ʱ
            SceneManager.LoadScene(4);//��ת����������
            MakePose.posed -= ge.KillEnemy;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()//��Ϸ��ʼ���������ü�ʱ����ʼ����ʱ
    {
        _Timer();
    }



    public void Reset()
    {
        if (canCilck)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            MakePose.posed -= ge.KillEnemy;
        }
    }


}

