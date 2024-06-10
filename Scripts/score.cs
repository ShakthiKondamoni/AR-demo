using System;
using UnityEngine;
using UnityEngine.Subsystems;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text example1;
    public int reference=0;
    public GameObject Target;

    void Start(){
        example1.text = "Score: " + reference;
    }
    

    void update(){

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name== "Target")
        {
            string copy=example1.text;
            reference=int.Parse(copy);
            reference++;
            example1.text= "Score: " + reference.ToString();
            
        }
    }
    
}
