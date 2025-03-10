using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEnemy : MonoBehaviour
{
    Queue<GameObject> enemyList = new Queue<GameObject>();//�洢���˵Ķ���
    public MakePose makePose;//������playerͨ��
    public GameObject enemy;
    private Transform BaseTransform;
    public static int score = 0;
    public int health = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
  

    public Num n;

    private SpriteRenderer spriteRenderer;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 3;
        BaseTransform = transform;
        MakePose.posed += KillEnemy;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyList.Count <= 0)
        {
            GeneEnemy();
            Debug.Log($"����������{enemyList.Count}");

        }

    }

    void GeneEnemy()
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
        ref int a = ref n.GetNumRef();
        if (a == sl && !enemyList.IsUnityNull())
        {
            score += 10;
            a = Random.Range(1, 4);
            Debug.Log(a);
            Debug.Log($"���ĵ÷��ǣ�{score}");
            Debug.Log($"����Ѫ����:{health}");

            switch (a)
            {
                case 1:
                    spriteRenderer.sprite = Sprite1;

                    break;
                case 2:
                    spriteRenderer.sprite = Sprite2;
                    break;

                case 3:
                    spriteRenderer.sprite = Sprite3;
                    break;

                case 4:
                    spriteRenderer.sprite = Sprite4;
                    break;
            }
        }
        else
        {
            health -= 1;
            Debug.Log($"����Ѫ����:{health}");
            
            switch (health)
            {
                case 3:
                break;
                case 2:
                    Destroy(heart3);
                break;
                case 1:
                    Destroy(heart2);
                    break;
                case 0:
                    Destroy(heart1);
                    break;
                default:
                break;
            }
        }


        if (health <= 0)
        {
            health = 3;
            SceneManager.LoadScene(3);
            
        }
    
        return true;
    }


}
