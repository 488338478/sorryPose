using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEnemy : MonoBehaviour
{
    Queue<GameObject> enemyList = new Queue<GameObject>();//存储敌人的队列
    public MakePose makePose;//用于与player通信
    public GameObject enemy;
    private Transform BaseTransform;
    public static int score = 0;
    public int health = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
  

    public Num n;
    public Num r;

    private SpriteRenderer spriteRenderer;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;
    public Sprite Sprite7;
    public Sprite Sprite8;

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
       
    }

    public bool KillEnemy(int sl)
    {
        ref int a = ref n.GetNumRef();
        ref int b = ref r.GetRRef();
        if (a <= sl && !enemyList.IsUnityNull())
        {
            score += 10;
            a = Random.Range(1, 5);
            b = Random.Range(0, 2);  
            Debug.Log($"a：{a}");
            Debug.Log($"b：{b}");
            Debug.Log($"您的得分是：{score}");
            Debug.Log($"您的血量是:{health}");

            switch (a)
            {

                case 1:
                    if (b == 0)
                        spriteRenderer.sprite = Sprite1;
                    else
                        spriteRenderer.sprite = Sprite5;

                    break;
                case 2:
                    if (b == 0)
                        spriteRenderer.sprite = Sprite2;
                    else
                        spriteRenderer.sprite = Sprite6;
                    break;

                case 3:
                    if (b == 0)
                        spriteRenderer.sprite = Sprite3;
                    else
                        spriteRenderer.sprite = Sprite7;
                    break;

                case 4:
                    if (b == 0)
                        spriteRenderer.sprite = Sprite4;
                    else
                        spriteRenderer.sprite = Sprite8;
                    break;
            }
        }
        else
        {
            health -= 1;
            Debug.Log($"您的血量是:{health}");
            
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
            MakePose.posed-= KillEnemy;
            SceneManager.LoadScene(4);
            
        }
    
        return true;
    }


}
