using System.Collections;
using UnityEngine;

namespace ProjectD.State
{
    public class IdleState : StateBase
    {
        private Unit unit;

        public IdleState(Unit unit)
        {
            this.unit = unit;
        }

        public override void EnterState()
        {
            base.EnterState();

            unit.SetAniMoveSpeed(0);
        }
    }
}