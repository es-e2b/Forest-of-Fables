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
        [SerializeField]
        private float Speed = 0.5f;
        
        private void Start()
        {
            coinTransform=spawnedCoin.GetComponent<RectTransform>();
            GetComponent<ShopObject>().OnProductionComplete.AddListener(SpawnCoinAbove);
        }
        public void SpawnCoinAbove()
        {
            BGMManager.Instance.PlaySound(2);
            startPosition=coinTransform.anchorMin;
            spawnedCoin.SetActive(true);
            isOccuring = true;
        }

        public void Update()
        {
            if(isOccuring == true)
            {
                Timesetting += Time.deltaTime;
                coinTransform.anchorMin=coinTransform.anchorMax+=new Vector2(0,Time.deltaTime)*Speed;
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