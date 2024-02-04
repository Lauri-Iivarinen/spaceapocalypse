using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class UpgradeShop : MonoBehaviour
{
    public GameObject btnPrefab;
    private TextMeshProUGUI currency;
    private TextMeshProUGUI killTracker;
        [SerializeField]
    private AudioSource btnClick;
    // Start is called before the first frame update
    void Start()
    {

        foreach (PermanentUpgrade upgr in PermanentStats.upgrades)
        {   
            GameObject btn = Instantiate(btnPrefab);
            btn.transform.SetParent(GameObject.Find("BuffPanel").transform, false);
            BuffButton buff = btn.GetComponent<BuffButton>();
            buff.upgrade = upgr;
        }

        this.currency = GameObject.Find("Currency").GetComponent<TextMeshProUGUI>();
        this.killTracker = GameObject.Find("KillTracker").GetComponent<TextMeshProUGUI>();
        killTracker.text = "Lifetime kills: " + PermanentStats.killCount;
    }

    public void RefundAll()
    {
        PermanentStats.refundUpgrades();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currency.text = ": " + PermanentStats.currency;
    }

    public void ReturnToMenu()
    {
        int[] arr = { PermanentStats.currency, PermanentStats.killCount };
        DatabaseHandler.SaveStatTrackers(arr);
        DatabaseHandler.SaveStatsArray(PermanentStats.upgrades);
        btnClick.Play();
        StartCoroutine(NavigateToMenu());
    }

    IEnumerator NavigateToMenu(){
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainMenu");
    }
}
