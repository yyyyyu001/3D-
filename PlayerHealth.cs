using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth, maxHealth, damageAmount;
    public HealthBar healthBar;
    public GameObject damageEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetmaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DealDamage()
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
       Instantiate(damageEffect, transform.position, Quaternion.identity);//实例化方法就是在场景中创建某个游戏对象//Quaternion.identity保持原始旋转
        
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
        }
    }
}
