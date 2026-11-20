using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Pickups : MonoBehaviour
{
    public int scoreAmount;
    public int score;
    public Text scoreText;
    public TMP_Text  PickText;
    public int Startitems;
    private int Needaccount = 3;
    public GameObject questsucceed;
    public GameObject questone, magicura,questPanel;
    public GameObject startEffect;
    public GameObject magicura2;
    bool questcompleted = false;
    private float requireQuestScore = 10f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "分数 ： 0 ";
        PickText.text = "星星 : 0 ";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            AudioManager.instance.PlaySfx(0);
            score += scoreAmount;
            Destroy(other.gameObject);
            UpdateText();
        }
        else if(other.gameObject.tag == "Star")
        {
            AudioManager.instance.PlaySfx(0);
            Startitems++;
            Instantiate(startEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            UpdateText();
            if (Startitems >= Needaccount && !questcompleted)
            {
                questsucceed.SetActive(true);
                questone.SetActive(false);
                magicura.SetActive(false);
                questPanel.SetActive(false);
                magicura2.SetActive(true);
                score += (int)requireQuestScore;
                UpdateText();
                StartCoroutine(HidequestPanel());
                
            }
        }
    }
    IEnumerator HidequestPanel()
    {
        yield return new WaitForSeconds(3f);
        questsucceed.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateText();
    }
    public void UpdateText()
    {
        scoreText.text = "分数 ：" + score ;
        PickText.text = "星星 : " + Startitems.ToString();
    }





}
