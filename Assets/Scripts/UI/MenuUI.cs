namespace Assets.Scripts.UI
{
    using Assets.Scripts.ShopSystem;
    using UnityEngine;
    public class MenuUI : MonoBehaviour
    {
        [SerializeField]
        private ShopData shopData;
        private void Start()
        {
            shopData = GetComponentInParent<ShopObject>().shopData;
        }
        public void OpenBackgroundUI()
        {
            BackgroundUI.Instance.ApplyShopdata(shopData);
        }
        public void OpenUpgradeUI()
        {
            UpgradeUI.Instance.ApplyShopdata(shopData);
        }
        public void OpenPlaceUI()
        {
            PlacementManager.Instance.shopData=shopData;
            PlacementManager.Instance.IsModeOn=true;
        }
    }
}