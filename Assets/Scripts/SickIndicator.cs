using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickIndicator : MonoBehaviour
{
    float currentValue = 0.5f;

    public float speed;

    Slider leftIndicator;
    Slider rightIndicator;

    public Character player;

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
    }

    IEnumerator IzolatePlayer()
    {
        while (currentValue >= 0.01) 
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }
        player.ResetMoving();
    }

    public void SetValue(float value)
    {
        currentValue = value;

        if (currentValue >= 0.98)
        {
            player.StopMoving();
            StartCoroutine(IzolatePlayer());
            print("izolation");
            player.PlayIsolationAnimation();
        }
    }

    public float GetValue()
    {
        return currentValue;
    }
}
