using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Slider EnemyHpBar;

    public NavMeshAgent agent;

    public GameObject ai;
    public EnemyFSM enemyFSM;

    private float _animationBlend;

    public bool Grounded = true;
    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.28f;
    public LayerMask GroundLayers;

    private Animator _animator;
    private bool _hasAnimator;

    // animation IDs
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;
    private int _animIDShoot;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _hasAnimator = TryGetComponent(out _animator);

        ai = transform.Find("AI").gameObject;
        enemyFSM = ai.GetComponent<EnemyFSM>();

        AssignAnimationIDs();
    }

    void Update()
    {
        _hasAnimator = TryGetComponent(out _animator);

        GroundedCheck();
        ShootCheck();
        Move();
    }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        _animIDShoot = Animator.StringToHash("Shoot");
    }

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        // update animator if using character
        if (_hasAnimator)
        {
            _animator.SetBool(_animIDGrounded, Grounded);
        }
    }

    private void ShootCheck()
    {
        if (enemyFSM.currentStateNumber == 1 || enemyFSM.currentStateNumber == 3)
        {
            _animator.SetBool(_animIDShoot, true);
        }
        else
        {
            _animator.SetBool(_animIDShoot, false);
        }
    }

    private void Move()
    {
        float targetSpeed = agent.speed;

        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * 10f);


        // update animator if using character
        if (_hasAnimator)
        {
            _animator.SetFloat(_animIDSpeed, _animationBlend);
            _animator.SetFloat(_animIDMotionSpeed, 1f);
        }
    }

}
