using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{

    //Para Pegar informações Salvas
    private Salve Salvador;
    public Text TotaldeMoedas;
    // Start is called before the first frame update
    void Start()
    {
        Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
    }

    // Update is called once per frame
    void Update()
    {
        ExibirMoedas();
    }

    void ExibirMoedas(){
        TotaldeMoedas.text = Salvador.InformaMoeda().ToString();
    }
}
