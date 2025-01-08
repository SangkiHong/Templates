using UnityEngine;

namespace ProjectD.State
{
    public class MoveState : StateBase
    {
        private Unit unit;

        private Vector3 destPoint;
        private float speed;
        private float elapsed;

        private float deadDistance = 0.05f;
        private float breakDistance = 1f;

        public MoveState(Unit unit)
        {
            this.unit = unit;

            deadDistance *= deadDistance;
            breakDistance *= breakDistance;
        }

        public void InitMoveInfo(Vector3 destPoint, float speed)
        {
            this.destPoint = destPoint;
            this.speed = speed;
        }

        public override void EnterState()
        {
            base.EnterState();

            Vector3 dir = destPoint - unit.ThisTransform.position;
            unit.ThisTransform.forward = dir.normalized;
        }

        public override void Tick()
        {
            base.Tick();

            Vector3 direction = destPoint - unit.ThisTransform.position;
            float sqrDistance = direction.sqrMagnitude;
            if (sqrDistance > deadDistance)
            {
                unit.ThisTransform.Translate(direction.normalized * speed * Time.deltaTime);
                SetAnimation(sqrDistance);
            }
            else
            {
                unit.ThisTransform.position = destPoint;
                unit.Idle();
            }
        }

        private void SetAnimation(float distance)
        {
            float currentMoveSpeed = unit.GetAniMoveSpeed();

            if (distance > breakDistance)
            {
                currentMoveSpeed = Mathf.Clamp01(currentMoveSpeed + (speed * Time.deltaTime));
            }
            else
            {
                currentMoveSpeed = Mathf.Clamp01(currentMoveSpeed - Time.deltaTime);
            }

            unit.SetAniMoveSpeed(currentMoveSpeed);
        }
    }
}