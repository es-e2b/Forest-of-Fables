namespace Assets.Scripts
{
    using UnityEngine;

    public class ClickSoundPlayer : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                BGMManager.Instance.PlaySound(0);
            }
        }
    }
}