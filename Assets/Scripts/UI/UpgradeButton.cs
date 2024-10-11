namespace Assets.Scripts.UI
{
    using UnityEngine;
    using ShopSystem;
    public class UpgradeButton : MonoBehaviour
    {
        [HideInInspector]
        public ShopData shopData;

        public void Upgrade()
        {
            if(GameManager.Instance.Currency<shopData.UpgradePrice) return;

            GameManager.Instance.Currency-=shopData.UpgradePrice;
            shopData.LevelUp();
        }
    }
}