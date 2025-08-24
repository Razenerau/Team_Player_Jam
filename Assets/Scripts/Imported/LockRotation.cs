using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion initialRotation;
    private Vector3 initialLocalPosition;

    void Start()
    {
        // Store the initial rotation
        initialRotation = transform.rotation;
        initialLocalPosition = transform.localPosition;


        // Optional: Freeze rotation if Rigidbody is present
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        // Force rotation to stay fixed
        transform.rotation = initialRotation;
        transform.localPosition = initialLocalPosition;
    }

}
