using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public class StateMachine<T>
    {
        public AbstractState<T> CurrentState = State<T>.GetEmpty();
        private StateManager<T> Manager;
        private T Entity;
        public StateMachine(StateManager<T> manager)
        {
            Manager = manager;
            Entity = manager.Entity;
        }
        public StateMachine(T entity)
        {
            Entity = entity;
            Manager = new StateManager<T>(Entity);
        }

        public StateManager<T> GetManager()
        {
            return Manager;
        }

        public void Run()
        {
            AbstractState<T> previous = CurrentState;
            if (Manager.GetNewState(ref CurrentState))
            {
                previous.OnExit(Entity);
                CurrentState.OnEnter(Entity);
                CurrentState.OnUpdate(Entity);
            }
            else
            {
                CurrentState.OnUpdate(Entity);
            }
        }

        public void TransitionTo(AbstractState<T> newState)
        {
            CurrentState.OnExit(Entity);
            CurrentState = newState;
            newState.OnEnter(Entity);
        }
    }

}
