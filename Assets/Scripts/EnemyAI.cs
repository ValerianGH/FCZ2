using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;               //pour que l'ennemi sache qui et où est le player
    public float speed;                     //vitesse de l'ennemi

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); //l'ennemi se dirige vers le player
    }
}