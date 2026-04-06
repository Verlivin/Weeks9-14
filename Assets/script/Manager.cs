using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;
    public List<AudioClip> SFXs;
    public AudioSource SFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player);


        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        LocalMultiplayerController controller = player.GetComponent<LocalMultiplayerController>();
        controller.manager = this;
        controller.SFX.clip = SFXs[player.playerIndex];
    }
    public void PlayerAttacking(PlayerInput attackingPlayer)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (attackingPlayer == players[i]) continue;

            if (Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position) < 0.5f)
            {
                SFX.Play();
                Debug.Log("Player " + attackingPlayer.playerIndex + " attcked player " + players[i].playerIndex);
            }
            
        }
    }
}
