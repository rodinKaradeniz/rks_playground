using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float maxHealth;
    private bool isPaused;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1; // Default time
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;

        // Pausing
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                PauseGame();
            } else {
                ResumeGame();
            }
        }
    }
    public void TakeDamage()
    {
        health -= 10;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // Stopping time
        isPaused = true;
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
