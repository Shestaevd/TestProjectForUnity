
namespace Assets.Scripts.StateMachine
{
    public abstract class StateModifier<T>
    {
        abstract public void UpdateModify(T entity);
        abstract public void EnterModify(T entity);
        abstract public void ExitModify(T entity);
    }
}