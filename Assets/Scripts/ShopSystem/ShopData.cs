namespace Assets.Scripts.ShopSystem
{
    using UnityEngine;
    using UnityEngine.Events;

    public class ShopData : MonoBehaviour
    {
        public string ShopName;
        public Sprite ShopImage;
        public string BackgroundSummary;
        public string BackgroundDetail;
        public int InstallationPrice;
        public int ProductionTime;
        public int RestTime;

        [HideInInspector]
        public int WorkTime;

        private void Awake()
        {
            WorkTime=ProductionTime*10;
            Level=1;
            productionCapacity=initialCapacity;
            restReward=initialCapacity*2;
            upgradePrice=initialUpgradePrice;
        }

        private int level;
        public int Level
        {
            get => level;
            private set
            {
                level=value;
                OnChangedLevel.Invoke(level);
            }
        }

        private int productionCapacity;
        public int ProductionCapacity
        {
            get => productionCapacity;
            private set
            {
                productionCapacity=value;
                OnChangedProductionCapacity.Invoke(value);
            }
        }

        private int restReward;
        public int RestReward
        {
            get => restReward;
            private set
            {
                restReward=value;
                OnChangedRestReward.Invoke(value);
            }
        }
        
        private int upgradePrice;
        public int UpgradePrice
        {
            get => upgradePrice;
            private set
            {
                upgradePrice=value;
                OnChangedUpgradePrice.Invoke(value);
            }
        }
        [SerializeField]
        private int initialCapacity;
        [SerializeField]
        private int initialUpgradePrice;
        [SerializeField]
        private int CapacityByLevel;
        [SerializeField]
        private int UpgradePriceByLevel;
        public void LevelUp()
        {
            Level++;
            ProductionCapacity=initialCapacity+(level-1)*CapacityByLevel;
            RestReward=ProductionCapacity*2;
            UpgradePrice=initialUpgradePrice+level*UpgradePriceByLevel;
        }

        public UnityEvent<int> OnChangedLevel;
        public UnityEvent<int> OnChangedProductionCapacity;
        public UnityEvent<int> OnChangedRestReward;
        public UnityEvent<int> OnChangedUpgradePrice;
    }
}