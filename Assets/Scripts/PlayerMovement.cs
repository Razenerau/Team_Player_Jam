using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles 2D player movement and rotation based on input.
/// Supports two players with separate input axes.
/// </summary>
public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D _rb;

    [Header("Player Settings")]
    public bool isPlayerOne = true;   // True if this is player 1, false for player 2
    public float xSpeed = 3f;         // Horizontal movement speed
    public float ySpeed = 3f;         // Vertical movement speed
    public float turnSpeed = 100f;

    [Header("Smoothing Rotation")]
    public float smoothingFactor = 20f;
    public Vector2 smoothedVelocity = Vector2.zero;
    public float lastDirection = 0;

    // Called when the game starts
    private void Start() { _rb = GetComponent<Rigidbody2D>(); }

    // Called once per frame
    private void FixedUpdate() {
        // Get player input
        float xInput = 0f;
        float yInput = 0f;

        if (isPlayerOne) {
            xInput = Input.GetAxis("Horizontal_P1");
            yInput = Input.GetAxis("Vertical_P1");
        }
        else {
            xInput = Input.GetAxis("Horizontal_P2");
            yInput = Input.GetAxis("Vertical_P2");
        }

        // Apply movement to the Rigidbody
        _rb.velocity = new Vector2(xInput * xSpeed, yInput * ySpeed);
        float newAngle = 0;

        // Rotate the player to face the direction of movement
        Vector2 movement = new Vector2(xInput, yInput);
        smoothedVelocity = Vector2.Lerp(smoothedVelocity, movement, Time.deltaTime * smoothingFactor);

        if (smoothedVelocity.sqrMagnitude > 0.01f)
        {
            // Calculate the targetAngle in degrees (0° = up, clockwise rotation)
            float targetAngle = Mathf.Atan2(smoothedVelocity.y, smoothedVelocity.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = transform.eulerAngles.z;

            // Smoothly rotate at a fixed speed
            newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, turnSpeed * Time.deltaTime);

            lastDirection = newAngle;
        }
        else
        {

            newAngle = lastDirection;
        }

        transform.rotation = Quaternion.Euler(0, 0, newAngle);
    }

    /// <summary>
    /// Returns the player's current velocity
    /// </summary>
    public Vector2 GetVelocity() {
        return _rb.velocity;
    }
}