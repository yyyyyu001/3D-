using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questtwo : MonoBehaviour
{
    public GameObject carcamera, car, player, mission2Panel,mission2enviorn;
    public GameObject carstoremagic;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.SetActive(false);
            carcamera.SetActive(true);
            car.SetActive(true);
            mission2Panel.SetActive(true);
            mission2enviorn.SetActive(true);
            carstoremagic.SetActive(true);
        }
    }

}
