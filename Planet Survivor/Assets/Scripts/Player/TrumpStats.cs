using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

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
        currentMagnet = playerData.Magnet;
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

        Recovery();

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
