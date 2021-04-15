using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    private AudioManager audioManagerScript;

    public Rigidbody player;

    void Start()
    {
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovement>();
        audioManagerScript = GameObject.FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (playerMovementScript.grounded == true && player.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}