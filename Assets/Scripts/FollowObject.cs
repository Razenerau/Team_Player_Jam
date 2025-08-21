using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject ObjectToFollow;


    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = ObjectToFollow.transform.position;
    }
}
