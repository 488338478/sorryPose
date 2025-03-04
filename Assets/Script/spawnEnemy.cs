using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class spawnEnemy : MonoBehaviour
{
    Queue<GameObject> enemyList= new Queue<GameObject>();//存储敌人的队列
    public MakePose makePose;//用于与player通信
    int ExsistEnemy =0;//检测是否所有敌人被打倒
    public GameObject enemy;//
    int OnceSpawnCounter = 0;//存储每一次生成多少个敌人
    private Transform BaseTransform;

    // Start is called before the first frame update
    void Start()
    {
        BaseTransform = transform;
        MakePose.posed += KillEnemy;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count==0)
        {
            BaseTransform = gameObject.transform;
            GameObject tmpEnemy;
            OnceSpawnCounter = Random.Range(1, 5);
            for(int i = 0; i < OnceSpawnCounter; i++)
            {

                tmpEnemy = Instantiate(enemy);//生成敌人
                tmpEnemy.transform.position=BaseTransform.position;//设置敌人位置
                enemyList.Enqueue(tmpEnemy);//入队
                Debug.Log(BaseTransform.transform.position.y);
                BaseTransform.Translate(new Vector3(0, 1, 0), Space.World);
                

            }
        }
    }
    bool KillEnemy(int sl)
    {
        GameObject DestroyedEnemy;
        int tmp = (int)enemyList.Peek().GetComponent<enemyLogic>().power;
        if (tmp == sl&&!enemyList.IsUnityNull()){
            DestroyedEnemy = enemyList.Dequeue();   
            GameObject.Destroy(DestroyedEnemy); 
        }
 

        return true;
    }
}
