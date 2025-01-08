using UnityEngine;

namespace ProjectD.State
{
    public class StateMachine
    {
        private Unit unit;
        
        public StateMachine(Unit unit)
            => this.unit = unit;

        public StateBase CurrentState { get; protected set; }

        public virtual void ChangeState(StateBase state)
        {
            if (CurrentState != null)
                Debug.Log($"ChangeState::PrevState: {CurrentState}, NewState: {state}");

            if (CurrentState != null)
                CurrentState.ExitState();

           // unit.currentState = state.ToString();

            CurrentState = state;
            CurrentState.EnterState();
        }

        public virtual bool isAssigned() { return CurrentState != null; }
    }
}