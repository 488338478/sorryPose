using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class generateEnemy : MonoBehaviour
{
    Queue<GameObject> enemyList = new Queue<GameObject>();//�洢���˵Ķ���
    public MakePose makePose;//������playerͨ��
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
        tmpEnemy = Instantiate(enemy);//���ɵ���
        tmpEnemy.transform.position = BaseTransform.position;//���õ���λ��
        enemyList.Enqueue(tmpEnemy);//���
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
            Debug.Log($"���ĵ÷��ǣ�{ score}");
        }


        return true;
    }
}
