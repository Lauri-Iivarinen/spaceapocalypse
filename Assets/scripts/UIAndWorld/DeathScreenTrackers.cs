using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathScreenTrackers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Counter").GetComponent<TextMeshProUGUI>().text = "" + PlayerStats.killCount;
        GameObject.Find("CCounter").GetComponent<TextMeshProUGUI>().text = "" + CurrencyController.currency;
    }
}
