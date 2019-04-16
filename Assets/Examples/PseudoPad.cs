using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class PseudoPad : MonoBehaviour
{
    public Pad pad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float pressure = Push2.GetPad(pad);
        transform.localScale = new Vector3(1.0f + pressure, 1.0f + pressure, 1.0f + pressure);
    }
}
