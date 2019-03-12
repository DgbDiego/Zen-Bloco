using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloco : MonoBehaviour
{

    public int _vida = 1;
    int _bkpVida = 0;
    // Start is called before the first frame update
    void Start()
    {

        _bkpVida = _vida;

        Debug.Log("Iniciado");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atingido(){
        _vida --;
        if (_vida < 1){

            _vida = _bkpVida;            
            gameObject.SetActive(false);
            
        }
        
    }
}
