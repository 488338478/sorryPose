using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
{
    public int num ;
    public ref int GetNumRef()
    {
        return ref num;
    }

        // Start is called before the first frame update
        void Start()
    {

        num =UnityEngine.Random.Range(1, 5);
        Debug.Log(num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
