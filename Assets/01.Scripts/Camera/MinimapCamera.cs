using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    [SerializeField] GameObject _player;

     void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, 40, _player.transform.position.z);
    
     }


}
