using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salve : MonoBehaviour
{

    private int maiorpontuacao = 0;
    private int moedas = 0;

    private int nivel = 0;
    //Minhas Vidas
    private int vidas_max = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Usado para zerar
        ///PlayerPrefs.DeleteAll();

        //RECORDE
        if(PlayerPrefs.HasKey("recorde") == true)
        {
            maiorpontuacao = PlayerPrefs.GetInt("recorde");
        }else
        {
            PlayerPrefs.SetInt("recorde", 0);
        }
        //MOEDAS
        if(PlayerPrefs.HasKey("moeda") == true)
        {
            maiorpontuacao = PlayerPrefs.GetInt("moeda");
        }else
        {
            PlayerPrefs.SetInt("moeda", 0);
        }
        //VIDAS MAXIMO
        if(PlayerPrefs.HasKey("vidas_max") == true)
        {
            vidas_max = PlayerPrefs.GetInt("vidas_max");
        }else
        {
            PlayerPrefs.SetInt("vidas_max", 1);
        }
        //NIVEL ATUAL
        if(PlayerPrefs.HasKey("nivel") == true)
        {
            nivel = PlayerPrefs.GetInt("nivel");
        }else
        {
            PlayerPrefs.SetInt("nivel", 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Verifica se houve alteração PONTOS
    public bool NovoRecorde(int valor)
    {
        maiorpontuacao = PlayerPrefs.GetInt("recorde");
        if(maiorpontuacao >= valor)
        {
            return false;
        }else
        {
            PlayerPrefs.SetInt("recorde", valor);
            return true;
        }
        
    }
    //informa o recorde atual PONTOS
    public int InformaRecorde()
    {
        maiorpontuacao = PlayerPrefs.GetInt("recorde");
        return maiorpontuacao;
    }

//Recebe o valos atual de moedas
    public void NovoMoeda(int valor)
    {
        //moedas = PlayerPrefs.GetInt("moeda");
        PlayerPrefs.SetInt("moeda", valor);
        
    }
    //informa o valor atual de moedas
    public int InformaMoeda()
    {
        moedas = PlayerPrefs.GetInt("moeda");
        return moedas;
    }

///VIDAS
    public int InformarVida(){
        vidas_max = PlayerPrefs.GetInt("vidas_max");
        return vidas_max;
    }

    public void AumentaVida(){
        vidas_max = PlayerPrefs.GetInt("vidas_max");
        vidas_max++;
        PlayerPrefs.SetInt("vidas_max", vidas_max);
    }
///NIvel
    public int InformarNivel(){
        nivel = PlayerPrefs.GetInt("nivel");
        return nivel;
    }

    public void AumentaNivel(){
        nivel = PlayerPrefs.GetInt("nivel");
        nivel++;
        PlayerPrefs.SetInt("nivel", nivel);
        Debug.Log("nivel autal"+nivel);
    }
}
