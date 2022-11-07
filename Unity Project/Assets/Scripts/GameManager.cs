using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;
    public Button _FlyButton;

    void EventOnClickFlyButton()
    {
        if (_DroneController.IsIdle())
            _DroneController.TakeOff();
    }

    void Start()
    {
        _FlyButton.onClick.AddListener(EventOnClickFlyButton);
    }

    void Update()
    {
        float speedX = Input.GetAxis("Horizontal");
        float speedZ = Input.GetAxis("Vertical");

        _DroneController.Move(speedX, speedZ);
    }
}
