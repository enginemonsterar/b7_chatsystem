using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Michsky.UI.ModernUIPack
{
    public class ProgressBar : MonoBehaviour
    {
        [Header("OBJECTS")]
        public Transform loadingBar;
        public Transform textPercent;

        [Header("SETTINGS")]
        public bool isOn;
        public bool restart;
        public bool invert;
        [Range(0, 100)] public float currentPercent;
        [Range(0, 100)] public int speed;

        [Header("SPECIFIED PERCENT")]
        public bool enableSpecified;
        public bool enableLoop;
        [Range(0, 100)] public float specifiedValue;

        void Start()
        {
            if (enableSpecified == true)
                currentPercent = specifiedValue;
        }

        void Update()
        {
            if (currentPercent <= 100 && isOn == true && enableSpecified == false && invert == false)
                currentPercent += speed * Time.deltaTime;

            else if (currentPercent >= 0 && isOn == true && enableSpecified == false && invert == true)
                currentPercent -= speed * Time.deltaTime;

            if (currentPercent == 100 || currentPercent >= 100 && restart == true && invert == false && enableSpecified == false)
                currentPercent = 0;

            else if (currentPercent == 0 || currentPercent <= 0 && restart == true && invert == true && enableSpecified == false)
                currentPercent = 100;

            if (isOn == true && enableSpecified == true)
            {
                if (currentPercent <= specifiedValue)
                    currentPercent += speed * Time.deltaTime;

                if (enableLoop == true && currentPercent == specifiedValue || currentPercent >= specifiedValue)
                    currentPercent = 0;
            }

            loadingBar.GetComponent<Image>().fillAmount = currentPercent / 100;
            textPercent.GetComponent<TextMeshProUGUI>().text = ((int)currentPercent).ToString("F0") + "%";
        }
    }
}