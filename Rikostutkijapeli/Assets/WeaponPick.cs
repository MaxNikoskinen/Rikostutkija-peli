﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{
    public float distance = 10f;
    public Transform equipPosition;
    GameObject currentWeapon;
    GameObject wp;

    bool canGrab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWeapons();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeapon != null)
                    Drop();

                PickUp();
            }
                
        }

        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Drop();
        }
        
    }

    private void CheckWeapons()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit,distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log(" I can grab it!");
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        else
            canGrab = false;
    }


    private void PickUp()
    {
        currentWeapon = wp;
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;

        Debug.Log("Picked it up");

    }

    private void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }


}