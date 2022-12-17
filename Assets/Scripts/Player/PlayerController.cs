using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Score Related Variables
    [Header("Score Variables")]
    [SerializeField] private int baseIncreaseValue;
    [SerializeField] private int baseDecreaseValue;
    [HideInInspector] private int consecutiveErrors;
    [SerializeField] public Collectable col;
    [SerializeField] public Collectable refCol;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        #region Colliding with Collectables
        if (collision.gameObject.tag == "Collectable")
        {
            col = collision.gameObject.GetComponent<Collectable>();
            if (col.isActive == false)
            {
                gameManager.current.loadLoseScreen();
            }

            if (refCol == null || col.myType != refCol.myType)
            {
                if (gameEvents.current.ConsecutiveFails > 0) gameEvents.current.ConsecutiveFails = 0;
            
                gameEvents.current.IncreaseScoreUI(baseIncreaseValue);
                refCol = collision.gameObject.GetComponent<Collectable>();
                refCol.hasBeenTouched = true;
                return;
            }
            else if (collision.gameObject.GetComponent<Collectable>().myType == col.myType)
            {
                gameEvents.current.DecreaseScoreUI(baseDecreaseValue, consecutiveErrors);

                col.DisableObject();
                consecutiveErrors++;

                return;
            }
        }
        #endregion
    }
}
