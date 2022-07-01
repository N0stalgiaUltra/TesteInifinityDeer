using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Assets/Create Enemy")]
public class EnemyData : ScriptableObject
{
    public int health;
    public int damage;
    public float speed;
}
