using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("What is Player")]
    public GameObject _player;

    [Header("Enemy Stat Info")]
    public int _hp = 60;

    [Header("Move Info")]
    public float _moveSpeed = 12;
    public float _runSpeed = 15;

    [Header("EnemyDamageOption")]
    public float _enemyDamage = 15;
    public float _attackDelayTimer = 1;


    [Header("Enemy Move Root")]
    [SerializeField] GameObject[] _enemyRoot;
    public int _currnetTargetIndex = 0;
    public Vector3 _enemyGoingIndex= Vector3.zero;
    public Quaternion _enemyTargetindex;
    public float _rootAngle = 220f;

    //나중에 이 헤더와 파라미터 이용해서 적의 행동에 대한 걸 따로 연출해보기.
    [Header("Enemy Pattern Parameter")]
    public int _enemyPattern = 0;


    [Header("Enemy Colider Prameter")]
    public GameObject _guardCollider;
    public GameObject _attackCollider;

    #region Componenets
    public Animator _anim { get; private set; }
    public Rigidbody _rb { get; private set; }
    public NavMeshAgent _navMesh {  get; private set; }
    public BoxCollider _boxCollider { get; private set; }

    #endregion


    #region State
    public EnemyStateMachine _stateMachine { get; private set; }
    public EnemyIdleState _idleState { get;private set; }
    public EnemyMoveState _moveState { get; private set; } 
    public EnemyGuardState _guardState { get; private set; }
    public EnemyAttackState _attackState { get; private set; }

    public EnemyDeadState _deadState { get; private set; }  

    #endregion

     void Awake()
    {
        _stateMachine = new EnemyStateMachine();

        _idleState = new EnemyIdleState(this, _stateMachine, "Idle");
        _moveState = new EnemyMoveState(this, _stateMachine, "Move");
        _guardState = new EnemyGuardState(this, _stateMachine, "Guard");
        _attackState = new EnemyAttackState(this, _stateMachine, "Attack");
        _deadState = new EnemyDeadState(this, _stateMachine, "Dead");

        GetRootIndex();

    }

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();
        _navMesh = GetComponent<NavMeshAgent>();
        _boxCollider = GetComponent<BoxCollider>();

        _stateMachine.Init(_idleState);
    }

     void Update()
    {
        _stateMachine._currentState.Update();


        EnemyRootMake();

        if (_hp <= 0)
        {
            _stateMachine.ChangeState(_deadState);
        }

    }

    //Move 예시 첫번째 그냥 고정 이동( 방향 수정 필요(
    public void Move()
    {
        Vector3 dir = (_enemyGoingIndex - transform.position).normalized;

        transform.Rotate(dir * Time.deltaTime);

        transform.position += dir * Time.deltaTime * _moveSpeed;

        if (Vector3.Distance(transform.position, _enemyGoingIndex) < 1.0f)
        {
            GetRootIndex(); // 목표에 도달하면 다음 지점 설정
        }
    }


#region Enemy_Move
    public void RotateMove()
    {
       
        transform.rotation = Quaternion.Slerp(transform.rotation, _enemyTargetindex, Time.deltaTime * _rootAngle);
     
        transform.position += transform.forward * Time.deltaTime * _moveSpeed ;

            // 3️⃣ 목표 지점에 도달하면 다음 Index로 변경
            if (Vector3.Distance(transform.position, _enemyGoingIndex) < 3.0f)
            {
                GetRootIndex();
            }
    }
    private void EnemyRootMake()
    {
        Vector3 dir = (_enemyGoingIndex - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(dir);

        _enemyTargetindex = targetRotation;
    }


    public void GetRootIndex()
    {
        _currnetTargetIndex++; // 다음 목표로 변경
        if (_currnetTargetIndex >= _enemyRoot.Length)
        {
            _currnetTargetIndex = 0; // 마지막 지점이면 처음으로 되돌림
        }
        _enemyGoingIndex = _enemyRoot[_currnetTargetIndex].transform.position;

    
    }


    public void PlayerTargerMove()
    {
        _navMesh.speed = 15f;
        _navMesh.SetDestination(_player.transform.position);
    }


    public void StopPlayerTagerMove()
    {
        _navMesh.isStopped = true;
    }

#endregion




    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player") && _attackCollider.activeSelf)
        {
            _stateMachine.ChangeState(_attackState);
        }

        if(other.CompareTag("Player"))
        {
            _stateMachine.ChangeState(_guardState);
            _guardCollider.SetActive(false);
        }

        if (other.CompareTag("SoundCollider"))
        {
            _stateMachine.ChangeState(_guardState);
            _guardCollider.SetActive(false);
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _attackCollider.activeSelf)
        {
            _stateMachine.ChangeState(_attackState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _attackCollider.activeSelf)
        {
            _stateMachine.ChangeState(_guardState);
        }
    }


    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if(_hp<=0)
        {
            Debug.Log("목표 사망함");
          //  _stateMachine.ChangeState();
        }
    }
}
