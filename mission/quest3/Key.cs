using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Effect3;
    public GameObject MissionTheree,MissionThereeSucceed;
    public GameObject Palyer;

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
            Instantiate(Effect3,transform.position,Quaternion.identity);
           
            MissionTheree.SetActive(false);
            MissionThereeSucceed.SetActive(true);
            Pickups pickups = Palyer.GetComponent<Pickups>();
            pickups.AddScore(10);
           Renderer renderer = this.GetComponent<Renderer>();
            renderer.enabled = false;
            Collider collider = this.GetComponent<Collider>();
            collider.enabled = false;
            StartCoroutine(DestroyPanel());


        }
    }
    IEnumerator DestroyPanel()
    {
        yield return new WaitForSeconds(3f);
        MissionThereeSucceed.SetActive(false);
        Destroy(this.gameObject);
    }
}
