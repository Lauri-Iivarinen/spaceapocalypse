using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaypointController : MonoBehaviour
{
    Player pl;
    float screenWidth = 36f;
    float screenHeight = 22f;
    public GameObject beamOrigin;
    public GameObject talentPrefab;

    TalentPickup pickup;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("Player").GetComponent<Player>();
        pickup = talentPrefab.GetComponent<TalentPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool OutsideOfView(float x, float y){
        if (pl.GetX() >= x && pl.GetX()-screenWidth/2 > x) return true;
        else if (pl.GetX()+screenWidth/2 < x) return true;
        else if (pl.GetY() >= y && pl.GetY()-screenHeight/2 > y) return true;
        else if (pl.GetY()+screenHeight/2 < y) return true;
        return false;
    }

    void FixedUpdate(){
        if (!pickup.PickedUp() && OutsideOfView(pickup.GetX(), pickup.GetY())){
            beamOrigin.SetActive(true);
            float angle = AngleBetweenTwoPoints(new Vector3(pl.GetX(), pl.GetY(), 0), new Vector3(pickup.GetX(), pickup.GetY(), 0));
            beamOrigin.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        }else {
            beamOrigin.SetActive(false);
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
