using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class spawnEnemy : MonoBehaviour
{
    Queue<GameObject> enemyList= new Queue<GameObject>();//�洢���˵Ķ���
    public MakePose makePose;//������playerͨ��
    int ExsistEnemy =0;//����Ƿ����е��˱���
    public GameObject enemy;//
    int OnceSpawnCounter = 0;//�洢ÿһ�����ɶ��ٸ�����
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

                tmpEnemy = Instantiate(enemy);//���ɵ���
                tmpEnemy.transform.position=BaseTransform.position;//���õ���λ��
                enemyList.Enqueue(tmpEnemy);//���
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
