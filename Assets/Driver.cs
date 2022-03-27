using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] int turnSpeed = 150;

    [SerializeField] int accelarationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float accelarationAmount = Input.GetAxis("Vertical") * accelarationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, accelarationAmount, 0);
    }
}
