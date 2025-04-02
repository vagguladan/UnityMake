using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private List<Camera> assignedCameras = new List<Camera>();  //  ���� ���� ī�޶� ��� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // �÷��̾ ������ ī�޶� ��ȯ
        {
            CameraManager.Instance.SetActiveCameras(assignedCameras);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // �÷��̾ ������ �⺻ ī�޶�� ����
        {
      //      CameraManager.Instance.ResetToDefaultCamera();
        }
    }
}
