using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadorInimigos : MonoBehaviour {


    public GameObject Objetoquecai;
    public GameObject Objetoquecai2;
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
            if (sorteio > 8)
            {
                //PONTO
                float posX = Random.Range(-2.5f, 2.5f);
                Vector3 posOrigem = new Vector3(posX, 6, 0);
                GameObject Item = Instantiate(Objetoquecai, posOrigem, Quaternion.identity);
                Destroy(Item, 3f);
                contador = 0;
            }
            else
            {
                //Inimigo
                float posX = Random.Range(-2.5f, 2.5f);
                Vector3 posOrigem = new Vector3(posX, 6, 0);
                GameObject Item = Instantiate(Objetoquecai2, posOrigem, Quaternion.identity);
                Destroy(Item, 3f);
                contador = 0;
            }


        }
    }

}
