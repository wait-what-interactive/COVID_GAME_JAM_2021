using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SickIndicator : MonoBehaviour
{
    float currentValue = 0f;

    public float speed;

    Image centerIndicator;

    public Character player;

    private void Start()
    {
        centerIndicator = transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        currentValue = currentValue > 0 ? currentValue - Time.deltaTime*speed/3 : 0;

        centerIndicator.fillAmount = currentValue;
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
            StartCoroutine(GoToIsolator());
    }

    private IEnumerator GoToIsolator()
    {
        player.StopMoving();

        player.PlayIsolationAnimation();
        yield return new WaitForSeconds(1f);

        Camera.main.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.1f);

        SceneManager.LoadScene("Isolator");
    }

    public float GetValue()
    {
        return currentValue;
    }
}
