using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInformationManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text livesText;
    private int goldOverTime = 1;
    private float currentGold = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGold += goldOverTime * Time.deltaTime;
        goldText.text = $"Gold: {(int)currentGold}";
    }
}
