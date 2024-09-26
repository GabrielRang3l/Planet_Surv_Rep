using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class TrumpStats : MonoBehaviour
{

    public PlayerScriptableObject playerData;


    //current stats
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentRecovery;
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentMight;
    [HideInInspector]
    public float currentProjectileSpeed;
    [HideInInspector]
    public float currentMagnet;

    TrumpAnimation ta;


    AudioSource au;
    [SerializeField]
    AudioClip clips;



    public ParticleSystem damageEffect;

    [Header("UI")]
    public Image healthBar;
    public Image expBar;
    public Text levelText;


    //exp do jogador
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experineceCapIncrese;

    }


    //iframe do trump
    [Header("Iframe")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;


    TrumpInventoryManager inventory;
    public int weaponIndex;
    public int passiveItemIndex;



    //toma conta do nivel
    public List<LevelRange> levelRanges;


    void Awake()
    {
        inventory = GetComponent<TrumpInventoryManager>();

        currentHealth = playerData.MaxHealth;
        currentRecovery = playerData.Recovery;
        currentMoveSpeed = playerData.MoveSpeed;
        currentMight = playerData.Might;
        currentProjectileSpeed = playerData.ProjectileSpeed;
        currentMagnet = playerData.Magnet;
}


    void Start()
    {
        //inicializa o experienceCap como o primeiro capIncrease
        experienceCap = levelRanges[0].experineceCapIncrese;
        ta = GetComponent<TrumpAnimation>();
        UpdateHealthBar();
        UpdateExpBar();
        UpdateLevelText();
    }


    void Update()
    {
        if (invincibilityTimer > 0) 
        {
            invincibilityTimer -= Time.deltaTime;
        }
        //se o timer de invencivel chegar a 0, deixa o invencivel como false
        else if (isInvincible)
        {
            isInvincible = false;
        }

        Recovery();

    }



    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();

        UpdateExpBar();
    }


    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experineceCapIncrese;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;

            UpdateLevelText();

        }
    }


    void UpdateExpBar()
    {
        expBar.fillAmount = (float)experience / experienceCap;
    }


    void UpdateLevelText()
    {
        levelText.text = "LV " + level.ToString();
    }





    public void TakeDamage(float dmg)
    {
        au = GetComponent<AudioSource>();

        au.clip = clips;
        au.Play();

        //se o jogador nao está em iframe, reduz a vida e inicia o iframe
        if (!isInvincible)
        {
            currentHealth -= dmg;

            

            if (damageEffect) Instantiate(damageEffect, transform.position, Quaternion.identity); //GERA PARTICULAS QUANDO ATINGIDO

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 1)
            {
                ta.DeathAnimation();
                Kill();
            }

            UpdateHealthBar();

        }
        
    }


    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / playerData.MaxHealth;
    }



    public void Kill()
    {
        
        Debug.Log("morreu");
    }


    public void RestoreHealth(float amount)
    {
        //só cura se estiver abaixo da vida maxima 
        if(currentHealth < playerData.MaxHealth)
        {
            currentHealth += amount;
        }
            
            //garante que a vida do jogador nao passe da vida maxima 
            if(currentHealth > playerData.MaxHealth)
            {
            currentHealth = playerData.MaxHealth;
            }
        
    }

    void Recovery()
    {
        if(currentHealth < playerData.MaxHealth)
        {
            currentHealth += currentRecovery * Time.deltaTime;

            //garante que a vida nao ultrapasse o limite
            if (currentHealth > playerData.MaxHealth)
            {
                currentHealth = playerData.MaxHealth;
            }

        }
        
    }



}
