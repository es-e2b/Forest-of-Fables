namespace Assets.Scripts.UI
{
    using Assets.Scripts.ShopSystem;
    using UnityEngine;
    using UnityEditor.Animations;

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
        [SerializeField]
        private Animator shopAnimeControl;
        [SerializeField]
        private AnimationClip shopAnime;

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
            newShop.GetComponent<Animator>().runtimeAnimatorController = shopData.ShopAnimeControl;
        }
    }
}