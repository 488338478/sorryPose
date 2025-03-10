using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
{
    public int num ;
    public int r;
    public ref int GetNumRef()
    {
        return ref num;
    }

    public ref int GetRRef()
    {
        return ref r;
    }

    // Start is called before the first frame update
    void Start()
    {

        num =UnityEngine.Random.Range(1,5);
        r=UnityEngine.Random.Range(0, 2);
        Debug.Log(num);
        Debug.Log(r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
