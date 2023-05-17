using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;


private void OnCollisionEnter(Collision other) 
{   
        score += 5;
        Debug.Log("Score = " + score);
        scoreText.text = "Score: " + score;        
     
}


}
