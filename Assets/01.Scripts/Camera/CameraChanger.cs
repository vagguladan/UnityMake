using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{

    [SerializeField] Camera[] _cameras;



    [Header("ChacrterMove")]
    public float _x;
    public float _z;

    public float _x2;
    public float _z2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_cameras[0].gameObject.activeSelf)
            {
                //정방향 진입시
                _cameras[0].gameObject.SetActive(false);
                _cameras[1].gameObject.SetActive(true);
                CharMove_1(other);
            }
            else
            {
                //다른 방향 진입시
                _cameras[0].gameObject.SetActive(true);
                _cameras[1].gameObject.SetActive(false);
                CharMove_2(other);
            }

        }
    }

    private void CharMove_1(Collider other)
    {
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            Vector3 moveDirection = new Vector3(_x, 0f, _z);
            controller.Move(moveDirection);
        }
    }

    private void CharMove_2(Collider other)
    {
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            Vector3 moveDirection = new Vector3(_x2, 0f, _z2);
            controller.Move(moveDirection);
        }
    }

    private void OnTriggerExit(Collider other)
    {


    }

    private void OnTriggerStay(Collider other)
    {
         

    }

}
