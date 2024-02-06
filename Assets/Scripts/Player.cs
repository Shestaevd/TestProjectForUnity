using Assets.Scripts.State;
using Assets.Scripts.StateMachine;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Cooldown between attacks")]
    [SerializeField] public float AttackCooldown = 1.0f;

    [Header("Attack window")]
    [SerializeField] public float AttackWindow = 1.5f;

    [Header("Velocity")]
    [SerializeField] public float Velocity = 5.0f;

    [Header("Jump height")]
    [SerializeField] public float JumpHeight = 5.0f;

    [Header("Player life")]
    [SerializeField] public PlayerHp life;

    [Header("Ground Layer Mask")]
    [SerializeField] public LayerMask GroundMask;

    [Header("Player colider")]
    [SerializeField] public Collider2D Collider;

    [Header("Blade colider")]
    [SerializeField] public Collider2D BladeCollider;

    [Header("Player rigitbody")]
    [SerializeField] public Rigidbody2D Rigidbody;

    [Header("Enemy")]
    [SerializeField] public Enemy enemy;

    [HideInInspector] public float AttackCooldownTimer = 0.0f;
    [HideInInspector] public float AttackWindowTimer = 0.0f;
    [HideInInspector] public Animator Animation;
    [HideInInspector] public bool IsDamaged = false;
    [HideInInspector] public bool IsGrounded = false;
    [HideInInspector] public bool Struck = false;

    StateMachine<Player> fsm;

    void Start()
    {
        Animator animation = gameObject.GetComponent<Animator>();
        if (animation) Animation = animation; else Debug.LogError(gameObject.name + " need Animation");

        AttackWindowTimer = AttackWindow;

        fsm = new StateMachine<Player>(
                new StateManager<Player>(this)
                .AddState(StateMap.Idle)
                .AddState(StateMap.Move)
                .AddState(StateMap.Jump)
                .AddState(StateMap.Attack)
                .AddState(StateMap.GetDamage)
              );

    }

    void Update()
    {
        fsm.Run();
        Debug.Log(fsm.CurrentState.Name);
        AttackWindowReset();
    }

    void AttackWindowReset()
    {
        if (AttackWindowTimer < AttackWindow)
        {
            AttackWindowTimer += Time.deltaTime;
        }
        else if (AttackWindowTimer > AttackWindow)
        {
            ClearDamage();
        }
    }

    public void ClearDamage()
    {
        life.RemoveCurrentHp();
        AttackWindowTimer = AttackWindow;
    }

    public void ClearDamageSafe()
    {
        life.UnhighlightCurrentHp();
        AttackWindowTimer = AttackWindow;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBlade")
        {
            IsDamaged = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            IsGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBlade")
        {
            IsDamaged = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            IsGrounded = false;
        }
    }

}
