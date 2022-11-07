using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;
    ControllerInput controls;
    public Button _FlyButton;
    public Button _LandButton;
    bool _drone_power_state = false;
    Vector2 translate_drone;

    void EventOnClickFlyButton()
    {
        if (_DroneController.IsIdle())
        {
            _DroneController.TakeOff();
            _FlyButton.gameObject.SetActive(false);
            _drone_power_state = true;
        }
    }

    void EventOnClickLandButton()
    {
        if (_DroneController.IsFlying())
        {
            _DroneController.Land();
            _LandButton.gameObject.SetActive(false);
            _drone_power_state = false;
        }
    }

    void power_switch_pressed()
    {
        _drone_power_state = !_drone_power_state;
        if (_drone_power_state)
            EventOnClickFlyButton();
        else
            EventOnClickLandButton();
    }


    void Awake()
    {
        controls = new ControllerInput();
        controls.Power.DronePowerSwitch.performed += ctx => power_switch_pressed();
        controls.Translate.Move.performed += ctx => translate_drone = ctx.ReadValue<Vector2>();
        controls.Translate.Move.canceled += CollectionExtensions => translate_drone = Vector2.zero;
    }

    void OnEnable()
    {
        controls.Power.Enable();
        controls.Translate.Enable();
    }

    void OnDisable()
    {
        controls.Power.Disable();
        controls.Translate.Disable();
    }

    void Start()
    {
        _FlyButton.onClick.AddListener(EventOnClickFlyButton);
        _LandButton.onClick.AddListener(EventOnClickLandButton);
        _LandButton.gameObject.SetActive(false);
        _FlyButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_DroneController.IsFlying())
            _LandButton.gameObject.SetActive(true);
        if (_DroneController.IsIdle())
            _FlyButton.gameObject.SetActive(true);
        _DroneController.Move(translate_drone.x, translate_drone.y);
    }
}
