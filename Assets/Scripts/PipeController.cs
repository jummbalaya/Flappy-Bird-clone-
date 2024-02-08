using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2.0f;
    // Time in seconds before the object is destroyed
    [SerializeField] float destroyDelay = 5f;

    void Start()
    {
        // Destroy this GameObject after the specified delay
        DestroyPipe();
    }

    private void Update()
    {
        MoveLeft();
    }
    
    void MoveLeft()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
    }
    void DestroyPipe()
    {
        Destroy(gameObject, destroyDelay);
    }
    
}
