using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAttributes : MonoBehaviour
{
    public GameObject player;
    public GameObject attributes;
    public GameObject proteinValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hp = player.GetComponent<Attributes>().healthPoints;
        float proteins = player.GetComponent<Attributes>().proteins;
        //Text[] textFields = attributes.FindGameObjectsWithTag("coconut");
        //(Text[])attributes.GetComponents<Text>();

        //Debug.Log(attributes.GetComponents<Text>().Length);

        /*for(int i = 0;i < textFields.Length;i++)
        {

            if(i == 0) {Debug.Log("reached loop");}
            Text t = textFields[i];

            if(t.name == "proteinValue")
            {
             t.text = proteins.ToString();
            }
        }*/
        proteinValue.GetComponent<Text>().text = proteins.ToString(); 
    }
}