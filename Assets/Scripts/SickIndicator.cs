using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickIndicator : MonoBehaviour
{
    float currentValue = 0;

    public float speed;

    Slider leftIndicator;
    Slider rightIndicator;
    private void Start()
    {
        leftIndicator = transform.GetChild(0).GetComponent<Slider>();
        rightIndicator = transform.GetChild(1).GetComponent<Slider>();
    }

    void Update()
    {
        currentValue = currentValue > 0 ? currentValue - Time.deltaTime*speed : 0;

        leftIndicator.value = currentValue;
        rightIndicator.value = currentValue;

        if (currentValue == 1)
        {
            //�������� ������
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
