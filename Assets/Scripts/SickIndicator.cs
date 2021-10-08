using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickIndicator : MonoBehaviour
{
    float currentValue = 1;

    public float speed;

    Image leftIndicator;
    Image rightIndicator;
    private void Start()
    {
        leftIndicator = transform.GetChild(0).GetComponent<Image>();
        rightIndicator = transform.GetChild(1).GetComponent<Image>();
    }

    void Update()
    {
        currentValue = currentValue > 0 ? currentValue - Time.deltaTime*speed : 0;

        leftIndicator.fillAmount = currentValue;
        rightIndicator.fillAmount = currentValue;

        if (currentValue == 1)
        {
            //≥зол€ц≥€ гравц€
            print("izolation");
        }
    }

    public void SetValue(float value)
    {
        currentValue = value;
    }

    public float GetValue()
    {
        return currentValue;
    }
}
