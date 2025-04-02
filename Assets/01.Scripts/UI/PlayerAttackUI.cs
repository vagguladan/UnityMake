using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackUI : MonoBehaviour
{
    [SerializeField] private Gun equippedGun; // ¿Â¬¯«— √—±‚

    [SerializeField] Text BulletText;
    [SerializeField] Text magazineText;

    private void Update()
    {
        BulletText.text = equippedGun._currentBullet.ToString();
        magazineText.text = equippedGun._gunMagazine.ToString();   
    }

}
