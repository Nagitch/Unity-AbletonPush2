using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class noteoneshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Send()
    {
        MidiJack.MidiMaster.SendNoteOn(Push2.MidiOutDeviceId, MidiJack.MidiChannel.Ch1, Pads.S1T1.number, 1.0f);
    }
}
