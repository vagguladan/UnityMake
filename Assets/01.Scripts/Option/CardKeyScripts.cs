using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardKeyScripts : MonoBehaviour
{

    [SerializeField] GameObject _destroyWall;

    private void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Time.deltaTime * 50; // 50�� ȸ�� �ӵ�
        transform.eulerAngles = rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(_destroyWall);
            Destroy(gameObject);

        }

    }
}
