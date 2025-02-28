namespace Assets.Scripts.UI
{
    using TMPro;
    using UnityEngine;
    using ShopSystem;
    using UnityEngine.UI;
    
    public class ShopInfoUI : MonoBehaviour
    {
        [SerializeField]
        private InstallationButton installationButton;
        [SerializeField]
        private UpgradeButton UpgradeButton;
        [SerializeField]
        private ShopData shopData;
        [SerializeField]
        private TMP_Text shopName;
        [SerializeField]
        private Image shopImage;
        [SerializeField]
        private TMP_Text levelText;
        [SerializeField]
        private TMP_Text installationText;
        [SerializeField]
        private TMP_Text productionTimeText;
        [SerializeField]
        private TMP_Text workTimeText;
        [SerializeField]
        private TMP_Text productionCapacityText;
        [SerializeField]
        private TMP_Text restTimeText;
        [SerializeField]
        private TMP_Text restRewardText;
        [SerializeField]
        private TMP_Text upgradePriceText;

        private void UpdateLevel(int level)
        {
            levelText.text=""+level;
        }
        private void UpdateProductionCapacity(int productionCapacity)
        {
            productionCapacityText.text=""+productionCapacity;
        }
        private void UpdateUpgradePrice(int upgradePrice)
        {
            upgradePriceText.text=""+upgradePrice;
        }
        private void UpdateRestReward(int restReward)
        {
            restRewardText.text=""+restReward;
        }

        private void Start()
        {
            levelText.text=""+shopData.Level;
            shopName.text=""+shopData.ShopName;
            shopImage.sprite=shopData.ShopImage;
            installationText.text=""+shopData.InstallationPrice;
            productionTimeText.text=""+shopData.ProductionTime;
            workTimeText.text=""+shopData.WorkTime;
            productionCapacityText.text=""+shopData.ProductionCapacity;
            restTimeText.text=""+shopData.RestTime;
            restRewardText.text=""+shopData.RestReward;
            upgradePriceText.text=""+shopData.UpgradePrice;

            installationButton.shopData=shopData;
            UpgradeButton.shopData=shopData;
            
            shopData.OnChangedLevel.AddListener(UpdateLevel);
            shopData.OnChangedProductionCapacity.AddListener(UpdateProductionCapacity);
            shopData.OnChangedUpgradePrice.AddListener(UpdateUpgradePrice);
            shopData.OnChangedRestReward.AddListener(UpdateRestReward);
        }
        
    }
}