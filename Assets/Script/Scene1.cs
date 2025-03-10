using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene01();
        
    }

    public void Scene01()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            
        }
        
    }

}
