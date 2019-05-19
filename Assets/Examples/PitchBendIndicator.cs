using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class PitchBendIndicator : MonoBehaviour
{
    void Update()
    {
        var pos = Push2.GetTouchStripPosition();
        this.transform.localPosition = new Vector3(transform.localPosition.x, pos * 0.5f, transform.localPosition.z);
    }
}
