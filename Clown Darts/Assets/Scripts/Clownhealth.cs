using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clownhealth : MonoBehaviour {

    public int myHealth = 100;
    public AudioSource clownHurt;
    public AudioSource clownKill;

    //called from the ontriggerenter event in darttip
    public void DartHit(int dartDamage)
    {
        myHealth -= dartDamage;
        if(myHealth > 0)
        {
            ClownHitBark();
        }
        else if(myHealth <= 0)
        {
            //ClownKill();
            ClownKillBark();
        }
    }

    public void ClownHitBark()
    {
        clownHurt.Play();
    }
    public void ClownKillBark()
    {
        clownKill.Play();
    }
}
