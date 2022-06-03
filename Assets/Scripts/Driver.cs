using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float speed = 15f; // serialize used to show in inspector, but not in code
    public float steerSpeed = 300f; // public used to show in inspector, and in code
    public float slowSpeed = 15f;
    public float boostSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("slow speed activated");
        speed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost")
        {
            Debug.Log("boost speed activated");
            speed = boostSpeed;
        }
    }
}
