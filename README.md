# Unity-AbletonPush2

MIDI interface for controls Ableton Push2 from Unity.
(no display control. sorry)

## Limitations

- API cannot recognize MIDI IN devices individually. it means API can't identify what device sends MIDI message to Unity. (from Push2, or another one) so, e.g. connected Push2 and MIDI keyboard in same time, then you play keyboard, GetPad(Pad) might returns the value.
- API cannot switch Push2 mode (Live/User/Dual mode) itself. it means you can't run your project and Ableton Live in same time.
- touch strip configuration is not modifiable.
- Pad LED's color pallet is not modifiable.

## Installation

- Unity-AbletonPush2 is depend on MIDIJack. download and import package from here.
- download and import package Unity-AbletonPush2 from here.

## API Reference

### Note

API specification is based on [Push2 interface official documentation](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc).

and also parts/controls namings are based on this resource [Push2-map.json](https://github.com/Ableton/push-interface/blob/master/doc/Push2-map.json).

- Pad.S8T1 = the pad of bottom, left corner positioned.
- Pad.S8T2 = the pad of bottom, left +1 right positioned.
- Pad.S1T8 = the pad of top, right positioned.

### Receive messages from Push 2

- Pad GetPad(Pad)
- float GetPadPressure(Pad)
- float GetPadAfterTouch(Pad)
- Button GetButton(Button)
- bool GetButtonPressed(Button)
- TouchStrip GetTouchStrip(TouchStrip)
- RotaryEncoder GetEncoder(RotaryEncoder)
- float GetEncoderStep(Encoder)
- bool GetEncoderTouched(EncoderTouch)


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

- SetLED(Part\[Pad|Button\], LEDColor, LEDAnimation = LEDAnimation.None)

  Turn LED on / off. LEDAnimation is selectable below, based on [this section in Push2 spec document](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc#LED%20Animation).
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
    SetLED(LED.Pad.All, LEDColor.RGB.White, LEDAnimation.TurnOn);
    // 
    SetLED(LED.Pad.S8T1, LEDColor.RGB.Red, LEDAnimation.Blinking16th);
    // turn off TapTempo button LED. LEDColor Black means turn off
    SetLED(LED.Button.TapTempo, LEDColor.Mono.Black);
    // 
    SetLED(LED.Button.UpperRow1, LEDColor.Black);
```

`LEDColor.RGB.xxx` is available only RGBLEDs. you can see what button/control has RGBLED in here. [Push Interface document](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc#MIDI%20Mapping)
