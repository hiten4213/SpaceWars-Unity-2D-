using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIgameover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext;
    score score;
    private void Awake()
    {
        score = FindObjectOfType<score>();
    }
    void Start()
    {
        scoretext.text = score.getcurrentscore().ToString();
    }


}
