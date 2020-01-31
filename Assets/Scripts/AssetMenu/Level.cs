﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public string levelName;
    public GameObject[] enemys;
    public float respawnTime;

}
