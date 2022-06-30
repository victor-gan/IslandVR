using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColour;
    public InputActionReference activateReference = null;
    private bool removeItemFlag = false; //turns true when gameobject is removed from inventory, but grip is still held
    private GameObject removeItemGameObject = null; //stores the gameobject that has been removed but is still held


    // Start is called before the first frame update
    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColour = slotImage.color;
    }

    // OnTriggerStay is called constantly when another gameobject's collider is colliding with this script's gameobject
    private void OnTriggerStay(Collider other)
    {
        if (ItemInSlot != null) return;
        if (!IsItem(other.gameObject)) return;
        if(activateReference.action.ReadValue<float>() == (float) 0)
        {
            InsertItem(other.gameObject);
        }
    }

    // Called when a gameobject stored in the inventory is taken out
    private void OnTriggerExit(Collider other)
    {
        if(!GameObject.ReferenceEquals(ItemInSlot, other.gameObject)) return;
        if(activateReference.action.ReadValue<float>() != (float) 0)
        {
            // A flag is switched on which will cause RemoveItem to be called in update() when the grip is released. This is done because if RemoveItem is 
            // called here, when the grip is released, the gameobject will remain a child of this slot, causing glitches.
            removeItemFlag = true;
            removeItemGameObject = other.gameObject;
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        slotImage.color = Color.gray;
    }

    void RemoveItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.transform.parent = null;
        obj.GetComponent<Item>().inSlot = false;
        obj.GetComponent<Item>().currentSlot = null;
        ItemInSlot = null;
        ResetColor();
    }

    public void ResetColor()
    {
        slotImage.color = originalColour;
    }

    // Update is called once per frame
    void Update()
    {
        if(removeItemFlag)
        {
            if(activateReference.action.ReadValue<float>() == (float) 0)
            {
                RemoveItem(removeItemGameObject);
                removeItemFlag = false;
                removeItemGameObject = null;
            }
        }
    }
}
