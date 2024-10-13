namespace Assets.Scripts.UI
{
    using Assets.Scripts.ShopSystem;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class PlacementManager : MonoBehaviour
    {
        public static PlacementManager Instance { get; private set;}
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        // [HideInInspector]
        public ShopData shopData;
        private GameObject shopPrefab;
        private bool isModeOn;
        public bool IsModeOn
        {
            get => isModeOn;
            set
            {
                isModeOn = value;
                OnPlaceModeChanged.Invoke(value);
            }
        }
        private void Start()
        {
            shopPrefab=Resources.Load<GameObject>("Shop Object");
        }
        public bool CanIntstall()
        {
            return GameManager.Instance.Currency>=shopData.InstallationPrice;
        }
        public GameObject CreateShop()
        {
            GameManager.Instance.Currency-=shopData.InstallationPrice;

            GameObject newShop=Instantiate(shopPrefab, GameObject.Find("Shops").transform);
            newShop.GetComponent<ShopObject>().shopData = shopData;
            newShop.GetComponent<Image>().sprite = shopData.ShopImage;
            shopData.IsPlaced = true;
            shopData.shopObject = newShop;
            newShop.GetComponent<Animator>().runtimeAnimatorController = shopData.ShopAnimeControl;

            return newShop;
        }

        public UnityEvent<bool> OnPlaceModeChanged;
    }
}