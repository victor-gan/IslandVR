using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreeChop : MonoBehaviour
{
    public int healthPoints;
    private System.Random r = new System.Random();
    private bool coconutFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //called whenever collider hits tree
    private void OnTriggerEnter(Collider other)
    {
     if(r.Next(4) == 3) {coconutFlag = true;}
     healthPoints = Math.Max(healthPoints-100,0);
    }

    // Update is called once per frame
    void Update()
    {
     if(healthPoints == 0)
     {
      TreeFall();
     }
     if(coconutFlag)
     {
      CoconutDrop();
     }
    }

    private GameObject createCoconut()
    {
     Transform parent = GetComponent<Transform>();
     GameObject coconut = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere),parent);
     coconut.transform.SetPositionAndRotation(new Vector3((float)-1.3,(float)8,(float)-1.2), new Quaternion(0,0,0,0));
     return coconut;
    }
    
    //drops the coconut (surprise!)
    private void CoconutDrop()
    {
     //make the coconut fall
     GameObject newCoconut = createCoconut();
    }

    //take a wild guess 
    private void TreeFall()
    {
     Debug.Log("tree felled.");
    }
}
