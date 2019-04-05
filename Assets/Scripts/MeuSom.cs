using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeuSom : MonoBehaviour
{
    //Dano
    public AudioClip dano;
    //Ponto
    public AudioClip ponto;

    //moeda
    public AudioClip moeda;


    //EMISOR DE SOM
    private AudioSource fontedesom;
    
    
    // Start is called before the first frame update
    void Start()
    {
        fontedesom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TOCAR DANO
    public void SomDano(){
        fontedesom.clip = dano;
        fontedesom.Play();
    }

    //TOCAR PONTO
    public void SomPonto(){
        fontedesom.clip = ponto;
        fontedesom.Play();
    }

    //TOCAR MOEDA
    public void SomMoeda(){
        fontedesom.clip = moeda;
        fontedesom.Play();
    }


}
