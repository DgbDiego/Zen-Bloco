using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public Text atualText;
    public Text ultimaText;
    public Text recordeText;
    public int pontosAtual;
    public int pontosUltima;
    public int pontosRecorde;
    public GameObject bolinha;
    public criaBlocos cb;  

    public int cubosRestantes = 1;


    // Start is called before the first frame update
    void Start()
    {
        // zera o contador atual e exibe
        pontosAtual = 0;
        atualText.text = pontosAtual.ToString();    

        // exibe ultima pontuacao
        pontosUltima = PlayerPrefs.GetInt("PontosSalvos");

        // exibe recorde
        pontosRecorde = PlayerPrefs.GetInt("pontosRecorde");              

    }

    // Update is called once per frame
    void LateUpdate()
    {    
        
        if (cubosRestantes < 1){

            cb.reativaBlocos();
            cubosRestantes = cb.cubos.Count;            

        }
        
    }
    public void atualizaPontos(){

        // adiciona ponto atual e exibe
        pontosAtual++;
        atualText.text = pontosAtual.ToString();

        // caso ponto atual seja recorde...
        if (pontosAtual > pontosRecorde){

            // guarda ponto atual como recorde e exibe
            pontosRecorde = pontosAtual;
            PlayerPrefs.SetInt("pontosRecorde", pontosRecorde);
            recordeText.text = pontosRecorde.ToString();

        }
        
    }

    public void resetaJogo(){
        
        // guarda o atual, zera e exibe
        PlayerPrefs.SetInt("PontosSalvos", pontosAtual);
        pontosAtual = 0;
        atualText.text = pontosAtual.ToString();
        
        // alimenta o ultimo ponto e exibe
        pontosUltima = PlayerPrefs.GetInt("PontosSalvos");
        ultimaText.text = pontosUltima.ToString();

        // exibe o recorde
        recordeText.text = pontosRecorde.ToString();  

        // religa todos os blocos
        cb.reativaBlocos();

        // reseta direcao e posicao da bolinha
        bolinha.GetComponent<bolinha>().impulsoInicial();
        bolinha.transform.position = Vector2.zero;        
        
    }
}
