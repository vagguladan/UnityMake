using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private List<Camera> assignedCameras = new List<Camera>();  //  여러 개의 카메라 등록 가능

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // 플레이어가 들어오면 카메라 전환
        {
            CameraManager.Instance.SetActiveCameras(assignedCameras);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // 플레이어가 나가면 기본 카메라로 복귀
        {
      //      CameraManager.Instance.ResetToDefaultCamera();
        }
    }
}
