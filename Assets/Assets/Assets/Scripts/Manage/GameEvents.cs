using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{
    public static UnityEvent PlayerDied = new UnityEvent();
    public static UnityEvent EnemyDied = new UnityEvent();
    public static UnityEvent CollectItem = new UnityEvent();
    public static UnityEvent EnemySpawn = new UnityEvent();
}
