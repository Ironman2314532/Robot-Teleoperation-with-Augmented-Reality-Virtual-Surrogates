using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;
    public Button _FlyButton;
    public Button _LandButton;

    void EventOnClickFlyButton()
    {
        if (_DroneController.IsIdle())
        {
            _DroneController.TakeOff();
            _FlyButton.gameObject.SetActive(false);
        }
    }

    void EventOnClickLandButton()
    {
        if (_DroneController.IsFlying())
        {
            _DroneController.Land();
            _FlyButton.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        _FlyButton.onClick.AddListener(EventOnClickFlyButton);
        _LandButton.onClick.AddListener(EventOnClickLandButton);
        _LandButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_DroneController.IsFlying())
        {
            _LandButton.gameObject.SetActive(true);
            Debug.Log("Activating Land Button");
        }
        float speedX = Input.GetAxis("Horizontal");
        float speedZ = Input.GetAxis("Vertical");
        _DroneController.Move(speedX, speedZ);
    }
}
