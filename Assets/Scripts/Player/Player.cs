using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScriptSystem
{
    public class Player : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Running,
            Sprinting,
            Jumping,
            Attacking,
            Mining,
            Dying
        }

        public static State state;

    }
}

