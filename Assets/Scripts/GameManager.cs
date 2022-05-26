using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject winGameScreen;
    public GameObject looseGameScreen;

    bool levelStarted = false;
    public bool LevelStarted { get => levelStarted; set => levelStarted = value; }

    //bool gameOver = false;
    //public bool GameOver { get => gameOver; set => gameOver = value; }

    bool winGame = false;
    public bool WinGame { get => winGame; set => winGame = value; }

    bool gamePlaying = false;
    public bool GamePlaying { get => gamePlaying; set => gamePlaying = value; }

    public float delay = 1f;

    public static GameManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        StartCoroutine("MainGameLoop");

    }
    void Update()
    {

    }

    IEnumerator MainGameLoop()
    {
        yield return StartCoroutine("StartLevelRoutine");
        yield return StartCoroutine("PlayLevelRoutine");
        yield return StartCoroutine("EndLevelRoutine");
    }

    IEnumerator StartLevelRoutine()
    {
        Debug.Log("StartLevelRoutine");
        Time.timeScale = 0;
        winGame = false;

        while (!levelStarted)
        {
            //show statr screeen and do other preps before level start
            //user press button to start
            //levelStarted = true;
            yield return null;
        }

    }

    IEnumerator PlayLevelRoutine()
    {
        Debug.Log("PlayLevelRoutine");

        gamePlaying = true;
        Time.timeScale = 1;
        while (gamePlaying)
        {
            yield return null;
        }
    }

    IEnumerator EndLevelRoutine()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("EndLevelRoutine");
        
        Time.timeScale = 0;
        if (winGame)
            WinningSequence();
        else
            GameOverSequence();

        yield return null;
    }

    private void GameOverSequence()
    {
        Debug.Log("End Game");

        looseGameScreen.SetActive(true);
    }

    private void WinningSequence()
    {
        Debug.Log("Win Game");

        winGameScreen.SetActive(true);
    }

}