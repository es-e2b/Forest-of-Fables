namespace Assets.Scripts.UI
{
    using UnityEngine;
    using ShopSystem;
    using TMPro;
    using UnityEngine.UI;

    public class UpgradeUI : MonoBehaviour
    {
        public static UpgradeUI Instance { get; private set;}
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        [SerializeField]
        private GameObject upgradePanel;
        private ShopData shopData;
        [SerializeField]
        private TMP_Text nameText;
        [SerializeField]
        private Image image;
        [SerializeField]
        private TMP_Text currentLevelText;
        [SerializeField]
        private TMP_Text currentCapacityText;
        [SerializeField]
        private TMP_Text currentRestRewardText;
        [SerializeField]
        private TMP_Text nextLevelText;
        [SerializeField]
        private TMP_Text nextCapacityText;
        [SerializeField]
        private TMP_Text nextRestRewardText;
        [SerializeField]
        private TMP_Text upgradePriceText;
        [SerializeField]
        private Button upgradeButton;
        public void ApplyShopdata(ShopData data)
        {
            if(shopData!=data)
            {
                shopData=data;
            }
            if(!upgradePanel.activeSelf)
            {
                upgradePanel.SetActive(true);
                nameText.text = ""+shopData.ShopName;
                image.sprite=shopData.ShopImage;
            }

            currentLevelText.text=""+shopData.Level;
            currentCapacityText.text=""+shopData.ProductionCapacity;
            currentRestRewardText.text=""+shopData.RestReward;

            nextLevelText.text=""+(shopData.Level+1);
            nextCapacityText.text=""+shopData.CalculateProductionCapacity(shopData.Level+1);
            nextRestRewardText.text=""+shopData.CalculateRestReward(shopData.Level+1);

            upgradePriceText.text=""+shopData.UpgradePrice;

            upgradeButton.onClick.RemoveAllListeners();
            upgradeButton.onClick.AddListener(Upgrade);
        }
        private void Upgrade()
        {
            if(GameManager.Instance.Currency<shopData.UpgradePrice) return;

            GameManager.Instance.Currency-=shopData.UpgradePrice;
            shopData.LevelUp();
            ApplyShopdata(shopData);
        }
    }
}