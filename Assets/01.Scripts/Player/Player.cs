using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Stat Info")]
    public int _hp = 100;
    [SerializeField] Slider _hpSlider;

    [Header("MoveInfo")]
    public float _moveSpeed = 12;
    public float _sitMoveSpeed = 6;
    public float _runSpeed = 16;
    public float _rotAngle = 220;

    [Header("PlayerAttackOption")]
    [SerializeField] public GameObject _playerAttackSetting;

    [Header("Player Invisivle")]
    [SerializeField] Material[] _playerMaterials;
    [SerializeField] GameObject _playerRederer;
    public float invisibilityDuration = 5f;  // 투명 지속 시간
    private bool isInvisible = false;
    private Coroutine invisibilityCoroutine;
    public SkinnedMeshRenderer _playerMaterial;

    private Material[] _originalMaterials;

    [Header("Player Damage Option")]
    public float _nextDamageTime = 0f;
    public float _damageCoolDown = 0.5f;

    #region Components
    public Animator _anim { get; private set; }
    public CharacterController _CC { get; private set; }
    public BoxCollider _collider { get; private set; }


    #endregion

    #region States
    public PlayerStateMachine _stateMachine { get; private set; }
    public PlayerIdleState _idleState { get; private set; }
    public PlayerMoveState _moveState { get; private set; }
    public PlayerRunState _runState { get; private set; }
    public PlayerSitState _sitState { get; private set; }
    public PlayerAttackState _attackState { get; private set; }
    public PlayerDeadState _deadState { get; private set; } 

    public PlayerOnePersonState _onePersonState { get; private set; }

    #endregion


    private void Awake()
    {
        _stateMachine = new PlayerStateMachine();

        _idleState = new PlayerIdleState(this, _stateMachine, "Idle");
        _moveState = new PlayerMoveState(this, _stateMachine, "Move");
        _runState = new PlayerRunState(this, _stateMachine, "Run");
        _attackState = new PlayerAttackState(this, _stateMachine, "Attack");
        _sitState = new PlayerSitState(this, _stateMachine, "Sit");
        _deadState = new PlayerDeadState(this, _stateMachine, "Dead");
        _onePersonState = new PlayerOnePersonState(this, _stateMachine, "Attack");


    }


    void Start()
    {
   //     _playerMaterial=GetComponentInChildren<Material>();
        _anim = GetComponentInChildren<Animator>();
 //       _rb = GetComponent<Rigidbody>();
        _CC= GetComponent<CharacterController>();
        _collider = GetComponent<BoxCollider>();
        _stateMachine.Init(_idleState);

        _playerMaterial = _playerRederer.GetComponent<SkinnedMeshRenderer>();
        _originalMaterials = _playerMaterial.materials.Clone() as Material[];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 YZero = _CC.transform.position;

        PlayerHpValue();

        YZero.y = 0;
        //플레이어 Y축 고정 (안밀려나게)
        _CC.transform.position = YZero;

        _stateMachine._currentState.Update();

        if (_hp <= 0)
        {
            _stateMachine.ChageState(_deadState);
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine("InvisibilityRoutine", 5f);
        }

    }

    private void PlayerInvisible()
    {
        _playerMaterial.materials = _playerMaterials;
        Material[] mats = _playerMaterial.materials; // 현재 마테리얼 배열 가져오기
        mats[0] = _playerMaterials[0]; // 첫 번째 마테리얼만 교체
        _playerMaterial.materials = mats; // 변경 적용
    }

    private void PlayerHpValue()
    {
        _hpSlider.value = _hp;
        
        if(_hpSlider.value<=50)
        {
            Image ChageColor = _hpSlider.fillRect.GetComponent<Image>();

            ChageColor.color = Color.yellow;
        }

        if (_hpSlider.value <= 20)
        {
            Image ChageColor = _hpSlider.fillRect.GetComponent<Image>();

            ChageColor.color = Color.red;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("AttackCollider") && Time.time>= _nextDamageTime)
        {
            _hp -= 10;
            _nextDamageTime = Time.time + _damageCoolDown;
        }
    }

    //새롭게 만들어야하는 Rotate이용 회전 이동 
    public void SetRotateMove(float mz,float LnR ,float ry)
    {
        int _dirLnR = (int)LnR;
        transform.Rotate(Vector3.up * ry * _rotAngle * Time.deltaTime);
        Vector3 mv = transform.rotation * new Vector3(_dirLnR, 0, mz);
        mv = mv.magnitude > 1 ? mv.normalized : mv;

        float gravityY = Physics.gravity.y;

        if (!_CC.isGrounded)
        {
            Vector3 gv = new Vector3(0, gravityY, 0);
            _CC.Move((mv * _moveSpeed + gv) * Time.deltaTime);
        }
        else
        _CC.Move((mv* _moveSpeed) * Time.deltaTime);

    }

    //기존 이동 WASD를 이용해서 고정 방향이 동연산
    public void SetVelocity(float xVelocity, float zVelocity)
    {
        Vector3 moveDirection = new Vector3(xVelocity, 0, zVelocity);

        // 이동 중이라면 방향 변경
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = targetRotation; 
        }
    }
    public void ActivateInvisibility()
    {
        if (isInvisible) return;  // 중복 실행 방지

        isInvisible = true;
        invisibilityCoroutine = StartCoroutine(InvisibilityRoutine());
    }


    private IEnumerator InvisibilityRoutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < invisibilityDuration)
        {
            PlayerInvisible();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 지속시간 종료 후 원래대로 복구
        _playerMaterial.materials = _originalMaterials;
        isInvisible = false;
    }


}
