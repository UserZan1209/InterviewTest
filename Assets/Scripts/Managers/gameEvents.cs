using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEvents : MonoBehaviour
{
    [HideInInspector] public static gameEvents current;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

    #region ScoreUI Actions

    [HideInInspector] public int increaseVal;

    public event Action IncreaseScore;
    public void IncreaseScoreUI(int val)
    {
        increaseVal = val;

        if(IncreaseScore != null)
        {
            IncreaseScore();
        }
    }

    [HideInInspector] public int decreaseVal;
    [HideInInspector] public int ConsecutiveFails;

    public event Action DecreaseScore;
    public void DecreaseScoreUI(int val, int conFails)
    {
        decreaseVal = val;
        ConsecutiveFails = conFails;
        DecreaseScore();
    }

    [SerializeField] public int totalScore;
    #endregion

    #region Collectable Actions

    public event Action DecreaseSpawnCount;
    public void decreaseSpawnCount()
    {
        if (DecreaseSpawnCount != null)
        {
            DecreaseSpawnCount();
        }
    }
    #endregion
    #region Save and Loading
    [HideInInspector] public int levelOneHS;
    #endregion
}
