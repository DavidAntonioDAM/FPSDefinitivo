using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField]//unity serializa estas variables para que podamos verlas en el inspector a pesar de ser privadas
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private Image healthBarImage;

    private void Start()
    {
        health = maxHealth;
    }

    //funcion a la que llamaran los enemigos y/o objetos curativos para dañar o curar
    public void addHealth(float amount)
    {
        health += amount;
        updateHealthUI();
    }

    public void makeDamage(float amount)
    {
        if (health > 0)
        {
            health -= amount;
            updateHealthUI();
        } else if (health == 0)
        {
            updateHealthUI();
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    private void updateHealthUI()
    {
        healthBarImage.fillAmount = (1 / maxHealth) * health;
    }
}