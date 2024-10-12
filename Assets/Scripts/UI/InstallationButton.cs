namespace Assets.Scripts.UI
{
    using Assets.Scripts.ShopSystem;
    using UnityEngine;
    using UnityEngine.UI;

    public class InstallationButton : MonoBehaviour
    {
        [HideInInspector]
        public ShopData shopData;
        [SerializeField]
        private GameObject installationPanel;
        [SerializeField]
        private GameObject upgradePanel;
        private void Start()
        {
            if(shopData.IsPlaced)
            Destroy(installationPanel);

            shopData.OnChangedPlaced.AddListener(OnChangedPlaced);
        }
        public void Intstall()
        {
            if(GameManager.Instance.Currency<shopData.InstallationPrice)return;
            GameObject.Find("Info Panel").SetActive(false);
            PlacementManager.Instance.shopData = shopData;
            PlacementManager.Instance.IsModeOn=true;
        }
        private void OnChangedPlaced(bool isPlaced)
        {
            if(isPlaced) Destroy(installationPanel);
        }
    }
}