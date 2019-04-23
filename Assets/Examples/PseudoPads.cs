using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class PseudoPads : MonoBehaviour
{
    public GameObject padBase;
    public float padSpacingX = 0.03f;
    public float padSpacingY = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        Pads.All.ForEach(e =>
        {
            Vector3 pos = new Vector3(transform.position.x + (index % 8) * padSpacingX, transform.position.y + (Mathf.FloorToInt(index / 8)) * padSpacingY, transform.position.z);
            GameObject go = Instantiate(padBase, pos, Quaternion.identity, this.transform);
            go.transform.Find("PadVisual").gameObject.GetComponent<PseudoPad>().pad = e;
            index++;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
