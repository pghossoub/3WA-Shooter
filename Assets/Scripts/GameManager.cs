using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool readyToRestart = false;

    public GameObject[] enemySpawns;
    public GameObject[] enemys;
    public GameObject gameOverPanel;
    public GameObject scorePanel;

    private Text scoreText;
    private int score = 0;

    void Start()
    {
        scoreText = scorePanel.GetComponentInChildren<Text>();
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && readyToRestart)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    IEnumerator SpawnEnemy()
    {
        while (!readyToRestart) 
        {
            yield return new WaitForSeconds(1.0f);
            int spawnNumber = Random.Range(0, enemySpawns.Length);
            int enemyNumber = Random.Range(0, enemys.Length);
            Instantiate(enemys[enemyNumber], enemySpawns[spawnNumber].transform.position, Quaternion.identity);
            //Debug.Log("Spawn!");
        }
    }

    public void addScore()
    {
        score += 1;
        scoreText.text = string.Format("{0}", score);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

}
