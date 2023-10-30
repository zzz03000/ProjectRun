using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;

    [SerializeField] 
    private GameObject optionPanel;
    [SerializeField]
    ScoreManager scoreManager;
    [SerializeField]
    private GameObject scorePanel;
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    private GameObject currentScore;

    private bool setactive = false;

    private void Awake()
    {
        Time.timeScale = 1.0f;

        currentScore.SetActive(true);
        optionPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        currentScore.GetComponent<TextMeshProUGUI>().text = Mathf.Round(scoreManager.GetScore()).ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setactive = !setactive;
            Time.timeScale = setactive ? 0 : 1;
            optionPanel.SetActive(setactive);
        }

        if (player.IsDead)
            GameOver();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        optionPanel.SetActive(false);
    }

    public void GameOver() 
    {
        currentScore.SetActive(false);
        Time.timeScale = 0f;
        scorePanel.SetActive(true);
        scoreText.GetComponent<TextMeshProUGUI>().text = Mathf.Round(scoreManager.GetScore()).ToString();
    }
}
