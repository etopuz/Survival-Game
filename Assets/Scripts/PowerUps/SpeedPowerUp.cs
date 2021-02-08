using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerScriptSystem;


public class SpeedPowerUp : PowerUp
{
    [SerializeField]
    private float speedMultiplier = 2f;

    void Update()
    {
        RotatePowerUps();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerScript = other.GetComponent<PlayerController>();
            playerScript.ChangeSpeed(speedMultiplier);
            Destroy(this.gameObject);
        }
    }
}
