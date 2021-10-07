using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;                                             //variable pour gérer la vitesse de l'ennemi
    public Transform Target;

    void Start()
    {
        Positioninitial = transform.//hors de la cam
        Target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
