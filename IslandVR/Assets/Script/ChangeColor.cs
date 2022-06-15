using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //arbitrary material, to be connected in inspector.
    [SerializeField] private Material material;
    [SerializeField] private Transform pos;

    private void OnTriggerEnter(Collider rightController)
    {
        if (rightController.CompareTag("RightController"))
        {
            material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider rightController)
    {
        if (rightController.CompareTag("RightController"))
        {
            material.color = Color.red;
        }
    }

    private void Update()
    {
        if(pos.localPosition.x <= 0)
        {
            material.color = Color.green;
        }

        if (pos.localPosition.x > 0)
        {
            material.color = Color.red;
        }
    }
}