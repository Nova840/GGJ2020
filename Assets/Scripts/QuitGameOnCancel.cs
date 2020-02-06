using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class QuitGameOnCancel : MonoBehaviour {

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Application.Quit();
#if UNITY_EDITOR
            Debug.Log("Can't quit game from editor.");
#endif
        }
    }

}