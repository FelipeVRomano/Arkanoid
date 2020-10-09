using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    NORMAL_COLLISION,
    SPECIAL_COLLISION,
    PLAYER_COLLISION,
    GAME_OVER,
    POWER_UP,
    SHOOT
}

public class AudioController : MonoBehaviour
{
    public AudioSource normalCol;
    public AudioSource specialCol;
    public AudioSource playerCol;
    public AudioSource gameOver;
    public AudioSource powerUp;
    public AudioSource shoot;

    public void PlaySound(AudioType type)
    {
        switch (type)
        {
            case AudioType.NORMAL_COLLISION:
                normalCol.Play();
                break;

            case AudioType.SPECIAL_COLLISION:
                specialCol.Play();
                break;

            case AudioType.PLAYER_COLLISION:
                playerCol.Play();
                break;

            case AudioType.GAME_OVER:
                gameOver.Play();
                break;

            case AudioType.POWER_UP:
                powerUp.Play();
                break;
            case AudioType.SHOOT:
                shoot.Play();
                break;
        }
    }

}
