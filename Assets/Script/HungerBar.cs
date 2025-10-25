using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;
    [SerializeField]
    private Text fillText;

    private void Start()
    {
        PlayerHunger.OnHungerUpdated += UpdateBar;
    }
    private void UpdateBar(float current, float max)
    {
        fillImage.fillAmount = current / max;
        fillText.text = $"{current}/{max}";
    }
}
