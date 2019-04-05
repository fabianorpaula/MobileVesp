using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    public Sprite Bota2;
    public int vida = 10;
    public int pontos = 0;
    public int moedas = 0;

    public float velocidade = 0.05f;
    

    //CHAMAR MEU SOM
    private MeuSom SomJogador;

    void Start()
    {
      SomJogador = GameObject.FindGameObjectWithTag("SONS").GetComponent<MeuSom>();       
    }


    public void AtualizarSprite(){
        GetComponent<SpriteRenderer>().sprite = Bota2;
        velocidade = 0.07f;
    }
    void Update()
    {
        //SeguirDedo();
    }


    public void MoverE()
    {
        //Define posição
        Vector3 destino = new Vector3(transform.position.x - velocidade, transform.position.y, transform.position.z);
        //Executa Movimento
       transform.position = destino;
    }
    public void MoverD()
    {
        //Define posição
        Vector3 destino = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);
        //Executa Movimento
        transform.position = destino;
    }

    void SeguirDedo()
    {
        if (Input.GetMouseButton(0))
        {
            //captura a posição do mouse
            Vector3 destino = Input.mousePosition;
            //Corrigi a posição do mouse
            Vector3 destinoCorrigido = Camera.main.ScreenToWorldPoint(destino);
            //posição com apenas eixo X e Y
            Vector3 destinoFinal = new Vector3(destinoCorrigido.x, destinoCorrigido.y, transform.position.z);
            //Vector3 destinoFinal = new Vector3(destinoCorrigido.x, transform.position.y, transform.position.z);
            //fazer jogador seguir
            transform.position = Vector3.MoveTowards(transform.position, destinoFinal, velocidade);
        }
        

    }

    ///ONDE OCORRE AS COLISISÕES
    void OnCollisionEnter2D(Collision2D col)
    {
        //TOCOU NA COMIDA
        if(col.gameObject.tag == "comida")
        {
            pontos++;
            SomJogador.SomPonto();
            Destroy(col.gameObject);
        }
        //TOCOU NO VENENO
        if (col.gameObject.tag == "veneno")
        {
            vida--;
            SomJogador.SomDano();
            Destroy(col.gameObject);
        }
        //TOCOU NA MOEDA
        if (col.gameObject.tag == "moeda")
        {
            moedas++;
            SomJogador.SomMoeda();
            Destroy(col.gameObject);
        }
    }

}
