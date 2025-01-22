using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gasUI;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public Player player;

    void Start()
    {
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        gasUI.SetActive(false);
        BackgroundScroll.isGameStarted = false;
    }

    void Update()
    {
        if(player!=null&&BackgroundScroll.isGameStarted){
            if (player.PlayerGas <= 1)
            {
                EndGame();
            }
        }
    }

    public void StartGame()
    {
        gameOverPanel.SetActive(false);
        gasUI.SetActive(true);
        gamePanel.SetActive(true);
        startPanel.SetActive(false);
        BackgroundScroll.isGameStarted = true;
    }

    public void EndGame()
    {
        gamePanel.SetActive(false);
        gasUI.SetActive(false);
        BackgroundScroll.isGameStarted = false;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        player.ResetPlayer();
        player.PlayerGas = 100f;
        BackgroundScroll.isGameStarted = false;
    }
}