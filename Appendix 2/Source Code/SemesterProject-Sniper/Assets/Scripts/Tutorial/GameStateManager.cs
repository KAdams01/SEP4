using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameState gameState;

    void Awake()
    {
        gameState = GameState.Welcome;
    }
}
