using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//计时器
public class Timer : MonoBehaviour
{
    public GenerateEnemy ge;
    [SerializeField] private float timer = 30f;//计时总时长为30秒

    public Text timerText;//组件

    private bool isTimeOut = false;//时间是不是到了

    bool canCilck = false;//重新开始按钮能不能点



    private void _Timer()//计时器
    {
        if (isTimeOut == false)//如果时间没到
        {
            timer -= Time.deltaTime;//一直减去流逝的时间
            timerText.text = timer.ToString("F1");//显示时间
        }
        if (timer <= 0)//如果时间到了
        {
            isTimeOut = true;
            timerText.text = "0.0";//显示0.0，不再继续计时
            SceneManager.LoadScene(4);//跳转到结束场景
            MakePose.posed -= ge.KillEnemy;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()//游戏开始，立即调用计时器开始倒计时
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

