using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        takeDmg = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }
    void TakeDamage()
    {
        health -= 10;
    }
}
