using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] static float orginalMoveSpeed = 15f;
    [SerializeField] float moveSpeed = orginalMoveSpeed;
    [SerializeField] float maxSpeed = 30f;
    [SerializeField] float minSpeed = 10f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float bumpAndBoostRate = 1.25f;
    void Start()
    {
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = moveAmount != 0 ? -Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime : 0;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    private void OnCollisionEnter2D()
    {
        moveSpeed = Math.Min(orginalMoveSpeed, moveSpeed); ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Boost"))
        {
            moveSpeed = Math.Min(maxSpeed, moveSpeed * bumpAndBoostRate);
        }

        if (other.CompareTag("Bump"))
        {
            moveSpeed = Math.Max(minSpeed, moveSpeed / bumpAndBoostRate);
        }
    }
}
