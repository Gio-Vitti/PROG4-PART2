using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Move forward when mouse clicked
       if(Mouse.current.leftButton.isPressed)
        {
            transform.position += transform.forward * speed;
        }

        //Rotate with scroll wheel
        Vector2 scroll = Mouse.current.scroll.readValue();

        if (scroll.y > 0)
        {
            transform.Rotate(Vector3.up * speed);
        }

        if (scroll.y < 0)
        {
            transform.Rotate(Vector3.up * speed);
        }
    }
}
