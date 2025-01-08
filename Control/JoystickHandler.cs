using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SK.Practice
{
    public class JoystickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Image inner;
        [SerializeField] private Image outter;

        private Vector3 _defaultPos;
        private Vector3 _dir;
        private float _radius;

        private void Start()
        {
            if (inner != null)
            {
                _defaultPos = inner.transform.position;

                if (outter != null)
                {
                    _radius = outter.rectTransform.rect.width * 0.5f;
                }
                else
                {
                    Debug.LogError("Need outter image");
                }
            }
            else
            {
                _defaultPos = transform.position;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (inner != null)
            {
                inner.transform.position = eventData.position;
            }

            _dir = ((Vector3)eventData.position - _defaultPos).normalized;
        }
        public void OnDrag(PointerEventData eventData)
        {
            float distance = Vector2.Distance(eventData.position, _defaultPos);

            _dir = ((Vector3)eventData.position - _defaultPos).normalized;

            if (inner != null)
            {
                if (distance > _radius)
                {
                    inner.transform.position = _defaultPos + (_dir * _radius);
                }
                else
                {
                    inner.transform.position = _defaultPos + _dir * distance;
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (inner != null)
            {
                inner.transform.position = _defaultPos;
            }

            _dir = Vector3.zero;
        }
    }
}