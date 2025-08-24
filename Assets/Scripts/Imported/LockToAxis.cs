using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToAxis : MonoBehaviour
{
    private Vector3 lockedPosition;

    void Start()
    {
        // Store initial X and Z values
        lockedPosition = gameObject.transform.position;
    }

    void LateUpdate()
    {
        // Only allow movement in Y axis
        transform.position = new Vector3(lockedPosition.x, transform.position.y, lockedPosition.z);
    }

}
