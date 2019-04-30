using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class PseudoPad : MonoBehaviour
{
    public Pad pad;

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        Push2.padPressedDelegate += PadPressed;
        Push2.padReleasedDelegate += PadReleased;
    }

    public void PadPressed(Pad pad, float velocity)
    {
        if (this.pad.number != pad.number)
        {
            return;
        }

        Push2.SetLED(pad, LED.Color.RGB.Red, LED.Animation.Blinking8th);
        transform.localScale = new Vector3(1.0f + velocity, 1.0f + velocity, 1.0f + velocity);
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void PadReleased(Pad pad)
    {
        if (this.pad.number != pad.number)
        {
            return;
        }
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GetComponent<Renderer>().material.color = Color.gray;
        Push2.SetLED(pad, LED.Color.RGB.LightGray);
    }
}
