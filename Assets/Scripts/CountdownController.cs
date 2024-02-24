using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;

    private void start ()
    {
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }


           countdownDisplay.text = "WRESTLE!";

          // GameController.instance.BeginGame();

           yield return new WaitForSeconds(1f);

           countdownDisplay.gameObject.SetActive(false);

    }

}
