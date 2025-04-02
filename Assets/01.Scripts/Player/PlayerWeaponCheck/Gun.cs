using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Stat")]
    [SerializeField] private int _gunBullet;  // 최대 총알 수
    [SerializeField] public int _currentBullet;  // 현재 총알 개수
    [SerializeField] private float _gunRange;  // 사정거리
    [SerializeField] private float _fireRate;  // 연사 속도
    [SerializeField] private int _gunDamage;  // 데미지
    [SerializeField] private string _gunName;  // 총기 이름
    [SerializeField] private LayerMask targetLayer; // 타겟 레이어

    [SerializeField] private Camera _playerCamera;

    [Header("Gun Effect")]
    [SerializeField] private GameObject _gunEffect;
    [SerializeField] private GameObject _effectPosition;
    [SerializeField] private GameObject _hitEffect;

    [Header("Gun Sound")]
    [SerializeField] private GameObject _gunSoundCollider;
    [SerializeField] private float _SoundTime;
    [SerializeField] private float _SoundRadius;

    private float _gunCooltime = 0f;
    public int _gunMagazine = 2;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_gunCooltime > 0)
        {

            _gunCooltime -= Time.deltaTime;
        }

    }

    public void Shoot()
    {
        if (_gunCooltime > 0) return;
        if (_currentBullet <= 0)
        {
            Debug.Log("탄약 부족!");
            return;
        }



        _currentBullet--; // 총알 감소
        _gunCooltime = _fireRate;


        GameObject effect = Instantiate(_gunEffect, _effectPosition.transform.position, _effectPosition.transform.rotation);
        effect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


        RaycastHit hit;
        Vector3 shootOrigin = _playerCamera.transform.position;
        Vector3 shootDirection = _playerCamera.transform.forward;

        if (Physics.Raycast(shootOrigin, shootDirection, out hit, _gunRange, targetLayer))
        {

            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_gunDamage);
            }


            GameObject hiteffect = Instantiate(_hitEffect, hit.point, _effectPosition.transform.rotation);
            hiteffect.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            CreateImpactCollider(hit.point);
            CreateImpactCollider(transform.position);
        }
    }

    private void CreateImpactCollider(Vector3 position)
    {
        if (_gunSoundCollider != null)
        {
            GameObject impactCollider = Instantiate(_gunSoundCollider, position, Quaternion.identity);

            SphereCollider Sound = impactCollider.GetComponent<SphereCollider>();

            Sound.radius = _SoundRadius;

            Destroy(impactCollider, _SoundTime); // 일정 시간 후 삭제
        }
    }

    public void Reload()
    {
        if (_gunMagazine <= 0)
            return;


        _gunMagazine--;
        _currentBullet = _gunBullet;
        Debug.Log($"{_gunName} 재장전 완료");
    }
}
