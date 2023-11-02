using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private GameObject goalPanel;
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    ScoreManager scoreManager;

    private CharacterController player;

    private bool isClear = false;
    public bool IsClear => isClear;

    private void Awake()
    {
        isClear = false;
        goalPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Clear();
        }
    }

    private void Clear()
    {
        isClear = true;
        Time.timeScale = 0.0f;
        goalPanel.SetActive(true);
        scoreText.GetComponent<TextMeshProUGUI>().text = Mathf.Round(scoreManager.GetScore()).ToString();
    }
}
