using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl player1;
    [SerializeField] private PlayerControl player2;
    [SerializeField] private PlayerControl player3;
    [SerializeField] private PlayerControl player4;

    [SerializeField] private PlayerControl[] players;
    [SerializeField] private int playerIndex = 0;

    public event Action OnGameOver;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SwapPlayerStats(float newValue)
    {
        Debug.Log("index"+playerIndex);
        players[playerIndex].SetSpeed(newValue);
        players[playerIndex].SetJumpForce(newValue);
    }
    public void OnChangeCharacterRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            SwapPlayerStats(0);
            playerIndex++;

            if (playerIndex >= players.Length)
                playerIndex = 0;

            SwapPlayerStats(5);
        }
    }
    public void OnChangeCharacterLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwapPlayerStats(0);
            playerIndex--;

            if (playerIndex <= 0)
                playerIndex = players.Length - 1;
            Debug.Log("playerlength" + players.Length);

            SwapPlayerStats(5);
        }
    }
}
