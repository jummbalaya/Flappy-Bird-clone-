using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2.0f; 

    void Update()
    {
        // Move the camera to the right based on the scroll input speed
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
