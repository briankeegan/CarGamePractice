using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] int turnSpeed = 150;
    [SerializeField] int accelarationSpeed = 5;
    [SerializeField] int pickUpSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float accelarationAmount = Input.GetAxis("Vertical") * (accelarationSpeed + pickUpSpeed) * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, accelarationAmount, 0);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Collidable")
        {
            // Loose your pickup if you have it!
            pickUpSpeed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);
        if (other.tag == "SpeedUp")
        {
            pickUpSpeed += 25;
        }
    }
}
