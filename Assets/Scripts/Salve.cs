using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salve : MonoBehaviour
{

    private int maiorpontuacao = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("recorde") == true)
        {
            maiorpontuacao = PlayerPrefs.GetInt("recorde");
        }else
        {
            PlayerPrefs.SetInt("recorde", 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Verifica se houve alteração
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
    //informa o recorde atual
    public int InformaRecorde()
    {
        maiorpontuacao = PlayerPrefs.GetInt("recorde");
        return maiorpontuacao;
    }
}
