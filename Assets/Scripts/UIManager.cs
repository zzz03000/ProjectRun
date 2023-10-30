using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject quitButton;       //메뉴로 나가기 버튼
    public GameObject resumeButton;      // 재개 버튼
    public GameObject gameOverSpr;          // GAME OVER 이미지
    public GameObject gameClearSpr;         // GAME CLEAR 이미지
    public string sceneName;

    bool setactive = false;

    // Start is called before the first frame update
    private void Awake()
    {
        resumeButton.SetActive(false);
        quitButton.SetActive(false);  //버튼 숨기기
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
                quitButton.SetActive(true);  //버튼 숨기기
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        resumeButton.SetActive(false);
        quitButton.SetActive(false);  //버튼 숨기기
    }

    public void Load()
    {
        SceneManager.LoadScene("Start");
    }

}
