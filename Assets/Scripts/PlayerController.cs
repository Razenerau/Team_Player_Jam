using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData PlayerData;

    // Start is called before the first frame update
    void Awake()
    {
       PlayerData = gameObject.GetComponent<PlayerData>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(PlayerData.Up))
        {
            PlayerData.Vertical += PlayerData.SpeedSensetivity;
        }
        if(Input.GetKey(PlayerData.Down))
        {
            PlayerData.Vertical += -PlayerData.SpeedSensetivity;
        }
        if (Input.GetKey(PlayerData.Left))
        {
            PlayerData.Horizontal += -PlayerData.SpeedSensetivity;
        }
        if (Input.GetKey(PlayerData.Right))
        {
            PlayerData.Horizontal += PlayerData.SpeedSensetivity;
        }

        PlayerData.Horizontal = Mathf.Clamp(PlayerData.Horizontal, -1f, 1f);
        PlayerData.Vertical = Mathf.Clamp(PlayerData.Vertical, -1f, 1f);

        if(!Input.GetKey(PlayerData.Left) && !Input.GetKey(PlayerData.Right))
        {
            PlayerData.Horizontal = 0f;
        }
        if (!Input.GetKey(PlayerData.Up) && !Input.GetKey(PlayerData.Down))
        {
            PlayerData.Vertical = 0f;
        }
    }

    private void FixedUpdate()
    {
        float xVelocity = PlayerData.Horizontal * PlayerData.Speed;
        float yVelocity = PlayerData.Vertical * PlayerData.Speed;
        PlayerData.Rigidbody.velocity = new Vector2 (xVelocity, yVelocity);
    }
}
