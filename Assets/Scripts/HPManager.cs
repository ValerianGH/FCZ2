using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    public int HP;
    private int maxHP;

    private void Start()
    {
        maxHP = HP;
    }

    void Update()
    {
        if (HP == 0 & tag == "ENEMY") 
        {
            Destroy(gameObject);
        }
        else if(HP == 0 & tag == "PLAYER")
        {
            
            transform.position = SpawnPoint.position;
            HP = maxHP;
        
        }
        Debug.Log(HP);
    }
}
