using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;//For Base Unity
using UnityEngine.UI;//For Canvas Editing
using UnityEngine.InputSystem;//For Controller Inputs
using TMPro; //For Text Editing

public class GameManager : MonoBehaviour
{
    public DroneController _PrimaryDrone;
    public DroneController _VirtualSurrogate;
    public WayPointManager WayPointManager;
    ControllerInput controls;
    bool _virtual_surrogate_control_mode = true;
    Vector3 translate_drone;
    [SerializeField] public TextMeshProUGUI _ModeSelector;
    public Camera MainCam;


    bool merge_position = false;
    bool retrace_path = false;

    void power_switch_pressed()
    {
        if (!_virtual_surrogate_control_mode)
        {
            _PrimaryDrone._drone_power_state = !_PrimaryDrone._drone_power_state;
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

    void save_way_point()
    {
        if (_virtual_surrogate_control_mode)
        {
            if (WayPointManager.current_way_point_location < 10)
            {
                Vector3 _pos = _VirtualSurrogate.GetDroneLocation();
                WayPointManager.set_waypoint(_pos);
            }
            else
                Debug.Log("All Way Point Markers Placed");
        }
    }

    void delete_way_point()
    {

    }
    void scroll_way_point()
    {

    }

    void retrace_way_points()
    {
        if (_virtual_surrogate_control_mode)
        {
            _VirtualSurrogate.SetDroneLocation(_PrimaryDrone.GetDroneLocation());
            _VirtualSurrogate._State = DroneController.DroneState.DRONE_STATE_WAY_POINT_FOLLOW;
            _VirtualSurrogate.current_waypoint_tracking_index = -1;
        }
    }
    void execute_way_points()
    {
        if (_virtual_surrogate_control_mode)
        {
            if (_PrimaryDrone.IsIdle())
                _PrimaryDrone.TakeOff();
            retrace_path = true;
        }
    }

    void change_mode()
    {
        _virtual_surrogate_control_mode = !_virtual_surrogate_control_mode;
        if (_virtual_surrogate_control_mode)
        {
            // display_way_point_info(true);
            _ModeSelector.text = "Virtual Surrogate Control Mode";
            _ModeSelector.color = new Color32(0, 135, 62, 255);
            if (_PrimaryDrone.IsFlying() && _VirtualSurrogate.IsIdle())
                _VirtualSurrogate.TakeOff();
            else if (_PrimaryDrone.IsIdle() && _VirtualSurrogate.IsFlying())
                _VirtualSurrogate.Land();
            merge_position = true;
            _VirtualSurrogate._SpeedMultipler = 4.0f;
        }
        else
        {
            _ModeSelector.text = "Real Time Control Mode";
            _ModeSelector.color = new Color32(128, 0, 0, 255);
            WayPointManager.clear_waypoints();
            if (_VirtualSurrogate.IsFlying() && _PrimaryDrone.IsIdle())
                _VirtualSurrogate.Land();
            else if (_PrimaryDrone.IsFlying() && _VirtualSurrogate.IsIdle())
                _VirtualSurrogate.TakeOff();
            merge_position = true;
            _VirtualSurrogate._SpeedMultipler = 10.0f;
            MainCam.transform.position = new Vector3(-6.097f, 3.4f, -9.831f);
        }
    }


    void Awake()
    {
        controls = new ControllerInput();
        controls.Power.DronePowerSwitch.performed += ctx => power_switch_pressed();
        controls.Translate.Move.performed += ctx => translate_drone = new Vector3(ctx.ReadValue<Vector2>()[0], 0, ctx.ReadValue<Vector2>()[1]);
        controls.Translate.Move.canceled += CollectionExtensions => translate_drone = Vector3.zero;
        controls.Translate.Height.performed += ctx => translate_drone = new Vector3(0, ctx.ReadValue<float>(), 0);
        controls.Translate.Height.canceled += CollectionExtensions => translate_drone = Vector3.zero;
        controls.WayPoint.SaveWayPoint.performed += ctx => save_way_point();
        controls.WayPoint.DeleteWayPoint.performed += ctx => delete_way_point();
        controls.WayPoint.ScrollWayPoint.performed += ctx => scroll_way_point();
        controls.WayPoint.RetraceWayPoints.performed += ctx => retrace_way_points();
        controls.WayPoint.ExecuteWayPoints.performed += ctx => execute_way_points();
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
        change_mode();
    }

    void Update()
    {
        if (_virtual_surrogate_control_mode)
        {
            _VirtualSurrogate.Move(translate_drone.x, translate_drone.y, translate_drone.z);
            MainCam.transform.position = _VirtualSurrogate.GetDroneLocation() + new Vector3(-6.097f, 3.4f, -9.831f);
        }
        else
        {
            _PrimaryDrone.Move(translate_drone.x, translate_drone.y, translate_drone.z);
            _VirtualSurrogate.Move(translate_drone.x, translate_drone.y, translate_drone.z);
        }

        if (merge_position && (_VirtualSurrogate._State == _PrimaryDrone._State))
        {
            _VirtualSurrogate.SetDroneLocation(_PrimaryDrone.GetDroneLocation());
            merge_position = false;
        }

        if (retrace_path && _PrimaryDrone.IsFlying())
        {
            _PrimaryDrone._State = DroneController.DroneState.DRONE_STATE_WAY_POINT_FOLLOW;
            _PrimaryDrone.current_waypoint_tracking_index = -1;
            retrace_path = false;
        }

        if (_PrimaryDrone.retracing_path_complete)
        {
            WayPointManager.clear_waypoints();
            _PrimaryDrone.retracing_path_complete = false;
        }



        // Debug.Log("Drone State: " + _PrimaryDrone._State + " | " + _VirtualSurrogate._State);
    }
}