using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroClass
{
    Barbarian,
    Crusader,
    DemonHunter,
    Monk,
    Necromancer,
    WitchDoctor,
    Wizard
}

[System.Serializable]
public class Hero
{
    public int id;
    public int level;
    public string name;
    public int gold;
    public HeroClass heroClassIndex;
    public string heroClassName;
}
