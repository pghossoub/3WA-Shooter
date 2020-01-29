using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector] public bool readyToRestart = false;

    public GameObject[] enemySpawns;
    public GameObject enemy;
    public GameObject gameOverPanel;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && readyToRestart)
        {
            SceneManager.LoadScene("SampleScene");
        }

        //int spawnNumber = Random.Range(0, enemySpawns.Length);

        
    }

    IEnumerator SpawnEnemy()
    {
        while (!readyToRestart) 
        {
            yield return new WaitForSeconds(1.0f);
            int spawnNumber = Random.Range(0, enemySpawns.Length);
            Instantiate(enemy, enemySpawns[spawnNumber].transform.position, Quaternion.identity);
            Debug.Log("Spawn!");
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

}
