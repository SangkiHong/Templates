using System;

namespace ProjectD.State
{
    public class ActionState : StateBase
    {
        protected Unit unit;

        private static string AnimParam_OnAction;

        public ActionState(Unit unit)
        {
            this.unit = unit;
        }

        private bool onCheck;

        public Action OnEndAction;

        public override void EnterState()
        {
            onCheck = false;

            base.EnterState();
        }

        public override void FixedTick()
        {
            base.FixedTick();

            bool onActing = unit.Animator.GetBool(AnimParam_OnAction);

            if (!onCheck && onActing)
            {
                onCheck = true;
            }
            else if (onCheck && onActing == false)
            {
                onCheck = false;
                unit.Idle();

                OnEndAction?.Invoke();
            }
        }
    }
}