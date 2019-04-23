using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class PseudoPad : MonoBehaviour
{
    public Pad pad;

    private float pressureBefore;

    // Update is called once per frame
    void Update()
    {
        float pressure = (float)Push2.GetPad(pad).pressure;
        transform.localScale = new Vector3(1.0f + pressure, 1.0f + pressure, 1.0f + pressure);

        if (pressureBefore != pressure)
        {
            Push2.SetLED(pad, LED.Color.RGB.Blue, LED.Animation.OneShot16th);
            GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(SetLedBlack());
        }

        pressureBefore = pressure;
    }

    private IEnumerator SetLedBlack()
    {
        yield return new WaitForSeconds(0.3f);
        Push2.SetLED(pad, LED.Color.RGB.Black);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
