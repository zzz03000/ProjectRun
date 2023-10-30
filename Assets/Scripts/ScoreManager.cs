using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;

    public bool isPlaying = false;

    private void Update()
    {
        if (isPlaying)
            score += Time.timeScale;
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
