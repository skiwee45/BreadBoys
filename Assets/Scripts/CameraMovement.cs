using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    public float smoothing;
    public Vector2 max;
    public Vector2 min;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.position != target.position)
        {
            //in order to maintain its own z position but follow player for x and y
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            //bind camera to map
            targetPosition.x = Mathf.Clamp(target.position.x, min.x, max.x);
            targetPosition.y = Mathf.Clamp(target.position.y, min.y, max.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //moves certain percentage to target
        }
    }
}
