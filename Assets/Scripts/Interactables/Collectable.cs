using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    #region Collectable Variables and References
    [Header("Collectable Variables and References")]
    [SerializeField] public bool hasBeenTouched = false;
    [SerializeField] public bool isActive = true;

    [SerializeField] private Rigidbody myRb;
    [SerializeField] private Material disabledMaterial;

    //Enum for the player to use to determine what kind of collectable its colliding with
    public enum  collectableType { A, B, C}
    [SerializeField] public collectableType myType;
    #endregion

    void Update()
    {
        if (hasBeenTouched && isActive)
        {
            decreaseScale();
        }
    }

    #region Collectable Controller Functions
    private void decreaseScale()
    {
        if (transform.localScale.x >= 0)
        {
            transform.localScale -= Vector3.one * Time.deltaTime;

        }
        else { InvokeRepeating("destroyMe", 25.0f, 1); }
    }
    #endregion

    #region disable collectable
    // this is triggered when interacting with the same collectable twice and this prevents the object from being interacted with
    public void DisableObject()
    {
        isActive = false;
        myRb = gameObject.GetComponent<Rigidbody>();
        myRb.useGravity = true;
        gameObject.GetComponent<MeshRenderer>().material = disabledMaterial;

    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            gameEvents.current.decreaseSpawnCount();
            collision.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
        } 
    }

    //After the collectable has been scaled down, the object waits 25 seconds then destroys itself
    private void destroyMe()
    {
        GameObject.Destroy(gameObject);
    }

}
