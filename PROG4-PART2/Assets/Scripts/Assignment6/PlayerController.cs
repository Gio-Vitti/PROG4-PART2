using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private bool lastClickedLeft = true;
    public Transform body;

    public Collider car;
    public CinemachineCamera cam;

    private Rigidbody rb;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    private int hp = 3;

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
     
    }

    //Enemy collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bear")) {
            transform.position = new Vector3(0, transform.position.y, -15);
        }

        if (other.CompareTag("Car"))
        {
            transform.position = new Vector3(0, transform.position.y, -15);
        }
    }
}
