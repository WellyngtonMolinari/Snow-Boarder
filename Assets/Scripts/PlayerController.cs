using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    private Vector2 _previousRight;
    private float _angle;
    int flips=0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        _previousRight = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
        UpdateFlipCount();
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void UpdateFlipCount()
    {
        // get this frame's right vector
        var currentRight = transform.right;

        // compare it to the previous frame's right vector and sum up the delta angle
        _angle += Vector2.SignedAngle(_previousRight, currentRight);

        // store the current right vector for the next frame to compare
        _previousRight = currentRight;

        // did the angle reach +/- 360 ?
        if (Mathf.Abs(_angle) >= 360f)
        {   
            flips++;
            Debug.Log("you did: " + flips);

            // if _angle > 360 subtract 360
            // if _angle < -360 add 360
            _angle -= 360f * Mathf.Sign(_angle);
        }
    }
}
