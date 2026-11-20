using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quenstwofinish : MonoBehaviour
{

   
    public GameObject carcamera, car, player, mission2Panel,Misson2Succeed,mission2enviorn;
    
    bool trigger = false;
    public GameObject magicTwo,magicTheree;
   
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
        if(other.gameObject.tag == "Player" && !trigger)
        {
            carcamera.SetActive(false);
            car.SetActive(false);
            player.SetActive(true);
            mission2Panel.SetActive(false);
            Misson2Succeed.SetActive(true);
            magicTwo.SetActive(false);
            mission2enviorn.SetActive(false);
           Pickups pickups = player.GetComponent<Pickups>();
            pickups.AddScore(10);


            StartCoroutine(QuestTwoSucceed());
        }
    }

    IEnumerator QuestTwoSucceed()
    {
        yield return new WaitForSeconds(3f);
        mission2Panel.SetActive(false);
        Misson2Succeed.SetActive(false);
        this.gameObject.SetActive(false);
        magicTheree.SetActive(true);
    }
}
