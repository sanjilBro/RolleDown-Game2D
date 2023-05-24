using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField]
    private GameObject background,
                        impactParticle;

    [SerializeField]
    private TMP_Text score, 
                    backgroundScore,
                    backgroundHighScore;
    private int scoreInt = 0;
    private string highScore = "highscore";

    private Coroutine scoreUpdate;
    
    private void Start()
    {
        scoreUpdate = StartCoroutine(Timer(0f));
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnGameOver += ShowGameOverUI;
        playerController.OnCollision += InstantiateParticles;
        
    }

    private void InstantiateParticles(Transform transformObj)
    {
        Instantiate(impactParticle, transformObj.position, Quaternion.identity);
        
    }
   

    private void ShowGameOverUI() {
        background.SetActive(true);
        StopCoroutine(scoreUpdate);
        UpdateScore();
    }

    private IEnumerator Timer(float waitTime){
        yield return new WaitForSeconds(waitTime);
        scoreInt++;
        score.text = scoreInt.ToString();
        scoreUpdate = StartCoroutine(Timer(1f));
    }

    private void UpdateScore()
    {
        backgroundScore.text = "Your Score: " + scoreInt.ToString();
        if (scoreInt > PlayerPrefs.GetInt(highScore, 0)) PlayerPrefs.SetInt(highScore, scoreInt);
        backgroundHighScore.text = "High Score: " + PlayerPrefs.GetInt(highScore).ToString();
    }
}
