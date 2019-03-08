using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadorInimigos : MonoBehaviour {


    public GameObject ObjetoPonto;
    public GameObject ObjetoVeneno;
    public GameObject ObjetoMoeda;
    private int contador = 0;

    //Referencia ao Script que controla o jogo
    //Chama a CLASSE
    private ControladorJogo GameC;

	// Use this for initialization
	void Start () {
        //CHAMA O OBJETO EXISTENTE NO JOGO
        GameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControladorJogo>();
	}
	
	// Update is called once per frame
	void Update () {

        if(GameC.EstadoJogo() == true)
        {
            Criador();
        }
        


    }

    void Criador()
    {
        contador++;
        if (contador > 50)
        {
            int sorteio = Random.Range(0, 10);
            Debug.Log(sorteio);
            if (sorteio >0 && sorteio<3)
            {
                //PONTO
                float posX = Random.Range(-2.5f, 2.5f);
                Vector3 posOrigem = new Vector3(posX, 6, 0);
                GameObject Item = Instantiate(ObjetoPonto, posOrigem, Quaternion.identity);
                Destroy(Item, 3f);
                contador = 0;
            }
            else if(sorteio > 2)
            {
                //Inimigo
                float posX = Random.Range(-2.5f, 2.5f);
                Vector3 posOrigem = new Vector3(posX, 6, 0);
                GameObject Item = Instantiate(ObjetoVeneno, posOrigem, Quaternion.identity);
                Destroy(Item, 3f);
                contador = 0;
            }else if(sorteio == 0){
                //Moeda
                CriarMoeda();
            }


        }
    }

    void CriarPonto(){

    }
    void CriarVeneno(){

    }

    void CriarMoeda(){
        float posX = Random.Range(-2.5f, 2.5f);
                Vector3 posOrigem = new Vector3(posX, 6, 0);
                GameObject Item = Instantiate(ObjetoMoeda, posOrigem, Quaternion.identity);
                Destroy(Item, 3f);
                contador = 0;
    }
}
