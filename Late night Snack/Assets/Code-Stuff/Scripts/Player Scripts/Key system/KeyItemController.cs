using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] private bool apartmentDoor = false;
    [SerializeField] private bool apartmentKey = false;
    [SerializeField] private bool isSecret = false;
    public EndingStarter ending;

    [SerializeField] private KeyInventory _keyInventory = null;

    //private LockedDoor doorObject;
    private KeyDoorController doorObject;

    private void Start()
    {
        if (apartmentDoor)
        {
            //doorObject = GetComponent<LockedDoor>();
            doorObject = GetComponent<KeyDoorController>();
        }
    }

    public void ObjectInteraction()
    {
        if (apartmentDoor)
        {
            doorObject.PlayAnimation();
            //doorObject.OpenDoor();
        }

        else if (apartmentKey)
        {
            _keyInventory.hasApartmentKey = true;
            gameObject.SetActive(false);
        }
        else if(isSecret)
        {
            ending.collectedSecret = true;
            gameObject.SetActive(false);
        }
    }
}
