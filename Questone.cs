using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questone : MonoBehaviour
{
    public GameObject questCamera, questPanel, Palyer, questEnvorinment;
    bool questStarted = false;


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
        if(other.gameObject.tag == "Player" && !questStarted)//当玩家触发到碰撞体并且任务还没开始时
        {
            questStarted = true;
            questCamera.SetActive(true);
            questPanel.SetActive(true);
            questEnvorinment.SetActive(true);
            Palyer.SetActive(false);

            Invoke("DisableAnimation", 10f);
        }
    }

    private void DisableAnimation()
    {
        questCamera.SetActive(false);
        Palyer.SetActive(true);
    }


}
