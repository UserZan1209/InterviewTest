using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Movement Variables
    [Header("Player Variables")]
    [SerializeField] private float moveSpeed;
    [HideInInspector] private float xAxis;
    [HideInInspector] private float yAxis;
    #endregion

    //movement uses the fixed update function as the player gameobject uses a rigidbody
    void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        updateAxis();

        transform.Translate(xAxis * Time.deltaTime * moveSpeed, 0.0f, yAxis * Time.deltaTime * moveSpeed);

    }

    private void updateAxis()
    {
        #region Horizontal Axis
        xAxis = Input.GetAxis("Horizontal");
        #endregion
        #region Vertical Axis
        yAxis = Input.GetAxis("Vertical");
        #endregion
    }



}
