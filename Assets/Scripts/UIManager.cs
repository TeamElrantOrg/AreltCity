using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider levelBar;
    public TextMeshProUGUI HPText;
    public PlayerHealthManager playerHealth;
    private PlayerStats thePS;
    public TextMeshProUGUI levelText;
    private static bool UIExists;
    // Start is called before the first frame update
    void Start()
    {

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        thePS = GetComponent<PlayerStats>();

    }

    // Update is called once per frame, non riempirlo di cose o lagga più di Yandere Simulator.
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "Lvl: " + thePS.currentLevel;
        levelBar.maxValue = thePS.toLevelUp[thePS.currentLevel];
        levelBar.value = thePS.currentExp;
    }
}
