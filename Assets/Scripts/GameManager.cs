using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //[HideInInspector] public bool readyToRestart = false;

    public GameObject[] enemySpawns;
    //public GameObject[] enemys;
    public GameObject gameOverPanel;
    public GameObject scorePanel;
    public GameObject spawnLight;
    public Text highScoreDisplay;

    public FloatVariable score;
    public FloatVariable highScore;
    public BoolVariable playerIsHit;
    public BoolVariable readyToRestart;
    public Level[] levels;

    private Text scoreText;
    private int currentLevelNumber;

    void Start()
    {
        playerIsHit.value = false;
        readyToRestart.value = false;
        score.value = 0;
        currentLevelNumber = 0;

        scoreText = scorePanel.GetComponentInChildren<Text>();

        StartCoroutine(SpawnLight());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && readyToRestart.value)
        {
            SceneManager.LoadScene("SampleScene");
        }

        // Check Score for levelling
        if (score.value < 10)
            currentLevelNumber = 0;
        else if(score.value < 20)
            currentLevelNumber = 1;
        else if(score.value < 30)
            currentLevelNumber = 2;
        //else if (score.value > 30)
            //currentLevelNumber = 3;


        // Rewrite Score
        scoreText.text = string.Format("{0}", score.value);

        // If player is hit, game over
        if (playerIsHit.value)
            GameOver();

    }

    IEnumerator SpawnLight()
    {
        while (!readyToRestart.value)
        {
            yield return new WaitForSeconds(1.0f);
            int spawnNumber = Random.Range(0, enemySpawns.Length);
            Instantiate(spawnLight, enemySpawns[spawnNumber].transform.position, Quaternion.identity);
            StartCoroutine(SpawnEnemy(enemySpawns[spawnNumber].transform.position));
            //Debug.Log("Spawn!");
        }
    }

    IEnumerator SpawnEnemy(Vector3 position)
    {
        
        yield return new WaitForSeconds(1.0f);
        int enemyNumber = Random.Range(0, levels[currentLevelNumber].enemys.Length);
        Instantiate(levels[currentLevelNumber].enemys[enemyNumber], position, Quaternion.identity);
        
    }

    

    public void GameOver()
    {
        if (highScore.value < score.value)
            highScore.value = score.value;

        highScoreDisplay.text = string.Format("{0}", highScore.value);
        readyToRestart.value = true;
        gameOverPanel.SetActive(true);
    }

}
