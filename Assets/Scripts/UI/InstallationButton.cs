namespace Assets.Scripts.UI
{
    using Assets.Scripts.ShopSystem;
    using UnityEngine;
    public class InstallationButton : MonoBehaviour
    {
        private GameObject shopsParent;
        [SerializeField]
        private GameObject shopPrefab;
        [HideInInspector]
        public ShopData shopData;
        [SerializeField]
        private GameObject installationPanel;
        [SerializeField]
        private GameObject upgradePanel;
        private void Start()
        {
            shopsParent=GameObject.Find("Shops");
        }
        public void Intstall()
        {
            if(GameManager.Instance.Currency<shopData.InstallationPrice) return;
            GameManager.Instance.Currency-=shopData.InstallationPrice;

            upgradePanel.SetActive(true);
            CreateShop();
            Destroy(installationPanel);
        }
        public void CreateShop()
        {
            GameObject newShop=Instantiate(shopPrefab, shopsParent.transform);
            newShop.GetComponent<ShopObject>().shopData = shopData;
        }
    }
}