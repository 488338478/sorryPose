using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
//thi
public class enemyLogic : MonoBehaviour
{
    public MakePose makePose;
    public EventTrigger getScore;
    public Sprite[] newSprites;
    public enum Power { friend,workmate,leader,boss}
    public Power power;

    // Start is called before the first frame update
    void Start()
    {//生成上司时随机决定其身份
        power = (Power)Random.Range(0, 3);
        // 获取物体上的 SpriteRenderer 组件
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // 确保组件存在
        if (spriteRenderer != null && newSprites != null)
        {
            // 更换为新的图片
            spriteRenderer.sprite = newSprites[(int)power];
        }
        else
        {
            Debug.LogWarning("SpriteRenderer 或 newSprite 未设置！");
        }

        switch (power)
        {
            case Power.friend:
                gameObject.GetComponent<Sprite>();
                break;
            case Power.workmate:
                break;
            case Power.leader:
                break;
            case Power.boss:
                break;
            default:
            break;
        }
        if (makePose != null)
        {
        }
        MakePose.posed += addScore;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool addScore(int sl)
    {
        if ((int)power == sl)
        {
            Destroy(gameObject);
        }
            return (int)power == sl;
    }
}
