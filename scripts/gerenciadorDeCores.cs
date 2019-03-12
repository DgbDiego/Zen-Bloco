using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenciadorDeCores : MonoBehaviour
{
    public bool atualizaCor = false; 

    public Material mat01;
    public Material mat02;


    public string htmlPrincipal;
    public Color corPrincipal;
    public string htmlSecundaria;
    public Color corSecundaria;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (atualizaCor){

            if (htmlPrincipal!=null){
                ColorUtility.TryParseHtmlString (htmlPrincipal, out corPrincipal);
                mat01.color = corPrincipal;
                
            }

            if (htmlSecundaria!=null){
                ColorUtility.TryParseHtmlString (htmlSecundaria, out corSecundaria);
                
                mat02.color = corSecundaria;
                
            }           
            

            atualizaCor = false;

        }
        
    }


}
