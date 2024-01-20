using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BuffButton : MonoBehaviour
{
    public PermanentUpgrade upgrade;
    private TextMeshProUGUI buff;
    private TextMeshProUGUI buffTooltip;
    private TextMeshProUGUI buyText;
    private TextMeshProUGUI refundText;
    // Start is called before the first frame update
    void Start()
    {
        buff = gameObject.transform.Find("BuffTitle").GetComponent<TextMeshProUGUI>();
        buffTooltip = gameObject.transform.Find("BuffTooltip").GetComponent<TextMeshProUGUI>();
        buyText = gameObject.transform.Find("BuyButton").GetComponentInChildren<TextMeshProUGUI>();
        refundText = gameObject.transform.Find("RefundButton").GetComponentInChildren<TextMeshProUGUI>();
        buffTooltip.text = upgrade.tooltip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        buff.text = upgrade.name + " " + upgrade.currUpgrades + "/" + upgrade.maxUpgrades;
        buyText.text = "Buy " + upgrade.upgradeCost;
        refundText.text = "Refund";
    }

    public void BuyUpgrade()
    {
        upgrade.UpgradeStat();
    }

    public void RefundUpgrade()
    {
        upgrade.RefundStat();
    }
}
