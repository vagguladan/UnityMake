using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMoveScript : MonoBehaviour
{

    [SerializeField] GameObject _whatisPlayer;
    [SerializeField] GameObject _whatisVentMovement;
    [SerializeField] GameObject _WhereTOStart;
    [SerializeField] GameObject _whereToSpawnPlayer;



    private Camera _previousCamera;
    private Vector3 lastEntryDirection;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _whatisVentMovement.gameObject.transform.rotation = _WhereTOStart.transform.rotation;
            _whatisVentMovement.gameObject.transform.position = _WhereTOStart.transform.position;

        }
        if (other.CompareTag("Player") && (Input.GetKey(KeyCode.F)))
        {
            _whatisVentMovement.SetActive(true);
            _whatisPlayer.SetActive(false);

            lastEntryDirection = _whatisPlayer.transform.forward;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerInVent"))
        {
            // �÷��̾� Vent Ż�� ó��
            _whatisPlayer.transform.position = _whereToSpawnPlayer.transform.position;
            _whatisVentMovement.SetActive(false);
            _whatisPlayer.SetActive(true);

            // ���� �÷��̾ ���� ���� ����
            Vector3 exitDirection = _whatisPlayer.transform.forward;

            // ���� ����� �ⱸ ������ ���� ���
            float angleDifference = Vector3.Angle(lastEntryDirection, exitDirection);

        }
    }
}
