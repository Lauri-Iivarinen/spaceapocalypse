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
    private Slider buffProgress;

    private RectTransform sliderBorder;
    public Transform stepMarkersParent;
    public GameObject verticalLinePrefab;
    public int numberOfSteps = 6;
    // Start is called before the first frame update
    void Start() 
    {
        buff = gameObject.transform.Find("BuffTitle").GetComponent<TextMeshProUGUI>();
        buffTooltip = gameObject.transform.Find("BuffTooltip").GetComponent<TextMeshProUGUI>();
        buyText = gameObject.transform.Find("BuyButton").GetComponentInChildren<TextMeshProUGUI>();
        refundText = gameObject.transform.Find("RefundButton").GetComponentInChildren<TextMeshProUGUI>();
        buffTooltip.text = upgrade.tooltip;
        buffProgress = gameObject.transform.Find("Slider").GetComponent<Slider>();
        sliderBorder = gameObject.transform.Find("SliderBorder").GetComponent<RectTransform>();
        CreateStepMarkers();
        buff.text = upgrade.name;
        refundText.text = "Refund";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        buffProgress.value = (float)upgrade.currUpgrades / upgrade.maxUpgrades;
        if (upgrade.currUpgrades == upgrade.maxUpgrades) {
            buyText.text = "MAX";
            gameObject.transform.Find("BuyButton").GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.transform.Find("BuyButton").GetComponent<Button>().interactable = true;
            buyText.text = "" + upgrade.upgradeCost;
        }

        if(upgrade.currUpgrades == 0)
        {
            gameObject.transform.Find("RefundButton").GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.transform.Find("RefundButton").GetComponent<Button>().interactable = true;
        }
    }

    public void BuyUpgrade()
    {
        upgrade.UpgradeStat();
    }

    public void RefundUpgrade()
    {
        upgrade.RefundStat();
    }


    private void CreateStepMarkers()
    {
        RectTransform border = buffProgress.GetComponent<RectTransform>();
        int lines = upgrade.maxUpgrades-1;
        float lineWidth = border.rect.width / upgrade.maxUpgrades;
        float currWidth = lineWidth;
        for (int i = 0; i < lines; i++)
        {
            GameObject marker = Instantiate(verticalLinePrefab, sliderBorder);
            Vector3 pos = marker.transform.position;
            pos.x += 38f + currWidth;
            currWidth += lineWidth;
            marker.transform.position = pos;
        }
    }

}
