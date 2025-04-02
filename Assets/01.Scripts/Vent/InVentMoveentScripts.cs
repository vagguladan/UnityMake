using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InVentMoveentScripts : MonoBehaviour
{
    public float _moveSpeed = 12;
    public float _rotAngle = 220;

    protected float _xInput;
    protected float _yInput;
    protected float _rotate;

    public CharacterController _CC { get; private set; }
    void Start()
    {
        _CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _xInput = 0;
        _yInput = Input.GetAxisRaw("Vertical");
        _rotate = Input.GetAxisRaw("Rotate");

        SetRotateMove(_xInput,_yInput , _rotate);
    }


    public void SetRotateMove(float mz, float LnR, float ry)
    {
        int _dirLnR = (int)LnR;
        transform.Rotate(Vector3.up * ry * _rotAngle * Time.deltaTime);
        Vector3 mv = transform.rotation * new Vector3(_dirLnR, 0, mz);
        mv = mv.magnitude > 1 ? mv.normalized : mv;

        float gravityY = Physics.gravity.y;

        if (!_CC.isGrounded)
        {
            Vector3 gv = new Vector3(0, gravityY, 0);
            _CC.Move((mv * _moveSpeed + gv) * Time.deltaTime);
        }
        else
            _CC.Move((mv * _moveSpeed) * Time.deltaTime);

    }
}
