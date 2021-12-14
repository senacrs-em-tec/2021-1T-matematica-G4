using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text multiplierText;
    public float score;
    public float multiplier;
    float finalScore;
    void Start(){
        score = 0;
        multiplier = 1;
    }
    void Update(){
        finalScore = score;
        scoreText.text = "" + finalScore;
        multiplierText.text = multiplier +"x";
    }

}
