using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public enum DroneState
    {
        DRONE_STATE_IDLE,
        DRONE_STATE_START_TAKINGOFF,
        DRONE_STATE_TAKINGOFF,
        DRONE_STATE_MOVING_UP,
        DRONE_STATE_FLYING,
        DRONE_STATE_START_LANDING,
        DRONE_STATE_LANDING,
        DRONE_STATE_LANDED,
        DRONE_STATE_WAIT_ENGINE_STOP,
        DRONE_STATE_WAY_POINT_FOLLOW
    }

    public int way_point_number;
    int way_point_tracker = 0;
    const int POINTS = 10;
    public float[,] way_point_tracker_array = new float[POINTS, 4];

    float distance_error = 0.001f;
    public DroneState _State;
    Animator _Anim;
    Vector3 _Speed = new Vector3(0.0f, 0.0f, 0.0f);
    public float _SpeedMultipler = 1.0f;
    public bool _drone_power_state = false;

    public Vector3 way_point;

    public bool IsIdle()
    {
        return (_State == DroneState.DRONE_STATE_IDLE);
    }

    public void TakeOff()
    {
        _State = DroneState.DRONE_STATE_START_TAKINGOFF;
    }

    public bool IsFlying()
    {
        return (_State == DroneState.DRONE_STATE_FLYING);
    }

    public void Land()
    {
        _State = DroneState.DRONE_STATE_START_LANDING;

    }

    public void Move(float _speedX, float _speedY, float _speedZ)
    {
        _Speed.x = _speedX;
        _Speed.y = _speedY;
        _Speed.z = _speedZ;
        UpdateDrone();
    }

    public void SetDroneLocation(Vector3 _position)
    {
        transform.position = _position;
    }


    public Vector3 GetDroneLocation()
    {
        return (gameObject.transform.position);
    }

    public void DroneVisible(bool _drone_visible)
    {
        gameObject.SetActive(_drone_visible);
    }

    public void UpdateDrone()
    {
        switch (_State)
        {
            case DroneState.DRONE_STATE_IDLE:
                break;
            case DroneState.DRONE_STATE_START_TAKINGOFF:
                _Anim.SetBool("TakeOff", true);
                _State = DroneState.DRONE_STATE_TAKINGOFF;
                break;
            case DroneState.DRONE_STATE_TAKINGOFF:
                if (_Anim.GetBool("TakeOff") == false)
                    _State = DroneState.DRONE_STATE_MOVING_UP;
                break;
            case DroneState.DRONE_STATE_MOVING_UP:
                if (_Anim.GetBool("MoveUp") == false)
                    _State = DroneState.DRONE_STATE_FLYING;
                break;
            case DroneState.DRONE_STATE_FLYING:
                float angleZ = -30.0f * _Speed.x * 60.0f * Time.deltaTime;
                float angleX = 30.0f * _Speed.z * 60.0f * Time.deltaTime;
                Vector3 rotation = transform.localRotation.eulerAngles;
                Vector3 _distance = _Speed * _SpeedMultipler * Time.deltaTime;
                if ((transform.localPosition.y < 0) && _distance.y < 0) { }
                else
                {
                    transform.localPosition += _Speed * _SpeedMultipler * Time.deltaTime;
                    transform.localRotation = Quaternion.Euler(angleX, rotation.y, angleZ);
                }
                break;
            case DroneState.DRONE_STATE_START_LANDING:
                _Anim.SetBool("MoveDown", true);
                _State = DroneState.DRONE_STATE_LANDING;
                break;
            case DroneState.DRONE_STATE_LANDING:
                if (_Anim.GetBool("MoveDown") == false)
                    _State = DroneState.DRONE_STATE_LANDED;
                break;
            case DroneState.DRONE_STATE_LANDED:
                _Anim.SetBool("Land", true);
                _State = DroneState.DRONE_STATE_WAIT_ENGINE_STOP;
                break;
            case DroneState.DRONE_STATE_WAIT_ENGINE_STOP:
                if (_Anim.GetBool("Land") == false)
                    _State = DroneState.DRONE_STATE_IDLE;
                break;
            case DroneState.DRONE_STATE_WAY_POINT_FOLLOW:
                way_point = new Vector3(way_point_tracker_array[way_point_tracker, 0], way_point_tracker_array[way_point_tracker, 1], way_point_tracker_array[way_point_tracker, 2]);
                break;
        }
    }
    void Start()
    {
        _Anim = GetComponent<Animator>();
        _State = DroneState.DRONE_STATE_IDLE;
    }

    void Update()
    {
        if (_State == DroneState.DRONE_STATE_WAY_POINT_FOLLOW)
        {
            transform.position = Vector3.MoveTowards(transform.position, way_point, 1.1f * Time.deltaTime);
            if ((Vector3.Distance(transform.position, way_point) < distance_error))
            {
                way_point_tracker += 1;
                if (way_point_tracker > way_point_number)
                {
                    _State = DroneState.DRONE_STATE_FLYING;
                    return;
                }
                way_point = new Vector3(way_point_tracker_array[way_point_tracker, 0], way_point_tracker_array[way_point_tracker, 1], way_point_tracker_array[way_point_tracker, 2]);
            }
        }
    }
}
