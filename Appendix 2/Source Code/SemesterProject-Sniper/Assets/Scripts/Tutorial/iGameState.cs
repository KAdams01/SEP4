using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iGameState
{
    void TransitionToNextState();
}
