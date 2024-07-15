using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SystemMain : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Score =0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text =$"Score:{Score}";
    }
}
