﻿using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip coinPickupSFX = null;
    [SerializeField] private float coinPickupVolume = 0.6f;
    [SerializeField] private int coinScore = 1;

    private bool addedToScore = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int playerLayer = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == playerLayer)
        {
            if (!addedToScore)
            {
                addedToScore = true;

                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, coinPickupVolume);

                GameSession gameSession = FindObjectOfType<GameSession>();
                if (gameSession == null)
                {
                    Debug.LogError("GameSession is null, add GameSession to the scene.");
                    return;
                }
                gameSession.AddToScore(coinScore);

                gameObject.SetActive(false);
            }
        }
    }
}
