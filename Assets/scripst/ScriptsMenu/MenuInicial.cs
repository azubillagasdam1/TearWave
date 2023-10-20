using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
 public void jugarNivel1(){
    Debug.Log("JugandoNivel1...");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
 }
  public void jugarNivel2(){
    Debug.Log("JugandoNivel2...");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
 }
  public void jugarNivel3(){
    Debug.Log("JugandoNivel3...");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
 }

 public void salir(){
    Debug.Log("Salír...");
    Application.Quit();

 }
}
