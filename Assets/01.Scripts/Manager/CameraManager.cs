using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private Camera defaultCamera;  // 기본 3인칭 카메라
    [SerializeField] private Camera firstPersonCamera; // 1인칭 카메라 (벤트 등 특수 구역)

    private List<Camera> activeCameras = new List<Camera>();  // 현재 활성화된 카메라 리스트

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetToDefaultCamera();
    }

    //  여러 개의 카메라를 활성화하는 함수
    public void SetActiveCameras(List<Camera> newCameras)
    {
        foreach (Camera cam in activeCameras)
        {
            if (cam != null)
                cam.gameObject.SetActive(false);
        }

        activeCameras = newCameras;
        foreach (Camera cam in activeCameras)
        {
            if (cam != null)
                cam.gameObject.SetActive(true);
        }
    }

    //  1인칭 카메라 전환 (벤트 진입 등)
    public void EnableFirstPersonView()
    {
        SetActiveCameras(new List<Camera> { firstPersonCamera });
    }

    //  기본 카메라(3인칭)로 복귀
    public void ResetToDefaultCamera()
    {
        SetActiveCameras(new List<Camera> { defaultCamera });
    }

}
