using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Time in seconds before the object is destroyed
    [SerializeField] float destroyDelay = 5f; 

    void Start()
    {
        // Destroy this GameObject after the specified delay
        Destroy(gameObject, destroyDelay);
    }
}
