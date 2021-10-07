using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;  //On r�cup�re l'UI du menu pause
    [SerializeField] private GameObject WinUI;        //On r�cup�re l'UI de victoire
    private static bool gamePaused = false;           //Variable pour savoir si le jeu est en pause (= fausse)

    private void PausePerformed(InputAction.CallbackContext obj) //Fonction ex�cut�e quand on appuie sur Echap
    {
        if (gamePaused)                                          //Si la variable gamePaused est vraie
        {
            Resume();                                            //On ex�cute la fonction Resume
        }
        else                                                     //Sinon si la variable gamePaused est fausse
        {
            Paused();                                            //Alors on ex�cute la fonction Paused
        }
    }

    private void Paused()                                 //Fonction qui active l'UI du menu pause
    {
        PauseMenuUI.SetActive(true);                      //On active l'UI menu pause
        Time.timeScale = 0;                               //On arr�te le temps (mouvement du joueur etc.)
        gamePaused = true;                                //On passe la variable gamePaused � vraie pour pouvoir d�sactiver le menu pause lorsqu'on rappuiera sur Echap
        WinUI.SetActive(false);                           //On d�sactive l'UI de victoire (pour ne pas que les UI ne se superposent lorsque l'UI de victoire est affich�e et qu'on appuie sur echap)
    }

    private void Resume()                                    //Fonction qui d�sactive l'UI du menu pause
    {
        PauseMenuUI.SetActive(false);                        //On d�sactive l'UI menu pause
        Time.timeScale = 1;                                  //Le temps reprend son cours 
        gamePaused = false;                                  //On passe la variable gamePaused � faux pour pouvoir activer le menu pause lorsqu'on appuiera sur Echap
    }

    public void Play()                                  //Fonction pour charger la sc�ne pour lancer le Jeu
    {
        SceneManager.LoadScene("Play");           //On met la sc�ne du Jeu
    }

    public void Help()                                    //Fonction pour charger la sc�ne des Aides
    {
        SceneManager.LoadScene("Help");                   //On met la sc�ne des Aides
    }

    public void Credits()                                      //Fonction pour charger la sc�ne des Credits
    {
        SceneManager.LoadScene("Credits");                      //On met la sc�ne des Credits
    }

    public void Settings()                                      //Fonction pour charger la sc�ne des Credits
    {
        SceneManager.LoadScene("Settings");                      //On met la sc�ne des Credits
    }

    public void Main()                                            //Fonction pour charger la sc�ne du Menu
    {
        SceneManager.LoadScene("Menu");                           //On met la sc�ne du Menu
    }

    public void Quit()                                               //Fonction pour quitter le jeu 
    {
        Application.Quit();                                          //On quitte le jeu
    }
}