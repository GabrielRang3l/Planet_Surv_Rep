using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class TrumpStats : MonoBehaviour
{

    public PlayerScriptableObject playerData;


    //current stats
    float currentHealth;
    float currentRecovery;
    float currentMoveSpeed;
    float currentMight;
    float currentProjectileSpeed;


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




    //toma conta do nivel
    public List<LevelRange> levelRanges;


    void Awake()
    {
        currentHealth = playerData.MaxHealth;
        currentRecovery = playerData.Recovery;
        currentMoveSpeed = playerData.MoveSpeed;
        currentMight = playerData.Might;
        currentProjectileSpeed = playerData.ProjectileSpeed;
    }


    void Start()
    {
        //inicializa o experienceCap como o primeiro capIncrease
        experienceCap = levelRanges[0].experineceCapIncrese;

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

    }



    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();
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
        }
    }


    public void TakeDamage(float dmg)
    {
        //se o jogador nao está em iframe, reduz a vida e inicia o iframe
        if(!isInvincible)
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
        
    }

    public void Kill()
    {
        Debug.Log("morreu");
    }

}
