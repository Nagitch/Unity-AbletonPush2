using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbletonPush2;

public class PseudoPads : MonoBehaviour
{
    public GameObject padBase;
    public float padSpacing = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        // Debug.Log(Pads.S1T1.name);
        // Debug.Log(Pads.All[0].name);
        Pads.All.ForEach(e =>
        // foreach (Pad e in Pads.All)
        {
            Vector3 pos = new Vector3(transform.position.x + (index % 8) * padSpacing, transform.position.y + (Mathf.FloorToInt(index / 8)) * padSpacing, transform.position.z);
            GameObject go = Instantiate(padBase, pos, Quaternion.identity, this.transform);
            go.transform.Find("PadVisual").gameObject.GetComponent<PseudoPad>().pad = e;
            Debug.Log(e.name);
            index++;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
