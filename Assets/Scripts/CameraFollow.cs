using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed;

    // Minimum and maximum camera movement boundaries
    public float minX, maxX;
    public float minY, maxY;

    void Start()
    {
        // Initialization if needed
    }

    void FixedUpdate()
    {
        // Check that a target has been assigned
        if (Target != null)
        {
            Vector3 newCamPosition = Vector3.Lerp(
                transform.position,
                Target.position,
                Time.deltaTime * Cameraspeed
            );

            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);

            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}
