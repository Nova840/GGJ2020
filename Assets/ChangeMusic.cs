using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {
    public void Increment(int i) {
        Music.GameMusicStage+=i;
        Destroy(gameObject);
    }
}