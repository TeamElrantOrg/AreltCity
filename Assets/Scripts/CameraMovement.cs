using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The Camera's transform position
    public Transform target;

    // Smoothing amount for Lerp
    public float smoothing;
    
    // Max and Min position (Boundaries)
    public Vector2 maxPosition;
    public Vector2 minPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        // If the camera's position isn't the same as the target specified in the editor
        if (transform.position != target.position)
        {
            // Make a Vector3 with the Target Position
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Clamp movement inside Boundaries
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Move the camera's transform to the target position using Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
