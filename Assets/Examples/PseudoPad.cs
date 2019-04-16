using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class PseudoPad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float pressure = Push2.GetPad(Pads.S8T1);
        transform.localScale = new Vector3(1.0f + pressure, 1.0f + pressure, 1.0f + pressure);
    }
}
