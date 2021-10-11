using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemyPrefab;                                                                              //GameObject que l'on doit instancier
    public Vector3 spawnRange;                                                                                  //variable de spawn �ditable depuis l'�diteur
    public int NbrEnemyPerWave;                                                                                 //On d�cide du nombre d'ennemis qu'on spawn par vague

    public float waveTime;                                                                                      //param�tre pour g�rer le nombre de secondes entre chaque wave


    public bool isInGame = true;

    void Start()
    {

        StartCoroutine(generateWave());
    }

    IEnumerator generateWave()
    {

        while (isInGame)
        {

            for (int i = 0; i < NbrEnemyPerWave; i++)                                                          //On boucle pour que les ennemis spawn de 0 � 9 donc par vague de 10
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), Random.Range(spawnRange.y, spawnRange.y - 1), 0);             //On instancie un ennemi � la position du prefab (qui est al�atoire)
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);                                 //On instancie un ennemi � la position du prefab (qui est al�atoire)
            }
            yield return new WaitForSeconds(waveTime);                                                                  //temps de pause avant une autre wave, g�r� grace au param�tre waveTime �ditable depuis l'inspector
        }
    }
}