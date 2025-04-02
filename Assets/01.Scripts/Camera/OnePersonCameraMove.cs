using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnePersonCameraMove : MonoBehaviour
{
    [SerializeField] private float MouseSensictivity = 10f;
    [SerializeField] private Transform Player;

    public float _xRotation;
    public float _yRotation;
    private float _yawingLimit = 10;



    void Start()
    {
        float initialYRotation = Player.eulerAngles.y;

        //if (Mathf.Approximately(_yRotation, -10f) || Mathf.Approximately(_yRotation, 10f))
        //{
        //    _yRotation = initialYRotation; // 최초 Y 회전을 0으로 보정
        //}

    }

    void Update()
    {
        float Mouse_X = Input.GetAxis("Mouse X") * MouseSensictivity * Time.deltaTime;
        float Mouse_Y = Input.GetAxis("Mouse Y") * MouseSensictivity * Time.deltaTime;

        _xRotation -= Mouse_Y;
        _xRotation = Mathf.Clamp(_xRotation, -_yawingLimit, _yawingLimit);

        _yRotation = Player.eulerAngles.y + Mouse_X;
        _yRotation = Mathf.Clamp(_yRotation, Player.eulerAngles.y - _yawingLimit, Player.eulerAngles.y + _yawingLimit);


        Player.transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }


   private  void ToggleTrigger()
    { 
        _xRotation = 0;
        _yRotation = Player.eulerAngles.y;
    }
}
