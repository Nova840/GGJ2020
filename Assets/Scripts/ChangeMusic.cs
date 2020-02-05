using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {

    public void IncrementBy(int i) {
        Music.GameMusicStage += i;
    }

}