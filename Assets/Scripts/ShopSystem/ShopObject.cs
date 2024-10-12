namespace Assets.Scripts.UI
{
    using ShopSystem;
    using UnityEngine;
    using UnityEngine.Events;

    public class ShopObject : MonoBehaviour
    {
        public ShopData shopData;
        public UnityEvent OnProductionComplete;

        public void test()
        {
            OnProductionComplete.Invoke();
        }
    }
}