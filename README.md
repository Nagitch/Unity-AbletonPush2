# Unity-AbletonPush2

MIDI interface for controls Ableton Push2 from Unity.
(no display control. sorry)

## Limitations

- API cannot switch Push2 mode (Live/User/Dual mode) itself. This means you can't run your project and Ableton Live in same time.
- touch strip configuration is not modifiable.
- Pad LED's color pallet is not modifiable.

## Installation

- Unity-AbletonPush2 is depend on MIDIJack. download and import package from here.
- download and import package Unity-AbletonPush2 from here.

## API Reference

### Notes

API specification is based on [Push2 interface official documentation](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc).

and also Parts/controls namings are based on this resource [Push2-map.json](https://github.com/Ableton/push-interface/blob/master/doc/Push2-map.json).

PadS8T1 = the pad of bottom, left corner positioned.
PadS8T2 = the pad of bottom, left +1 right positioned.
PadS1T8 = the pad of top, right positioned.

### Receive messages from Push 2

- GetPad(Pad)
- GetButton(Button)
- GetTouchStrip(TouchStrip)
- GetEncoder(Encoder)
- GetEncoderTouch(EncoderTouch)


Their delegates are available.

- PadPressedDelegate(Pad, velocity)
- PadReleasedDelegate(Pad)
- ButtonPressedDelegate(Button)
- ButtonReleasedDelegate(Button)
- EncoderDelegate(Encoder, movement)
- EncoderTouchedDelegate(EncoderTouch)
- EncoderReleasedDelegate(EncoderTouch)
- TouchStripTouchedDelegate(TouchStrip)
- TouchStripReleasedDelegate(TouchStrip)


### Synchronization / clock

- SendClock()
  
  send MIDI clock message to Push2 (for use LED animation sync).

### Pad / Button LEDs

- SetLEDLight(LED, LEDColor, LEDAnimation = LEDAnimation.None)

  Turn LED light on / off. LEDAnimation is selectable below, based on [this section of Push2 spec document](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc#LED%20Animation).
  - None (stop transition)
  - 1shot24th
  - 1shot16th
  - 1shot8th
  - 1shotQuarter
  - 1shotHalf
  - Pulsing24th
  - Pulsing12th
  - Pulsing8th
  - PulsingQuarter
  - PulsingHalf
  - Blinking24th
  - Blinking16th
  - Blinking8th
  - BlinkingQuarter
  - Blinking24Half

Example

```cs
using AbletonPush2;
// ...
    // Turn on all pad LEDs.
    SetLEDLight(LED.Pad.All, LEDColor.RGB.White, LEDAnimation.TurnOn);
    // 
    SetLEDLight(LED.Pad.S8T1, LEDColor.RGB.Red, LEDAnimation.Blinking16th);
    // turn off TapTempo button LED. LEDColor Black means turn off
    SetLEDLight(LED.Button.TapTempo, LEDColor.Mono.Black);
    // 
    SetLEDLight(LED.Button.UpperRow1, LEDColor.Black);
```

`LEDColor.RGB.xxx` is available only RGBLEDs. you can see what button/control has RGBLED in here. [Push Interface document](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc#MIDI%20Mapping)