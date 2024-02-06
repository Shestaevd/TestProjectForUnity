using Assets.Scripts.State.Modifiers;
using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.State
{

    public static class StateMap
    {

        private static readonly GenericMoveModifier gmm = new GenericMoveModifier();
        private static readonly SlideModifier sm = new SlideModifier();
        private static readonly SpriteRotationModifier srm = new SpriteRotationModifier();
       

        public static State<Player> Idle = new State<Player>("Idle", (ulong) StatePriority.Idle)
            .SetOnStateEnter(entity =>
            {
                entity.Animation.Play("Idle");
            })
            .AddModifier(sm);

        public static State<Player> Move = new State<Player>("Move", (ulong) StatePriority.Move)
            .SetEnterCondition(entity => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            .SetOnStateEnter(entity =>
            {
                entity.Animation.Play("Idle");
            })
            .AddModifier(gmm)
            .AddModifier(srm);

        public static State<Player> Jump = new State<Player>("Jump", (ulong) StatePriority.Jump)
            .SetEnterCondition(entity => Input.GetKeyDown(KeyCode.Space) && entity.IsGrounded)
            .SetOnStateEnter(entity =>
            {
                entity.Animation.Play("Idle");
                entity.Rigidbody.velocity = new Vector2(entity.Rigidbody.velocity.x, entity.JumpHeight);
            });

        public static State<Player> Attack = new State<Player>("Attack", (ulong) StatePriority.Attack)
            .SetEnterCondition(entity => Input.GetKeyDown(KeyCode.Mouse0) && entity.AttackWindowTimer < entity.AttackWindow)
            .SetOnStateEnter(entity =>
            {
                
                Attack.Lock = true;
                entity.Animation.Play("Attack", -1, 0.0f);
                entity.BladeCollider.enabled = true;
                entity.AttackCooldownTimer = 0;
                entity.Struck = false;
            })
            .SetStateLogic(entity =>
            {

                if (entity.BladeCollider.IsTouching(entity.enemy.Collider) && !entity.Struck)
                {
                    entity.Struck = true;
                    entity.enemy.life.RemoveCurrentHp();
                    entity.ClearDamageSafe();
                }

                entity.AttackCooldownTimer = entity.AttackCooldownTimer + Time.deltaTime;
                if (entity.AttackCooldown < entity.AttackCooldownTimer)
                {
                    Attack.Lock = false;
                }
            })
            .SetOnStateExit(entity =>
            {
                entity.Struck = false;
                entity.BladeCollider.enabled = false;
            });

        public static State<Player> GetDamage = new State<Player>("GetDamage", (ulong) StatePriority.Damage)
            .SetEnterCondition(entity => entity.IsDamaged && entity.AttackWindowTimer >= entity.AttackWindow)
            .SetOnStateEnter(entity =>
            {
                entity.life.HighlightCurrentHp();
                entity.Animation.Play("Idle");
                entity.AttackWindowTimer = 0f;
            });

    }

}