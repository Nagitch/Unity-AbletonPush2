# Unity-AbletonPush2

MIDI interface for controls Ableton Push2 from Unity.
(no display control. sorry)

## Limitations

- No display control
- API cannot recognize MIDI IN devices individually. it means API can't identify what device sends MIDI message to Unity. (from Push2, or another one) so, e.g. connected Push2 and MIDI keyboard in same time, then you play keyboard, GetPad(Pad) should returns the value.
- API cannot switch Push2 mode (Live/User/Dual mode) itself. it means you can't run your project and Ableton Live in same time.
- touch strip configuration is not modifiable.
- Pad LED's color pallet is not modifiable.
- Polyphonic after touch is not supported.

## Installation

- Unity-AbletonPush2 is depend on MIDIJack. download and import package from here.
- download and import package Unity-AbletonPush2 from here.

## API Reference

### Note

Include namespace:

```cs
using AbletonPush2;
```

API specification is based on [Push2 interface official documentation](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc).

and also parts/controls namings are referred [Push2-map.json](https://github.com/Ableton/push-interface/blob/master/doc/Push2-map.json).

- Pad.S1T8 = the pad of top, right positioned.
- Pad.S8T1 = the pad of bottom, left corner positioned.
- Pad.S8T2 = the pad of bottom, left +1 right positioned.

### Receive messages from Push 2

- Pad Push2.GetPad(Pad)

    get pad's data, include pressure (between 0.0 to 1.0 value). `Pad` is entity of Push2 pad,
    and you can use `Pads.S1T1, Pads.S1T2...` pre-defined indicator. like this:

    ```cs
    var pad = Push2.GetPad(Pads.S8T1);
    Debug.Log(pad.pressure); // between 0.0f - 1.0f
    ```

- float Push2.GetPadPressure(Pad)

    get just pad's pressure value.

- float Push2.GetAfterTouchPressure()

    get pad's after touch. this is `Channel Aftertouch`, don't care for whitch pad is pressed.

- Button Push2.GetButton(Button)

    get button's data, a sort of `GetPad()`. also you can use `Buttons.Play, Buttons.TapTempo, ...` pre-defined indicator.

    ```cs
    var button = Push2.GetButton(Pads.S8T1);
    Debug.Log(button.pressed); // true as pressed
    ```

- bool Push2.GetButton(Button)

    get just button's pressed status. `true` as pressed.

- TouchStrip Push2.GetTouchStrip(TouchStrip)

    get TouchStrip's data, include bend position.

    ```cs
    var touchStrip = Push2.GetTouchStrip(Pads.S8T1);
    Debug.Log(touchStrip.position); // between -1.0f to 1.0f
    ```

- float Push2.GetTouchStripPosition()

    get just touch strip position. (between -1.0f to 1.0f)

- RotaryEncoder Push2.GetEncoder(RotaryEncoder)

    get RotaryEncoder's data, include rotation step. you can use `RotaryEncoders.TempoEncoder, RotaryEncoders.Track1Encoder, ...` indicator.

    _Note: encoder step is very small value around 0.01._

    ```cs
    var encoder = Push2.GetEncoder(RotaryEncoders.Track1Encoder);
    Debug.Log(encoder.step); // between -1.0f to 1.0f, minus as left
    ```

- float Push2.GetEncoderStep(RotaryEncoder)

    get just encoder's rotation step. (between -1.0f to 1.0f, minus as left)

- bool Push2.GetEncoderTouched(RotaryEncoder)

    get encoder touched status.

    ```cs
    Push2.GetEncoderTouched(RotaryEncoders.Track1Encoder); // true as touched
    ```


Their delegates are available.

- PadPressedDelegate(Pad, pressure)
- PadReleasedDelegate(Pad)
- ButtonPressedDelegate(Button)
- ButtonReleasedDelegate(Button)
- EncoderDelegate(Encoder, step)
- EncoderTouchedDelegate(Encoder)
- EncoderReleasedDelegate(Encoder)
- TouchStripTouchedDelegate(TouchStrip)
- TouchStripReleasedDelegate(TouchStrip)
- AfterTouchDelegate(pressure)


### Pad / Button LEDs

- SetLED(\[Pad|Button\], LED.Color, LED.Animation)

  Turn LED on / off, with color and animation.

  ```cs
  using AbletonPush2;
      // Turn on all pad LEDs to white.
      SetLED(Pad.All, LED.Color.RGB.White);
      // Turn on pad of bottom, left corner positioned to Red, blinking 16 beat
      SetLED(Pad.S8T1, LED.Color.RGB.Red, LEDAnimation.Blinking16th);
      // turn off TapTempo button LED. LEDColor Black means turn off
      SetLED(Button.TapTempo, LED.Color.Mono.Black);
  ```

  `LEDColor.RGB.xxx` is available only RGB LEDs. you can see what button/control has RGBLED in here. [Push Interface document](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc#MIDI%20Mapping)

  and, you can indicate _color number_ below, instead of LEDColor.RGB definitions. based on Push2 default color pallet.

  ![ColorPallet0-63](https://github.com/Nagitch/Unity-AbletonPush2/blob/orphan-docs/images/color-pallet-1.jpeg)

  ![ColorPallet64-127](https://github.com/Nagitch/Unity-AbletonPush2/blob/orphan-docs/images/color-pallet-2.jpeg)

  LED.Animation is selectable below, based on [this section in Push2 spec document](https://github.com/Ableton/push-interface/blob/master/doc/AbletonPush2MIDIDisplayInterface.asc#LED%20Animation).

  - LED.Animation.None (stop transition)
  - LED.Animation.1shot24th
  - LED.Animation.1shot16th
  - LED.Animation.1shot8th
  - LED.Animation.1shotQuarter
  - LED.Animation.1shotHalf
  - LED.Animation.Pulsing24th
  - LED.Animation.Pulsing12th
  - LED.Animation.Pulsing8th
  - LED.Animation.PulsingQuarter
  - LED.Animation.PulsingHalf
  - LED.Animation.Blinking24th
  - LED.Animation.Blinking16th
  - LED.Animation.Blinking8th
  - LED.Animation.BlinkingQuarter
  - LED.Animation.Blinking24Half
