namespace Assets.Scripts.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class DraggableTargetUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField]
        private GameObject targetUI;
        private GraphicRaycaster raycaster;
        private RectTransform targetRectTransform;
        private bool isDragging;
        private void Awake()
        {
            raycaster = GetComponentInParent<GraphicRaycaster>();
            targetRectTransform = targetUI.GetComponent<RectTransform>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if(!IsPointerOverUIObject(eventData)) return;

            isDragging = true;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if(!isDragging) return;

            targetRectTransform.anchoredPosition += new Vector2(eventData.delta.x, eventData.delta.y);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            isDragging = false;
        }
        private bool IsPointerOverUIObject(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(eventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject == gameObject)
                {
                    return true;
                }
            }
            return false;
        }
    }
}