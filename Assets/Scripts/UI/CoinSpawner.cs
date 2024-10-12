namespace Assets.Scripts.UI
{
    using UnityEngine;
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject spawnedCoin;
        private float Timesetting = 0f;
        public bool isOccuring = false;
        private Vector2 startPosition;
        private RectTransform coinTransform;
        
        private void Start()
        {
            coinTransform=spawnedCoin.GetComponent<RectTransform>();
            GetComponent<ShopObject>().OnProductionComplete.AddListener(SpawnCoinAbove);
        }
        public void SpawnCoinAbove()
        {
            startPosition=coinTransform.anchorMin;
            spawnedCoin.SetActive(true);
            isOccuring = true;
        }

        public void Update()
        {
            if(isOccuring == true)
            {
                Timesetting += Time.deltaTime;
                coinTransform.anchorMin=coinTransform.anchorMax+=new Vector2(0,Time.deltaTime)*0.125f;
                if(Timesetting>=1f)
                {
                    spawnedCoin.SetActive(false);
                    coinTransform.anchorMin=coinTransform.anchorMax=startPosition;
                    Timesetting = 0f;
                    isOccuring = false;
                }
            }
        }
    }
}