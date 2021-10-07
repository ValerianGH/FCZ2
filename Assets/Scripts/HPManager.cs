using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public int HP;
    private int maxHP;

    private void Start()
    {
        maxHP = HP;
    }

    void Update()
    {
        if (HP == 0) // TOUS
        {
            Debug.Log(HP);
            Destroy(gameObject); // enemy only
        }
        //transform.position = SpawnPoint.position; // player only
        //HP = maxHP; // player only
    }
}
