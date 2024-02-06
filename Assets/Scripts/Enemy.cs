using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Cooldown between attacks")]
    [SerializeField] public float AttackCooldown = 1.0f;

    [Header("Enemy life")]
    [SerializeField] public EnemyHp life;

    [Header("Enemy colider")]
    [SerializeField] public Collider2D Collider;

    [Header("Blade colider")]
    [SerializeField] public Collider2D BladeCollider;

    [Header("Player")]
    [SerializeField] public Player Player;

    private Animator Animation;
    private float AttackCooldownTimer = 0.0f;

    void Start()
    {
        Animator animation = gameObject.GetComponent<Animator>();
        if (animation) Animation = animation; else Debug.LogError(gameObject.name + " need Animation");
    }

    void Update()
    {
        LookAtPlayer();
        Attack();
    }

    void LookAtPlayer()
    {
        float input =  Player.transform.position.x - transform.position.x >= 0 ? 1 : -1;
        if (input < 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (input > 0) transform.localScale = new Vector3(1, 1, 1);
    }

    private void Attack()
    {
        AttackCooldownTimer += Time.deltaTime;
        //float animLength = Animation.GetCurrentAnimatorStateInfo(0).length;
        //Debug.Log(animLength);
        //if (AttackCooldownTimer > animLength)
        //{
        //    Debug.Log("Blade off");
        //    BladeCollider.enabled = false;
        //}
        //else
        //{
        //    Debug.Log("Blade on");
        //    BladeCollider.enabled = true;
        //}

        if (AttackCooldownTimer > AttackCooldown)
        {
            AttackCooldownTimer = 0f;
            Animation.Play("Attack", -1, 0.0f);
        }
    }
}