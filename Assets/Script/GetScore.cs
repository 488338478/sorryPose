using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetScore : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public GenerateEnemy score;
    public int c;

    // Start is called before the first frame update
    void Start()
    {
        score=GetComponent<GenerateEnemy>();
        c = GenerateEnemy.score;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = " "+ c;
    }
}
