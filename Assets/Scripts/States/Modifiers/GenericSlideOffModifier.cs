using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.State.Modifiers
{
    public class SlideModifier : StateModifier<Player>
    {
        public override void EnterModify(Player entity)
        {

        }

        public override void ExitModify(Player entity)
        {

        }

        public override void UpdateModify(Player entity)
        {
            entity.Rigidbody.velocity = new Vector2(0f, entity.Rigidbody.velocity.y);
        }
    }
}