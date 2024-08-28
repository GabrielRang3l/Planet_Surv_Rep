using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;


    int currentLevel;
    int totalExperience;

    int previousLevelExperience;
    int nextLevelExperience;


    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image experienceFill;



    void Start()
    {
        UpdateLevel();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddExperience(5);
        }
    }


    void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelExperience)
        {

            currentLevel++;
            UpdateLevel();
            
            //adicionar vfx ou sons

        }
    }

    void UpdateLevel()
    {
        previousLevelExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
    }

    void UpdateInterface()
    {
        int start = totalExperience - previousLevelExperience;
        int end = nextLevelExperience - previousLevelExperience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + " exp / " + end + " exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }

}
