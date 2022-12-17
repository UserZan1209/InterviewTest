using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playAgain : MonoBehaviour
{
    public void playAgaain() 
    {
        SceneManager.LoadScene(0);
    }
}
