using System;

namespace ProjectD.State
{
    public abstract class StateBase
    {
        public Action OnEnterHandler;
        public Action OnFixedTickHandler;
        public Action OnTickHandler;
        public Action OnExitHandler;

        public virtual void EnterState() { OnEnterHandler?.Invoke(); }
        public virtual void FixedTick() { OnFixedTickHandler?.Invoke(); }
        public virtual void Tick() { OnTickHandler?.Invoke(); }
        public virtual void ExitState(){ OnExitHandler?.Invoke(); }
    }
}