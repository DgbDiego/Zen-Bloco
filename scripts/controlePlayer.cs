using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlePlayer : MonoBehaviour
{

    public Rigidbody2D _rb;
    public Vector2 mousePos;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1")){

            //cam.ScreenToWorldPoint(mousePos);
            
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        _rb.MovePosition (new Vector2(mousePos.x, -4.6f));



        
    }
}
