using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    #region UI score Variables
    [Header("Score UI Variables and References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int scoreValue;
    #endregion

    void Awake() { initScoreController(); }

    private void Start()
    {
        //listeners
        gameEvents.current.IncreaseScore += increaseScore;
        gameEvents.current.DecreaseScore += decreaseScore;
    }

    private void initScoreController()
    {
        scoreValue = 0;
        updateScoreUI(scoreValue);
    }

    #region updating the score on the UI
    private void updateScoreUI(float sVal)
    {
        scoreText.text = sVal.ToString();
        gameEvents.current.totalScore = scoreValue;
    }

    public void increaseScore()
    {
        scoreValue += gameEvents.current.increaseVal;

        updateScoreUI(scoreValue);
    }

    public void decreaseScore()
    {
        scoreValue -= gameEvents.current.decreaseVal * gameEvents.current.ConsecutiveFails;

        updateScoreUI(scoreValue);
    }
    #endregion
}
