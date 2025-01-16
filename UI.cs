using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] Slider healthslider;
    [SerializeField] health playerhealth;
    [SerializeField] TextMeshProUGUI scoretext;
    score score;

    private void Awake() 
    {
        score= FindObjectOfType<score>();
    }
    
    void Start()
    {
        healthslider.maxValue = playerhealth.gethealth();
        
    }

    
    void Update()
    {
       healthslider.value = playerhealth.gethealth();
       scoretext.text = score.getcurrentscore().ToString();
    }
}
