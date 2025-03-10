using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GenePlayer : MonoBehaviour
{
    Queue<GameObject> playerList = new Queue<GameObject>();//队列
    public GameObject player;
    private Transform BaseTransform;

    public Num n;



    // Start is called before the first frame update
    void Start()
    {
        BaseTransform = transform;
        MakePose.posed += KillPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerList.Count == 0)
        {
            GenerPlayer();

        }
    }

    void GenerPlayer()
    {
        BaseTransform = gameObject.transform;
        GameObject tmpEnemy;
        tmpEnemy = Instantiate(player);//生成敌人
        tmpEnemy.transform.position = BaseTransform.position;//设置敌人位置
        playerList.Enqueue(tmpEnemy);//入队
        Debug.Log(BaseTransform.transform.position.y);

    }

    bool KillPlayer(int sl)
    {
        ref int a = ref n.GetNumRef();
        GameObject DestroyedPlayer;
        int tmp = a;
        if (tmp == sl && !playerList.IsUnityNull())
        {
            DestroyedPlayer = playerList.Dequeue();
            GameObject.Destroy(DestroyedPlayer);
    
        }
        return true;
    }
}
