using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    Animator _Anim;
    Vector3 _Speed = new Vector3(0.0f, 0.0f, 0.0f);
    public float _SpeedMultipler = 1.0f;
    public void Move(float _speedX, float _speedZ)
    {
        _Speed.x = _speedX;
        _Speed.z = _speedZ;
        UpdateDrone();
    }


    void UpdateDrone()
    {
        float angleZ = -30.0f * _Speed.x * 60.0f * Time.deltaTime;
        float angleX = 30.0f * _Speed.z * 60.0f * Time.deltaTime;
        Vector3 rotation = transform.localRotation.eulerAngles;
        transform.localPosition += _Speed * _SpeedMultipler * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(angleX, rotation.y, angleZ);
    }
    void Start()
    {
        _Anim = GetComponent<Animator>();
        _Anim.SetBool("TakeOff", true);
    }

    void Update()
    {
    }
}
