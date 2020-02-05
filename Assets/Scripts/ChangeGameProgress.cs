using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameProgress : MonoBehaviour {

    public void IncreaseMusicBy(int amount) {
        Music.GameMusicStage += amount;
    }

    public void IncreaseBackgroundBy(int amount) {
        SpriteChanger.Background.SetSprite(SpriteChanger.Background.CurrentSpriteIndex + amount);
    }

}