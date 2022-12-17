using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager current;
    void Start()
    {
        current = this;
        
    }

    private void Update()
    {
        checkForScoreGoal();
    }

    private void checkForScoreGoal()
    {
        if (gameEvents.current.totalScore >= 100 && gameEvents.current.totalScore < 400) 
        {
            if (SceneManager.GetActiveScene().buildIndex == 1) return;

            gameEvents.current.levelOneHS = gameEvents.current.totalScore;
            SaveLoad.current.writeSaveFile();
            SceneManager.LoadScene(1);
        }
        if (gameEvents.current.totalScore >= 400) 
        {
            //level 2 save
            SceneManager.LoadScene(2);
        } 

    }

    public void loadLoseScreen()
    {
        SceneManager.LoadScene(3);
    }

}
