using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;  //On récupère l'UI du menu pause
    [SerializeField] private GameObject WinUI;        //On récupère l'UI de victoire
    private static bool gamePaused = false;           //Variable pour savoir si le jeu est en pause (= fausse)

    private void PausePerformed(InputAction.CallbackContext obj) //Fonction exécutée quand on appuie sur Echap
    {
        if (gamePaused)                                          //Si la variable gamePaused est vraie
        {
            Resume();                                            //On exécute la fonction Resume
        }
        else                                                     //Sinon si la variable gamePaused est fausse
        {
            Paused();                                            //Alors on exécute la fonction Paused
        }
    }

    private void Paused()                                 //Fonction qui active l'UI du menu pause
    {
        PauseMenuUI.SetActive(true);                      //On active l'UI menu pause
        Time.timeScale = 0;                               //On arrête le temps (mouvement du joueur etc.)
        gamePaused = true;                                //On passe la variable gamePaused à vraie pour pouvoir désactiver le menu pause lorsqu'on rappuiera sur Echap
        WinUI.SetActive(false);                           //On désactive l'UI de victoire (pour ne pas que les UI ne se superposent lorsque l'UI de victoire est affichée et qu'on appuie sur echap)
    }

    private void Resume()                                    //Fonction qui désactive l'UI du menu pause
    {
        PauseMenuUI.SetActive(false);                        //On désactive l'UI menu pause
        Time.timeScale = 1;                                  //Le temps reprend son cours 
        gamePaused = false;                                  //On passe la variable gamePaused à faux pour pouvoir activer le menu pause lorsqu'on appuiera sur Echap
    }

    public void Play()                                  //Fonction pour charger la scène pour lancer le Jeu
    {
        SceneManager.LoadScene("Play");           //On met la scène du Jeu
    }

    public void Help()                                    //Fonction pour charger la scène des Aides
    {
        SceneManager.LoadScene("Help");                   //On met la scène des Aides
    }

    public void Credits()                                      //Fonction pour charger la scène des Credits
    {
        SceneManager.LoadScene("Credits");                      //On met la scène des Credits
    }

    public void Settings()                                      //Fonction pour charger la scène des Credits
    {
        SceneManager.LoadScene("Settings");                      //On met la scène des Credits
    }

    public void Main()                                            //Fonction pour charger la scène du Menu
    {
        SceneManager.LoadScene("Menu");                           //On met la scène du Menu
    }

    public void Quit()                                               //Fonction pour quitter le jeu 
    {
        Application.Quit();                                          //On quitte le jeu
    }
}