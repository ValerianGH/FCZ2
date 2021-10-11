using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    [SerializeField] private int damages;

    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<HPManager>())
        {
            collision.GetComponent<HPManager>().HP -= damages;

            Destroy(objectToDestroy);
        }
    }
}
