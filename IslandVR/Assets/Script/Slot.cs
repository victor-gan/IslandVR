using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColour;

    // Start is called before the first frame update
    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColour = slotImage.color;
    }

    private void OnTriggerStay(Collider other)
    {
        if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
        //if (!isItem(obj)) return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
