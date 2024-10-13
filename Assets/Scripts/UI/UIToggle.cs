namespace Assets.Scripts.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIToggle : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> toggleButtons;
        [SerializeField]
        private List<GameObject> openButtons;
        [SerializeField]
        private List<GameObject> closeButtons;
        [SerializeField]
        private GameObject targetPanel;
        private void Start()
        {
            foreach(GameObject openButton in openButtons)
            {
                openButton.GetComponent<Button>().onClick.AddListener(OpenUI);
            }
            foreach(GameObject closeButton in closeButtons)
            {
                closeButton.GetComponent<Button>().onClick.AddListener(CloseUI);
                
            }
            foreach(GameObject toggleButton in toggleButtons)
            {
                toggleButton.GetComponent<Button>().onClick.AddListener(ToggleUI);
            }
        }
        private void OpenUI()
        {
            targetPanel.SetActive(true);
        }
        private void CloseUI()
        {
            targetPanel.SetActive(false);
        }
        private void ToggleUI()
        {
            if(targetPanel.activeSelf)
            {
                targetPanel.SetActive(false);
            }
            else
            {
                targetPanel.SetActive(true);
            }
        }
    }
}