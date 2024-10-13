namespace Assets.Scripts.ShopSystem
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEditor.Animations;
    using UI;

    public class ShopData : MonoBehaviour
    {
        private bool isPlaced;
        public bool IsPlaced
        {
            get => isPlaced;
            set
            {
                isPlaced = value;
                OnChangedPlaced.Invoke(value);
            }
        }
        [HideInInspector]
        public GameObject shopObject;
        private GameObject shopPosition;
        public GameObject ShopPosition
        {
            get => shopPosition;
            set
            {
                if(shopPosition != null)
                    shopPosition.GetComponent<PlacementPostion>().ShopData=null;
                shopPosition = value;
                if(value != null && shopObject != null)
                {
                    shopObject.transform.SetParent(shopPosition.transform);
                    shopObject.transform.SetSiblingIndex(0);
                    shopObject.GetComponent<RectTransform>().anchoredPosition=Vector2.zero;
                    value.GetComponent<PlacementPostion>().ShopData=this;
                }
            }
        }
        public string ShopName;
        public Sprite ShopImage;
        public AnimatorController ShopAnimeControl;
        public string BackgroundSummary;
        public string[] BackgroundDetail;
        public int InstallationPrice;
        public int ProductionTime;
        public int RestTime;

        [HideInInspector]
        public int WorkTime;

        private void Awake()
        {
            WorkTime=ProductionTime*10;
            Level=1;
        }

        private int level;
        public int Level
        {
            get => level;
            private set
            {
                BGMManager.Instance.PlaySound(1);
                level=value;
                OnChangedLevel.Invoke(level);
                ProductionCapacity=CalculateProductionCapacity(level);
                RestReward=CalculateRestReward(level);
                UpgradePrice=CalculateUpgradePrice(level);
                
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
        }
        public int CalculateProductionCapacity(int level)
        {
            return initialCapacity+level*CapacityByLevel;
        }
        public int CalculateRestReward(int level)
        {
            return ProductionCapacity*4;
        }
        public int CalculateUpgradePrice(int level)
        {
            return initialUpgradePrice+level*UpgradePriceByLevel;
        }

        public UnityEvent<int> OnChangedLevel;
        public UnityEvent<int> OnChangedProductionCapacity;
        public UnityEvent<int> OnChangedRestReward;
        public UnityEvent<int> OnChangedUpgradePrice;
        public UnityEvent<bool> OnChangedPlaced;
    }
}