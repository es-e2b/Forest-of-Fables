namespace Assets.Scripts.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DraggableTargetUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public GameObject targetObject;
        private bool isDragging;
        public GameObject[] shopImages;
        public static List<GameObject> others;
        private void Start()
        {
                
        }
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
    }
}