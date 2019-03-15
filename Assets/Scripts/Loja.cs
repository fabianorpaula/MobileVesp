using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{

    //Para Pegar informações Salvas
    private Salve Salvador;
    public Text TotaldeMoedas;

    public Text CustoCoracao;
    private int minhaCarteira;

    // Start is called before the first frame update
    void Start()
    {
        Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
    }

    // Update is called once per frame
    void Update()
    {
        ExibirMoedas();
        AtualizarCusto();
    }

    void AtualizarCusto(){
        int custo = Salvador.InformarVida() * 5;
        CustoCoracao.text = "VIDAS: "+Salvador.InformarVida().ToString()+"\n $"+custo.ToString();
    }
    void ExibirMoedas(){
        TotaldeMoedas.text = Salvador.InformaMoeda().ToString();
    }

    public void Botao1(){
        //Informa quantidad de vidas atuais
        int vidasatuais = Salvador.InformarVida();
        //informa o valor para comprar nova vida
        int valorvida = 5 * vidasatuais;
        //Chama função de compra e informa botão
        Comprar(valorvida, 1);

    }

    public void Botao2(){
        //SO PODE COMPRAR SE ESTIVER NO NIVEL 1
        if(Salvador.InformarNivel() == 1){
            Comprar(50, 2);
        }
        
    }

    void Comprar(int valor, int numero_botao){
        //Verifica Quantas moedas eu tenho
        minhaCarteira = Salvador.InformaMoeda();
        //Verifica se eu tenho dinheiro para comprar
        if(valor <= minhaCarteira){
            minhaCarteira = minhaCarteira - valor;
            Salvador.NovoMoeda(minhaCarteira);
            Comprado(numero_botao);
        }
    }

    void Comprado(int numerodacompra){
        switch(numerodacompra){
            case 1:
                Salvador.AumentaVida();
                break;
            case 2:
                Salvador.AumentaNivel();
                break;
            default:
                //Não deve acontecer jamais
                break;
        }
    }
}
