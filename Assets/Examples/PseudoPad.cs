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
        float pressure = Push2.GetPad(pad);
        transform.localScale = new Vector3(1.0f + pressure, 1.0f + pressure, 1.0f + pressure);

        if (pressureBefore != pressure)
        {
            Push2.SetLED(pad, LED.Color.RGB.Green, LED.Animation.Pulsing8th);
            StartCoroutine(SetLedBlack());
        }

        pressureBefore = pressure;
    }

    private IEnumerator SetLedBlack()
    {
        yield return new WaitForSeconds(0.3f);
        Push2.SetLED(pad, LED.Color.RGB.Black);
    }
}
