using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorJogo : MonoBehaviour
{

    //SALVE DO JOGO
    private Salve Salvador;
    

    //PARA TELA DE RESET E GAMEOVER
    public GameObject GAMEOVER;
    public Text Recorde;
    public Text MaiorRecorde;
    public Text Parabens;


    //exibe ponto
    public Text ponto;
    //exibe vida
    public Text vida;
    //guarda viariavel usuario
    private GameObject Usuario;

    //variavel para detectar se o jogo esta ATIVO
    private bool gameON = false;


    // Start is called before the first frame update
    void Start()
    {
        //Busca o Jogador
        Usuario = GameObject.FindGameObjectWithTag("Player");
        //Busca o Salve do Jogo
        Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
        //Faz o jogo iniciar em tempo 1
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ponto.text = "Pontos: "+Usuario.GetComponent<Jogador>().pontos.ToString();
        vida.text = "Vida: "+Usuario.GetComponent<Jogador>().vida.ToString();
        Morreu();
    }

    //Retorna para outras funções o estado do Jogo
    public bool EstadoJogo()
    {
        return gameON;
    }
    //Permite o Botão iniciar o Jogo
    public void IniciarJogo()
    {
        gameON = true;
    }

    //Chama a função de morte
    void Morreu()
    {
        //VERIFICA SE O JOGADOR MORREU
        if(Usuario.GetComponent<Jogador>().vida <=0)
        {
            //PAUSE O JOGO
            gameON = false;
            Time.timeScale = 0;
            GAMEOVER.SetActive(true);
            Recorde.text = "Pontos: " + Usuario.GetComponent<Jogador>().pontos.ToString();
            //Verificando se têm recorde novo
            if (Salvador.NovoRecorde(Usuario.GetComponent<Jogador>().pontos) == true)
            {
                Debug.Log("PARABENS");
            }else
            {
                Debug.Log("Tente Outra Vez");
            }
            MaiorRecorde.text = "Recorde: " + Salvador.InformaRecorde().ToString();
        }
    }


    public void Reiniciar()
    {
        Usuario.GetComponent<Jogador>().pontos = 0;
        Usuario.GetComponent<Jogador>().vida = 5;
        GAMEOVER.SetActive(false);
        gameON = true;
        Time.timeScale = 1;
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
