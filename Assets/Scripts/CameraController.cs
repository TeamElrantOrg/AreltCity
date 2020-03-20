using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    public static bool cameraExists;
     Vector2 viewPortSize;
     Camera cam;
    public float viewPortFactor;
    private Vector3 currentVelocity;
    public float followDuration;
    public float maximumFollowSpeed;
    public Transform player;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       

        if (!cameraExists)
        {
            cameraExists = true;
            
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
        viewPortSize = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - cam.ScreenToWorldPoint(Vector2.zero) * viewPortFactor;
        targetPosition = player.position - new Vector3(0, 0, 10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, followDuration, maximumFollowSpeed);
    }
    void OnDrawGizmos()
    {
        Color c = Color.red;
        c.a = 0.3f;
        Gizmos.DrawCube(transform.position, viewPortSize);



    }
}
