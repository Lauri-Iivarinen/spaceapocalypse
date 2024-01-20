using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UpgradeShop : MonoBehaviour
{
    public GameObject btnPrefab;
    private TextMeshProUGUI currency;
    private TextMeshProUGUI killTracker;
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        float x = -550f;
        float y = 200f;

        foreach (PermanentUpgrade upgr in PermanentStats.upgrades)
        {   
            Vector3 pos = new Vector3(x, y, 0f);
            GameObject btn = Instantiate(btnPrefab, pos, transform.rotation);
            btn.transform.SetParent(GameObject.Find("Canvas").transform, false);
            BuffButton buff = btn.GetComponent<BuffButton>();
            buff.upgrade = upgr;
            count++;
            x += 450f;
            if (count == 4)
            {
                y -= 200f;
                x = -550f;
                count = 0;
            }
        }

        this.currency = GameObject.Find("Currency").GetComponent<TextMeshProUGUI>();
        this.killTracker = GameObject.Find("KillTracker").GetComponent<TextMeshProUGUI>();
        killTracker.text = "" + PermanentStats.killCount;
    }

    public void RefundAll()
    {
        PermanentStats.refundUpgrades();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currency.text = "Currency: " + PermanentStats.currency;
    }
}
