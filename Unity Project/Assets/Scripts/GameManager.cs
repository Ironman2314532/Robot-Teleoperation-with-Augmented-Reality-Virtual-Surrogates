using System.Collections;
using System.Collections.Generic;
using UnityEngine;//For Base Unity
using UnityEngine.UI;//For Canvas Editing
using UnityEngine.InputSystem;//For Controller Inputs
using TMPro; //For Text Editing

public class GameManager : MonoBehaviour
{
    public DroneController _PrimaryDrone;
    public DroneController _VirtualSurrogate;
    ControllerInput controls;
    public TextMeshProUGUI _ModeSelector;
    bool _virtual_surrogate_control_mode = true;
    Vector2 translate_drone;

    void power_switch_pressed()
    {
        if (!_virtual_surrogate_control_mode)
        {
            _PrimaryDrone._drone_power_state = !_PrimaryDrone._drone_power_state;
            _VirtualSurrogate._drone_power_state = _PrimaryDrone._drone_power_state;
            if (_PrimaryDrone._drone_power_state)
            {
                if (_PrimaryDrone.IsIdle())
                {
                    _PrimaryDrone.TakeOff();
                    _VirtualSurrogate.TakeOff();
                }
            }
            else
            {
                if (_PrimaryDrone.IsFlying())
                {
                    _PrimaryDrone.Land();
                    _VirtualSurrogate.Land();
                }
            }
        }
        else
        {
            _VirtualSurrogate._drone_power_state = !_VirtualSurrogate._drone_power_state;
            if (_VirtualSurrogate._drone_power_state)
            {
                if (_VirtualSurrogate.IsIdle())
                    _VirtualSurrogate.TakeOff();
            }
            else
            {
                if (_VirtualSurrogate.IsFlying())
                    _VirtualSurrogate.Land();
            }
        }
    }

    void save_way_point() { }
    void delete_way_point() { }
    void scroll_way_point() { }
    void change_mode()
    {
        _virtual_surrogate_control_mode = !_virtual_surrogate_control_mode;
        if (_virtual_surrogate_control_mode)
        {
            _ModeSelector.text = "Virtual Surrogate Control Mode";
            _ModeSelector.color = new Color32(0, 135, 62, 255);
            _VirtualSurrogate.DroneVisible(true);
        }
        else
        {
            _ModeSelector.text = "Real Time Control Mode";
            _ModeSelector.color = new Color32(128, 0, 0, 255);
            if (_PrimaryDrone.IsFlying())
            {
                if (_VirtualSurrogate.IsFlying())
                    return;
                else if (_VirtualSurrogate.IsIdle())
                    _VirtualSurrogate.TakeOff();
            }
            else if (_PrimaryDrone.IsIdle())
            {
                if (_VirtualSurrogate.IsFlying())
                    _VirtualSurrogate.Land();
                else if (_VirtualSurrogate.IsIdle())
                    return;
            }
            else { }

        }
    }


    void Awake()
    {
        controls = new ControllerInput();
        controls.Power.DronePowerSwitch.performed += ctx => power_switch_pressed();
        controls.Translate.Move.performed += ctx => translate_drone = ctx.ReadValue<Vector2>();
        controls.Translate.Move.canceled += CollectionExtensions => translate_drone = Vector2.zero;
        controls.WayPoint.SaveWayPoint.performed += ctx => save_way_point();
        controls.WayPoint.DeleteWayPoint.performed += ctx => delete_way_point();
        controls.WayPoint.ScrollWayPoint.performed += ctx => scroll_way_point();
        controls.ModeSelection.ChangeMode.performed += ctx => change_mode();

    }

    void OnEnable()
    {
        controls.Power.Enable();
        controls.Translate.Enable();
        controls.WayPoint.Enable();
        controls.ModeSelection.Enable();
    }

    void OnDisable()
    {
        controls.Power.Disable();
        controls.Translate.Disable();
        controls.WayPoint.Disable();
        controls.ModeSelection.Disable();
    }

    void Start()
    {
        _ModeSelector = FindObjectOfType<TextMeshProUGUI>();
        change_mode();
    }

    void Update()
    {
        if (_virtual_surrogate_control_mode)
            _VirtualSurrogate.Move(translate_drone.x, translate_drone.y);
        else
        {
            _PrimaryDrone.Move(translate_drone.x, translate_drone.y);
            _VirtualSurrogate.SetDroneLocation(_PrimaryDrone.GetDroneLocation());
        }
        Debug.Log("Primary Drone: " + _PrimaryDrone._State);
        Debug.Log("Virtual Surrogate: " + _VirtualSurrogate._State);
    }
}
