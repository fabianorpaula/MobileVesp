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
    public Text MoedasAtuais;
    public Text TotaldeMoedas;


    //TELAS PARA UI DO JOGO
    //exibe ponto
    public Text ponto;
    //exibe vida
    public Text vida;
    //exibe moedas
    public Text moeda;
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
        if(gameON == true){

       
        ponto.text = "Pontos: "+Usuario.GetComponent<Jogador>().pontos.ToString();
        vida.text = "Vida: "+Usuario.GetComponent<Jogador>().vida.ToString();
        moeda.text = Usuario.GetComponent<Jogador>().moedas.ToString();
        Morreu();
         }
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
        ParametrosIniciais();
    }

    //Colocar os dados elativos ao inicio do jogo;
    private void ParametrosIniciais(){
        Usuario.GetComponent<Jogador>().pontos = 0;
        Usuario.GetComponent<Jogador>().vida = Salvador.InformarVida();
        Usuario.GetComponent<Jogador>().moedas = 0;
        Debug.Log("NIEVEL"+Salvador.InformarNivel());
        if(Salvador.InformarNivel() > 1){
            Usuario.GetComponent<Jogador>().AtualizarSprite();
        }
        GAMEOVER.SetActive(false);
    }

    //Chama a função de morte
    void Morreu()
    {
        //VERIFICA SE O JOGADOR MORREU
        if(Usuario.GetComponent<Jogador>().vida <=0)
        {
            //PAUSE O JOGO
            gameON = false;
            GetComponent<MinhaPropaganda>().ShowAd();
            Time.timeScale = 0;
            GAMEOVER.SetActive(true);
            
            //Chama Recorde
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

            //InformaModeas
            //Moedas Atuais
            MoedasAtuais.text = Usuario.GetComponent<Jogador>().moedas.ToString();


            //Pego do meu save as moedas guardadas
            int moedasatuais = Salvador.InformaMoeda();
            //Somo com as moedas da partida
            moedasatuais = moedasatuais + Usuario.GetComponent<Jogador>().moedas;
            ///Informo ao meu save meu total de moedas
            Salvador.NovoMoeda(moedasatuais);
            //Exibo o meu total de moedas
            TotaldeMoedas.text = Salvador.InformaMoeda().ToString();
        }
    }

    //DAR RECOMPENSA AO JOGADOR
    public void RecompensarJogador(){

        int vezes2 = Usuario.GetComponent<Jogador>().moedas *2;
        if(vezes2 == 0){
            vezes2 =1;
        }
        MoedasAtuais.text = vezes2.ToString();


        int moedasatuais = Salvador.InformaMoeda();
        if(Usuario.GetComponent<Jogador>().moedas == 0){
                moedasatuais = 1;
            }
        //Somo com as moedas da partida
         moedasatuais = moedasatuais + Usuario.GetComponent<Jogador>().moedas;
            
            ///Informo ao meu save meu total de moedas
            Salvador.NovoMoeda(moedasatuais);
            //Exibo o meu total de moedas
            TotaldeMoedas.text = Salvador.InformaMoeda().ToString();
    }


    public void Reiniciar()
    {
        
        gameON = true;
        Time.timeScale = 1;
        ParametrosIniciais();
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
