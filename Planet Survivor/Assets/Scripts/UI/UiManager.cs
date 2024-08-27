using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class UiManager : MonoBehaviour
{
    [Header("Pede o componente Canvas")]
    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas popUpCanvas;

    [Header("Pede o componente Button")]
    [SerializeField] Button btnConfig;
    [SerializeField] Button btnExit;

    [Header("Pede o componente dos sons")]
    [SerializeField] Slider sliderVolume;
    [SerializeField] Toggle toggleSoundFx;

    Button bConfig;
    Button bConfirm;


    void Start()
    {
        //Esconde o Submenu ao iniciar
        popUpCanvas.enabled = false;

        //Componente do botão PopUpCanvas
        bConfig = btnConfig.GetComponent<Button>();
        bConfirm = btnExit.GetComponent<Button>();


        //Mostra PopUpCanvas ao apertar o botão
        bConfig.onClick.AddListener(ShowPopUpCanvas);

        //Esconde PopUpCanvas ao apertar o botão
        bConfirm.onClick.AddListener(HidePopUpCanvas);
    }

    private void HidePopUpCanvas()
    {
        //Despausa o jogo e tira o PopUp
        Time.timeScale = 1;
        popUpCanvas.enabled = false;
        bConfig.interactable = true;
    }

    private void ShowPopUpCanvas()
    {
        //Pausa o Jogo e sobe o PopUp
        Time.timeScale = 0;

        popUpCanvas.enabled = true;
        bConfig.interactable = false;
    }

    private void Update()
    {
        //Valores enviados para o script de musica (AudioManager)
        GameObject.Find("AudioManager").GetComponent<AudioManager>().volume = sliderVolume.value;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().UpdateAudio();

        //valores enviados para o script de SFX
        GameObject.Find("SFXManager").GetComponent<SFXManager>().PlaySFX = toggleSoundFx.isOn;
    }




}
