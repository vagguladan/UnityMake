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
            // 플레이어 Vent 탈출 처리
            _whatisPlayer.transform.position = _whereToSpawnPlayer.transform.position;
            _whatisVentMovement.SetActive(false);
            _whatisPlayer.SetActive(true);

            // 현재 플레이어가 나올 때의 방향
            Vector3 exitDirection = _whatisPlayer.transform.forward;

            // 진입 방향과 출구 방향의 각도 계산
            float angleDifference = Vector3.Angle(lastEntryDirection, exitDirection);

        }
    }
}
