using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Templates
{
    public class JoystickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Header("UI")]
        [SerializeField] private Image inner;
        [SerializeField] private Image outter;

        [Header("Info")]
        [SerializeField] private Vector3 defaultPos;
        [SerializeField] private Vector3 dir;
        [SerializeField] private float radius = 300f;

        private void Start()
        {
            if (inner != null)
            {
                defaultPos = inner.transform.position;

                if (outter != null)
                {
                    radius = outter.rectTransform.rect.width * 0.5f;
                }
                else
                {
                    Debug.LogError("Need outter image");
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //dir = ((Vector3)eventData.position - defaultPos).normalized;
            defaultPos = eventData.position;

            if (inner != null)
            {
                inner.transform.position = eventData.position;
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            dir = Normalize((Vector3)eventData.position - defaultPos);

            if (inner != null)
            {
                float distance = Vector2.Distance(eventData.position, defaultPos);

                if (distance > radius)
                {
                    inner.transform.position = defaultPos + (dir * radius);
                }
                else
                {
                    inner.transform.position = defaultPos + dir * distance;
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            dir = Vector3.zero;

            if (inner != null)
            {
                inner.transform.position = defaultPos;
            }
        }

        private Vector3 Normalize(Vector3 dir)
        {
            dir.x = Mathf.Clamp(dir.x / radius, -1, 1);
            dir.y = Mathf.Clamp(dir.y / radius, -1, 1);
            dir.z = Mathf.Clamp(dir.z / radius, -1, 1);

            return dir;
        }
    }
}