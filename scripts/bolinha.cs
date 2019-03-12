using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolinha : MonoBehaviour
{
        public AudioSource saidaAudio;
        public AudioClip[] tomInpacto;
        public gameManager gm;
        public float _velocidadeInicial = -0.7f;

        public Vector2 _velocidadeAtual;
        public float _velocidadeMaxima = 100f;
        public float _velocidadeMinima = 1f;

        
        public Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {

        impulsoInicial();
        
    }

    public void impulsoInicial(){
        if (!_rb)
        _rb = GetComponent<Rigidbody2D>();         
        Vector2 direction = new Vector2 (Random.Range(-0.2f, 0.2f),_velocidadeInicial);
        _rb.AddForce (direction * 5f, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {

        movimentoFisica();


    }

    public void movimentoFisica(){

        _velocidadeAtual = _rb.velocity;    
    
        if ( Mathf.Abs(_velocidadeAtual.x) > _velocidadeMaxima){

            _velocidadeAtual.x = (_velocidadeMaxima - (_velocidadeMaxima / 10)) *  Mathf.Sign(_velocidadeAtual.x);
            _rb.velocity = _velocidadeAtual;

        } else if ( Mathf.Abs(_velocidadeAtual.x) < 0.8f){

            _velocidadeAtual.x = _velocidadeMinima *  Mathf.Sign(_velocidadeAtual.x);
            _rb.velocity = _velocidadeAtual;


        } else if ( Mathf.Abs(_velocidadeAtual.y) > _velocidadeMaxima){

            _velocidadeAtual.y = (_velocidadeMaxima - (_velocidadeMaxima / 10)) *  Mathf.Sign(_velocidadeAtual.x);
            _rb.velocity = _velocidadeAtual;

        } else if ( Mathf.Abs(_velocidadeAtual.y) < 0.8f){

            _velocidadeAtual.y = _velocidadeMinima *  Mathf.Sign(_velocidadeAtual.x);
            _rb.velocity = _velocidadeAtual;

        }


    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform){

            string tag = other.transform.tag;

            switch (tag){

                case "Bloco" :

                    saidaAudio.PlayOneShot(tomInpacto[2]);

                    int _vida = other.transform.GetComponent<bloco>()._vida;

                    if (_vida <= 1) {

                        other.transform.GetComponent<bloco>().atingido();
                        gm.cubosRestantes --;
                        gm.atualizaPontos();

                    }

                    break;

                case "Barra" :

                    saidaAudio.PlayOneShot(tomInpacto[0]);

                    break;

                case "Parede" :

                    saidaAudio.PlayOneShot(tomInpacto[1]);

                    break;
                
                case "FIM":

                    saidaAudio.PlayOneShot(tomInpacto[3]);                    
                    gm.resetaJogo();

                    break;

                default :

                    break;
            }

        }     

    }


}
