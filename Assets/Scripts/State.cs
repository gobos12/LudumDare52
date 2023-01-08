using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public string name;
    public bool state;

    public void SetState(bool b)
    {
        state = b;
    }
}
