using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float score;

    public bool isPlaying = false;

    private void Start()
    {
        isPlaying = true;

        Reset();
    }

    private void Update()
    {
        if (isPlaying)
            score += (Time.timeScale / 60);
    }

    public void Reset()
    {
        score = 0;
    }

    public float GetScore() 
    {
        return score;
    }
}
