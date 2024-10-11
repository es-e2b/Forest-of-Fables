namespace Assets.Scripts
{
    using System.Collections.Generic;
    using UnityEngine;
    using ShopSystem;
    using UnityEngine.Events;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set;}
        [SerializeField]
        private int currency;
        public int Currency
        {
            get => currency;
            set
            {
                currency=value;
                OnChangedCurrency.Invoke(value);
            }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        public UnityEvent<int> OnChangedCurrency;
    }
}