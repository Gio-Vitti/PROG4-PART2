using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private bool lastClickedLeft = true;
    public Transform body;

    public Collider car;
    public CinemachineCamera cam;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       //Move forward when mouse clicked
       if(Mouse.current.leftButton.wasPressedThisFrame && !lastClickedLeft)
        {
            transform.position += transform.forward * moveSpeed;
            lastClickedLeft = true;
        }

        if (Mouse.current.rightButton.wasPressedThisFrame && lastClickedLeft)
        {
            transform.position += transform.forward * moveSpeed;
            lastClickedLeft = false;
        }

        //Rotate with scroll wheel
        Vector2 scroll = Mouse.current.scroll.ReadValue();

        if (scroll.y > 0)
        {
            transform.Rotate(Vector3.up * turnSpeed);
        }

        if (scroll.y < 0)
        {
            transform.Rotate(Vector3.up * -turnSpeed);
        }

        //Simple character animations
        if (lastClickedLeft)
        {
            body.eulerAngles = new Vector3(0, transform.eulerAngles.y, 30);
        }

        //Simple character animations
        if (!lastClickedLeft)
        {
            body.eulerAngles = new Vector3(0, transform.eulerAngles.y, -30);
        }

        //if (Physics.BoxCast(transform.position, Vector3.one, Vector3.zero) == )
       // {

        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) {
            rb.freezeRotation = false;
            cam.enabled = false;
        }
    }
}
