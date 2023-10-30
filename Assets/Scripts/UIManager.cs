using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject quitButton;       //�޴��� ������ ��ư
    public GameObject resumeButton;      // �簳 ��ư
    public GameObject gameOverSpr;          // GAME OVER �̹���
    public GameObject gameClearSpr;         // GAME CLEAR �̹���
    public string sceneName;

    bool setactive = false;

    // Start is called before the first frame update
    private void Awake()
    {
        resumeButton.SetActive(false);
        quitButton.SetActive(false);  //��ư �����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setactive = true;

            if (setactive == true)
            {
                Time.timeScale = 0.0f;
                resumeButton.SetActive(true);
                quitButton.SetActive(true);  //��ư �����
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        resumeButton.SetActive(false);
        quitButton.SetActive(false);  //��ư �����
    }

    public void Load()
    {
        SceneManager.LoadScene("Start");
    }

}
