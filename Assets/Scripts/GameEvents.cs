using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringEvent : UnityEvent<string> { }

public class GameEvents
{
    static public StringEvent OnHudText = new StringEvent();
}
