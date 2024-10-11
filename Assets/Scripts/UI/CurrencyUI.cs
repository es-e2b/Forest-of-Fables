namespace Assets.Scripts.UI
{
    using TMPro;
    using UnityEngine;
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text currecnyText;
        private void Start()
        {
            currecnyText.text=GameManager.Instance.Currency+"G";

            GameManager.Instance.OnChangedCurrency.AddListener(UpdateCurrecny);
        }
        private void UpdateCurrecny(int currency)
        {
            currecnyText.text=currency+"G";
        }
    }
}