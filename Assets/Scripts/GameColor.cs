using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColor : MonoBehaviour {

    private int colorState = 0;

    public delegate void ChangeColor(int i);

    public static ChangeColor onChangeColor;

    private void SetColorState(int newColorState) {
        colorState = newColorState;
        onChangeColor.Invoke(colorState);
    }

}