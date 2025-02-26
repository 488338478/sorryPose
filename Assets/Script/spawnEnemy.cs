using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    bool isExsistEnemy=false;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isExsistEnemy)
        {
            Instantiate(enemy);
            isExsistEnemy=true;
        }
        else if (enemy.IsDestroyed())
        {
            isExsistEnemy = false;
        }

    }
}
