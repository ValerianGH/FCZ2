using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemyPrefab;                                                                              //GameObject que l'on doit instancier
    public Vector3 spawnRange;                                                                                  //variable de spawn éditable depuis l'éditeur
    public int NbrEnemyPerWave;                                                                                 //On décide du nombre d'ennemis qu'on spawn par vague

    public float waveTime;                                                                                      //paramètre pour gérer le nombre de secondes entre chaque wave


    public bool isInGame = true;

    void Start()
    {

        StartCoroutine(generateWave());
    }

    IEnumerator generateWave()
    {

        while (isInGame)
        {

            for (int i = 0; i < NbrEnemyPerWave; i++)                                                          //On boucle pour que les ennemis spawn de 0 à 9 donc par vague de 10
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), Random.Range(spawnRange.y, spawnRange.y - 1), 0);             //On instancie un ennemi à la position du prefab (qui est aléatoire)
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);                                 //On instancie un ennemi à la position du prefab (qui est aléatoire)
            }
            yield return new WaitForSeconds(waveTime);                                                                  //temps de pause avant une autre wave, géré grace au paramètre waveTime éditable depuis l'inspector
        }
    }
}