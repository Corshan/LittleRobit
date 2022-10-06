using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerStats")]
public class playerStats : ScriptableObject
{
    public int health = 100;
    public int rescources = 100;
    public int scrap = 0;

}
