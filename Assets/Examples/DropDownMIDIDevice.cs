using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMIDIDevice : MonoBehaviour
{
    public enum ListAs {
        MIDIInDevices,
        MIDIOutDevices,
    }

    public ListAs listAs = ListAs.MIDIInDevices;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RefreshMIDIDeviceList();
    }

	public void RefreshMIDIDeviceList() {
		Dropdown dd = GetComponent<Dropdown>();
		dd.ClearOptions();

        int deviceCount = listAs == ListAs.MIDIInDevices ? MIDIManager.midiInDeviceCount : MIDIManager.midiOutDeviceCount;
		for (var i = 0; i < deviceCount; i++)
        {
            var option = listAs == ListAs.MIDIInDevices ? MIDIManager.MidiInDevices[i] : MIDIManager.MidiOutDevices[i];
			dd.options.Add(new Dropdown.OptionData(option.ToString()) );
		}

		dd.RefreshShownValue();
	}
}
