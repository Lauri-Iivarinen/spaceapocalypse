using UnityEngine;

public class MobObjects: MonoBehaviour{
    public static GameObject healthPickup;
    public static GameObject dmgTxt;

    [SerializeField]
    public GameObject _healthPickup;
    [SerializeField]
    public GameObject _dmgTxt;

    void Start(){
        healthPickup = _healthPickup;
        dmgTxt = _dmgTxt;
    }
}