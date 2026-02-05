using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startSpawnTime;
    public float waveWait;

    public TextMeshProUGUI scoreText;
    public int score;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    private bool gameOver;
    private bool restart;

    private void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
    IEnumerator SpawnValues()
    {
        int level = -3;
        hazard.GetComponent<Mover>().boltSpeed = level;
        yield return new WaitForSeconds(startSpawnTime);
        while (true)
        {
            hazard.GetComponent<Mover>().boltSpeed -= 1;
            
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-3, 3), 0, 1);
                Quaternion spawnRotation = Quaternion.identity; //rotasyon ayarlamalarý yapýlýr ama biz rotasyon ayarýný hali hazýrda yapmýþtýk bu yüzden identity dedik

                Instantiate(hazard, spawnPosition, spawnRotation);


                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait); // diðer round a geçmesi için bekletiyoruz
            if (gameOver == true)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }


    }
    public void updateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
    private void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        restart = false;
        gameOver = false;
        StartCoroutine(SpawnValues());
        
    }
}
