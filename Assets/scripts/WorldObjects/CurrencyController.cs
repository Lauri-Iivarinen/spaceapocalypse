using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public static int currency = 0;
    // Start is called before the first frame update

    private Player pl;

    private void Start()
    {
        pl = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D objectName)
    {
        if (objectName.gameObject.name.Equals("Player"))
        {
            currency++;
            Destroy(gameObject);
            pl.PlayPickupSound();
            Debug.Log(currency);
        }
    }
}
