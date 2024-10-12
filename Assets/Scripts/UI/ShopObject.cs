namespace Assets.Scripts.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using ShopSystem;
    using UnityEngine.Events;

    public class ShopObject : MonoBehaviour
    {
        public Image WorkGauge;
        public bool RestState;
        public bool TiredState;
        private bool isAnimating = false;
        private float elapsedTime = 0f;
        private float startValue;
        private float targetValue;
        private float animationTime;
        private int min;
        private int max;
        public bool activeSelf;
        public int Times = 1;
        public ShopData shopData;
        public GameObject coinSpawner;
        public GameObject RestButton;
        public UnityEvent OnProductionComplete;

        public void Start()
        {
            SomeMethod();
        }

        public void Update()
        {   
            if(RestState == false){
                if(Times == 8){
                    TiredState = true;
                    RestButton.SetActive(true);
                }
                if(Times == 10){
                    RestState = true;
                    TiredState = false;
                    Invoke("ChangeState", shopData.RestTime);
                    RestButton.SetActive(false);
                }
                if(WorkGauge.fillAmount <= 0.01){
                    GameManager.Instance.Currency += shopData.ProductionCapacity ;
                    OnProductionComplete.Invoke();
                    SomeMethod();
                }
            }

            if (isAnimating)
            {
                elapsedTime += Time.deltaTime;
                float currentValue = startValue + ((targetValue - startValue) * (elapsedTime / animationTime));
                WorkGauge.fillAmount = (currentValue - min) / (max - min);

                if (elapsedTime >= animationTime)
                {
                    isAnimating = false;
                    WorkGauge.fillAmount = (targetValue - min) / (max - min);
                }
            }
        }

        public void FallAsleep(){
            OnProductionComplete.Invoke();
            isAnimating = false;
            RestButton.SetActive(false);
            RestState = true;
            WorkGauge.fillAmount = 1;
            GameManager.Instance.Currency += shopData.ProductionCapacity*4 ;
            Invoke("ChangeState", shopData.RestTime);
        }

        void ChangeState(){
            RestState = false;
            Times = 0;
            SomeMethod();
        }
        
        public void StartGaugeAnimation(int min, int max, int startValue, int targetValue, float animationTime)
        {
            this.min = min;
            this.max = max;
            this.startValue = startValue;
            this.targetValue = targetValue;
            this.animationTime = animationTime;

            elapsedTime = 0f;
            isAnimating = true;
        }

        public void SomeMethod()
        {
            //StartGaugeAnimation(0, 100, 100, 1, shopData.ProductionTime); // 예: 5초 동안 20에서 80으로 애니메이션
            StartGaugeAnimation(0, 100, 100, 1, 3);
            Times++;
        }

        public UnityEvent<bool> OnChangedRestState;
    }
}