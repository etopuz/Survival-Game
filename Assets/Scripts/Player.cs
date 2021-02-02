using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State
    {
        Idle,
        Running,
        Jumping,
        Attacking,
        Mining,
        Dying
    }

    public static State state;
}
