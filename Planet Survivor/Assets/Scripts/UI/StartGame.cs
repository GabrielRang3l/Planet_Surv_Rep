using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [Header("Insira o componente botão que inicia o jogo")]
    [SerializeField] Button StartGameButton;

    void Start()
    {
        Button bStartGame = StartGameButton.GetComponent<Button>();

        //Chama a cena Play Game
        bStartGame.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        //Carrega a cena do jogo
        SceneManager.LoadScene("GameScene");
    }
}
