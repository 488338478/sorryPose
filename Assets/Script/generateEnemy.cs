using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class generateEnemy : MonoBehaviour
{
    Queue<GameObject> enemyList = new Queue<GameObject>();//存储敌人的队列
    public MakePose makePose;//用于与player通信
    public GameObject enemy;
    private Transform BaseTransform;
    public static int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        BaseTransform = transform;
        MakePose.posed += KillEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count == 0)
        {
            GenerateEnemy();

        }

    }

    void GenerateEnemy()
    {
        BaseTransform = gameObject.transform;
        GameObject tmpEnemy;
        tmpEnemy = Instantiate(enemy);//生成敌人
        tmpEnemy.transform.position = BaseTransform.position;//设置敌人位置
        enemyList.Enqueue(tmpEnemy);//入队
        Debug.Log(BaseTransform.transform.position.y);

    }


    bool KillEnemy(int sl)
    {
        GameObject DestroyedEnemy;
        int tmp = (int)enemyList.Peek().GetComponent<enemyLogic>().power;
        if (tmp == sl && !enemyList.IsUnityNull())
        {
            DestroyedEnemy = enemyList.Dequeue();
            GameObject.Destroy(DestroyedEnemy);
            score += 1;
            Debug.Log($"您的得分是：{ score}");
        }


        return true;
    }
}
