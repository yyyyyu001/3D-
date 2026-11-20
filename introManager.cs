using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introManager : MonoBehaviour
{
    public GameObject introcamera, introPanel, Player;




    // Start is called before the first frame update
    void Start()
    {
        introcamera.SetActive(true);
        introPanel.SetActive(true);
        Player.SetActive(false);
        Invoke("Disableintro", 10f);
    }
    public void Disableintro()
    {

        introcamera.SetActive(false);
        introPanel.SetActive(false);
        Player.SetActive(true);
    }

}
