using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target_Arrow : MonoBehaviour
{

    [SerializeField] GameObject[] _target;
    [SerializeField] GameObject _player;

    [SerializeField] GameObject _object;

    private float _angle;
    private Vector3 _direction;

    public float _deltaX;
    public float _deltaZ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //   _object.gameObject.transform.rotation = Quaternion.LookRotation(_direction);

        //  _object.transform.rotation = Quaternion.Euler(0, 0, _angle);

        if (_target[0] != null)
            MakeTargetAngle();
        else if( _target[1] != null)
            MakeTargetAngle2();



        if (_target[1] == null)
            _object.gameObject.SetActive(false);
    }


    public void MakeTargetAngle()
    {
        _deltaX = _target[0].transform.position.x - _player.transform.position.x;
        _deltaZ = _target[0].transform.position.z - _player.transform.position.z;

        _angle= Mathf.Atan2(_deltaX, _deltaZ);
        _angle = Mathf.Rad2Deg * _angle;

        _object.transform.rotation = Quaternion.Euler(0, 0, -_angle);
    }

    public void MakeTargetAngle2()
    {
        _deltaX = _target[1].transform.position.x - _player.transform.position.x;
        _deltaZ = _target[1].transform.position.z - _player.transform.position.z;

        _angle = Mathf.Atan2(_deltaX, _deltaZ);
        _angle = Mathf.Rad2Deg * _angle;

        _object.transform.rotation = Quaternion.Euler(0, 0, -_angle);
    }

}
