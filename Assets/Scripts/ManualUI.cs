using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualUI : MonoBehaviour
{
    [SerializeField]
    private GameObject ManualPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        ManualPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ManualPanel.SetActive(false);
        }
    }
}
