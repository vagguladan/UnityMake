using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{


    [SerializeField] private Gun equippedGun; // ¿Â¬¯«— √—±‚

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            equippedGun?.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            equippedGun?.Reload();
        }
    }
}
