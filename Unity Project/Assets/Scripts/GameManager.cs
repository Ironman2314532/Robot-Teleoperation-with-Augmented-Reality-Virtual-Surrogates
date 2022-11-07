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
    ControllerInput controls;
    [SerializeField] public TextMeshProUGUI _ModeSelector;
    bool _virtual_surrogate_control_mode = true;
    Vector3 translate_drone;
    const int WAYPOINT_LENGTH = 10;
    int way_point_marker_position = 0;
    public GameObject[] way_point_tracker_array = new GameObject[WAYPOINT_LENGTH];
    [SerializeField] public TextMeshProUGUI[] way_point_label_array = new TextMeshProUGUI[WAYPOINT_LENGTH];
    [SerializeField] public TextMeshProUGUI _way_point_label_topic;

    float[,] way_point_array = new float[WAYPOINT_LENGTH, 4];//x,y,z,state

    void power_switch_pressed()
    {
        if (!_virtual_surrogate_control_mode)
        {
            _PrimaryDrone._drone_power_state = !_PrimaryDrone._drone_power_state;
            if (_PrimaryDrone._drone_power_state)
            {
                if (_PrimaryDrone.IsIdle())
                    _PrimaryDrone.TakeOff();
            }
            else
            {
                if (_PrimaryDrone.IsFlying())
                    _PrimaryDrone.Land();
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

    void display_way_point_info(bool _display_status)
    {
        if (!_display_status)
        {
            for (int i = 0; i < WAYPOINT_LENGTH; i++)
            {
                way_point_array[i, 0] = 0;
                way_point_array[i, 1] = 0;
                way_point_array[i, 2] = 0;
            }
            way_point_marker_position = 0;
        }

        for (int i = 0; i < 10; i++)
        {
            Vector3 tracker_pos = new Vector3(way_point_array[i, 0], way_point_array[i, 1], way_point_array[i, 2]);
            way_point_tracker_array[i].transform.position = tracker_pos;
            string output_waypoint_label = "" + (i + 1) + ". (" + way_point_array[i, 0] + "," + way_point_array[i, 1] + "," + way_point_array[i, 2] + ")";
            way_point_label_array[i].text = output_waypoint_label;
            way_point_tracker_array[i].SetActive(_display_status);
            way_point_label_array[i].enabled = _display_status;
            _way_point_label_topic.enabled = _display_status;
        }
    }

    void save_way_point()
    {
        if (_virtual_surrogate_control_mode)
        {
            if (way_point_marker_position < 10)
            {
                Vector3 _pos = _VirtualSurrogate.GetDroneLocation();
                way_point_array[way_point_marker_position, 0] = _pos.x;
                way_point_array[way_point_marker_position, 1] = _pos.y;
                way_point_array[way_point_marker_position, 2] = _pos.z;
                way_point_marker_position += 1;
                display_way_point_info(true);
            }
            else
                Debug.Log("All Way Point Markers Placed");
        }
    }

    void delete_way_point() { }
    void scroll_way_point() { }
    void retrace_way_points()
    {
        _VirtualSurrogate.SetDroneLocation(_PrimaryDrone.GetDroneLocation());
        _VirtualSurrogate._State = DroneController.DroneState.DRONE_STATE_WAY_POINT_FOLLOW;
        if (_PrimaryDrone._State == DroneController.DroneState.DRONE_STATE_IDLE)
        {
            _VirtualSurrogate.way_point = new Vector3(_PrimaryDrone.GetDroneLocation().x, 4.57698f, _PrimaryDrone.GetDroneLocation().z);
            _VirtualSurrogate.UpdateDrone();
        }
        _VirtualSurrogate.way_point_tracker = 0;

        _VirtualSurrogate.way_point_number = way_point_marker_position - 1;
        for (int i = 0; i < way_point_marker_position; i++)
        {
            _VirtualSurrogate.way_point_tracker_array[i, 0] = way_point_array[i, 0];
            _VirtualSurrogate.way_point_tracker_array[i, 1] = way_point_array[i, 1];
            _VirtualSurrogate.way_point_tracker_array[i, 2] = way_point_array[i, 2];
        }
    }
    void execute_way_points()
    {
        if (_PrimaryDrone._State == DroneController.DroneState.DRONE_STATE_IDLE)
        {
            power_switch_pressed();
            _PrimaryDrone.UpdateDrone();
        }
        _PrimaryDrone.way_point_tracker = 0;

        _PrimaryDrone.way_point_number = way_point_marker_position - 1;
        for (int i = 0; i < way_point_marker_position; i++)
        {
            _PrimaryDrone.way_point_tracker_array[i, 0] = way_point_array[i, 0];
            _PrimaryDrone.way_point_tracker_array[i, 1] = way_point_array[i, 1];
            _PrimaryDrone.way_point_tracker_array[i, 2] = way_point_array[i, 2];
        }
        _PrimaryDrone._State = DroneController.DroneState.DRONE_STATE_WAY_POINT_FOLLOW;
    }

    void change_mode()
    {
        _virtual_surrogate_control_mode = !_virtual_surrogate_control_mode;
        if (_virtual_surrogate_control_mode)
        {
            display_way_point_info(true);
            _ModeSelector.text = "Virtual Surrogate Control Mode";
            _VirtualSurrogate.DroneVisible(true);
            _ModeSelector.color = new Color32(0, 135, 62, 255);
            _VirtualSurrogate.SetDroneLocation(new Vector3(_PrimaryDrone.GetDroneLocation().x, 0, _PrimaryDrone.GetDroneLocation().z));
            power_switch_pressed();
        }
        else
        {
            display_way_point_info(false);
            _ModeSelector.text = "Real Time Control Mode";
            _VirtualSurrogate.DroneVisible(false);
            _ModeSelector.color = new Color32(128, 0, 0, 255);
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
            _VirtualSurrogate.Move(translate_drone.x, translate_drone.y, translate_drone.z);
        else
            _PrimaryDrone.Move(translate_drone.x, translate_drone.y, translate_drone.z);
        Debug.Log("Primary Drone: " + _PrimaryDrone._State);
        Debug.Log("Virtual Surrogate: " + _VirtualSurrogate._State);
    }
}