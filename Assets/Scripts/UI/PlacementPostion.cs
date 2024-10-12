namespace Assets.Scripts.UI
{
    using Assets.Scripts.ShopSystem;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class PlacementPostion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        public ShopData ShopData;
        [SerializeField]
        private Image placementImage;
        [SerializeField]
        private GameObject placementPanel;
        private bool isPlaceable;


        private void Start()
        {
            PlacementManager.Instance.OnPlaceModeChanged.AddListener(OnChangedMode);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(ShopData!=null)return;

            isPlaceable=true;
            placementImage.gameObject.SetActive(true);
            placementImage.sprite=PlacementManager.Instance.shopData.ShopImage;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            print("good2");
            if(!isPlaceable)return;
            print("good3");
            if(!PlacementManager.Instance.shopData.IsPlaced&&PlacementManager.Instance.CanIntstall())
            {
                print("good");
                PlacementManager.Instance.CreateShop().GetComponent<ShopObject>().shopData.ShopPosition=gameObject;
            }
            else
            {
                PlacementManager.Instance.shopData.ShopPosition=gameObject;
            }

            PlacementManager.Instance.IsModeOn=false;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            if(!isPlaceable)return;

            placementImage.gameObject.SetActive(false);
        }
        private void OnChangedMode(bool mode)
        {
            if(!mode)
            {
                placementImage.gameObject.SetActive(false);
                isPlaceable=false;
            }
            placementPanel.SetActive(mode);
        }
    }
}