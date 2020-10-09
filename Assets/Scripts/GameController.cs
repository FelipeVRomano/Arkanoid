using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int numberOfBlocks;
    public GameObject[] powerUps;
    private int currentPowerUp;
    private bool canReleasePowerUp;
    public TextMeshProUGUI scoreHUD;
    private int score;
    private int currentPowerUP;
    //komaeda
    [HideInInspector]
    public int numberOfBalls = 1;

    private AudioController audioController;

    public void Start()
    {
        audioController = GameObject.FindWithTag("MainCamera").GetComponent<AudioController>();

        currentPowerUp = 0;
        canReleasePowerUp = true;
        score = 0;
        scoreHUD.text = score.ToString();
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RemoveBlock(Vector3 pos)
    {
        score += 10;
        scoreHUD.text = score.ToString();
        numberOfBlocks--;
        if (numberOfBlocks <= 0)
        {
            ReloadGame();
        }

        if (canReleasePowerUp)
        {
            Instantiate(powerUps[currentPowerUp], pos, Quaternion.identity);
            StartCoroutine(PowerUpCoolDown());
           
            
        }
    }

    public void RemoveBall()
    {
        numberOfBalls--;
        if (numberOfBalls <= 0)
        {

            StartCoroutine(PlayerLost());
        }
    }

    public IEnumerator PlayerLost()
    {
        Time.timeScale = 0;
        audioController.PlaySound(AudioType.GAME_OVER);
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        ReloadGame();
    }


    public IEnumerator PowerUpCoolDown()
    {
        canReleasePowerUp = false;
        yield return new WaitForSeconds(10);
        currentPowerUp++;
        if (currentPowerUp >= powerUps.Length)
            currentPowerUp = 0;

        canReleasePowerUp = true;
    }
}
