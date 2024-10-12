namespace Assets.Scripts.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class DraggableTargetUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public GameObject targetObject;
        private bool isDragging;
        private GraphicRaycaster raycaster;
        public void OnPointerDown(PointerEventData eventData)
        {
            isDragging=true;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if(!isDragging)return;
            targetObject.transform.position+=new Vector3(eventData.delta.x,eventData.delta.y,0)/108;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            isDragging=false;
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