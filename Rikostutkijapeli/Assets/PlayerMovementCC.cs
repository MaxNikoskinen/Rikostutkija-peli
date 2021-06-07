using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCC : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 12;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public bool allowMovement = true;
    public UIInventory uiInventory;
    public GameObject mapUI;
    public GameObject noteUI;
    public GameObject flashLight;


    private bool flashLightOn;
    private Inventory inventory;
    Vector3 velocity;
    [HideInInspector] public bool isGrounded;

    private void Start()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
    }

    private void UseItem(Item item)
    {
        switch(item.itemType)
        {
            case Item.ItemType.Map:
                mapUI.SetActive(true);
                break;
            case Item.ItemType.Flashlight:
                if(flashLightOn == false)
                {
                    flashLight.SetActive(true);
                    flashLightOn = true;
                }
                else
                {
                    flashLight.SetActive(false);
                    flashLightOn = false;
                }
                break;
            case Item.ItemType.PaperNote:
                noteUI.SetActive(true);
                break;
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if(allowMovement == true)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded && allowMovement)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void AllowMovement()
    {
        allowMovement = true;
    }
}
