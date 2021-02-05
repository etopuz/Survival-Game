using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : PowerUp
{
    [SerializeField]
    private float jumpHeightMultiplier = 2f;

    void Update()
    {
        RotatePowerUps();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerScript = other.GetComponent<PlayerController>();
            playerScript.ChangeJumpHeight(jumpHeightMultiplier);
            Destroy(this.gameObject);
        }
    }
}
