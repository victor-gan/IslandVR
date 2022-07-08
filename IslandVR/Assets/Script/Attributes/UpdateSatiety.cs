using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSatiety : MonoBehaviour
{
    public GameObject player;
    public GameObject attributes;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int hp = player.GetComponent<Attributes>().healthPoints;
        //attributes.hungerValue.text = hp.ToString();s
    }
}