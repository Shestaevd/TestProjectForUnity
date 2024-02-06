using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.State.Modifiers
{
    public class SpriteRotationModifier : StateModifier<Player>
    {
        public override void EnterModify(Player entity)
        {

        }

        public override void ExitModify(Player entity)
        {

        }

        public override void UpdateModify(Player entity)
        {
            float input = Input.GetKey(KeyCode.A) == true ? -1f : Input.GetKey(KeyCode.D) == true ? 1f : 0f;
            if (input < 0) entity.transform.localScale = new Vector3(-1, 1, 1);
            else if (input > 0) entity.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}