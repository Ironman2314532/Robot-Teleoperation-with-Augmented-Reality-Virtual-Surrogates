using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;


    void Update()
    {
        float speedX = Input.GetAxis("Horizontal");
        float speedZ = Input.GetAxis("Vertical");

        _DroneController.Move(speedX, speedZ);
    }
}
