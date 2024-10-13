namespace Assets.Scripts.UI
{
    using Assets.Scripts.ShopSystem;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class BackgroundUI : MonoBehaviour
    {
        public static BackgroundUI Instance { get; private set;}
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
        private GameObject backgroundPanel;
        private ShopData shopData;
        [SerializeField]
        private TMP_Text nameText;
        [SerializeField]
        private Image image;
        [SerializeField]
        private GameObject descriptionObject;
        [SerializeField]
        private GameObject descriptionPrefab;
        public void ApplyShopdata(ShopData data)
        {
            shopData=data;

            nameText.text = ""+shopData.ShopName;
            image.sprite=shopData.ShopImage;

            foreach(string detail in shopData.BackgroundDetail)
            {
                GameObject detailObject=Instantiate(descriptionPrefab, descriptionObject.transform);
                detailObject.GetComponent<TMP_Text>().text=detail;
            }

            backgroundPanel.SetActive(true);
        }
    }
}