using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criaBlocos : MonoBehaviour
{

    public Vector2 tamanho;
    public Vector2 dist;
    public Vector2 posAtual;    
    public GameObject original;

    public gameManager gm;
    public List<GameObject> cubos;


    void Start()    
    {
        
        // Define a posição inicial e monta a grade de blocos
        posAtual = transform.position;

        for (int i = 0; i < tamanho.y; i ++){             

            for (int j = 0; j < tamanho.x; j ++){

                criarObjeto(original, posAtual);

                posAtual.x += dist.x;

            }

            posAtual.y += dist.y;
            posAtual.x = transform.position.x;

        }

        // Guarda a quantidade total dos blocos
        gm.cubosRestantes = cubos.Count;
        
    }

    public void criarObjeto(GameObject obj, Vector2 pos){ //Cria novo objeto na posição fornecida e salva obj na lista

        GameObject novoCubo = Instantiate (obj, pos, Quaternion.identity) as GameObject;
        cubos.Add(novoCubo);        

    }

    public void reativaBlocos(){ // Religa todos os obj da lista

        foreach (GameObject item in cubos){
            item.SetActive(true);
        }
        
    }


}
