using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class Navegacion : MonoBehaviour
{
    public string nombreArchivo = "JuegoGuardado";
    public string nombreDirectorio = "Partidas";
    public GameData datosjuego; //Instancia de la estructura

    public static string nombreJugador = "";

    private void Awake() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start() {
        if (!Directory.Exists(nombreDirectorio)) { //Si no existe el directorio, lo crea al igual que al archivo
            Directory.CreateDirectory(nombreDirectorio);
            BinaryFormatter formatter = new BinaryFormatter(); //Convierte los datos de unity en binarios
            FileStream saveFile = File.Create(nombreDirectorio + "/" + nombreArchivo + ".bin"); //Ubicación del archivo a grabar
            formatter.Serialize(saveFile, datosjuego);
            saveFile.Close();
            Debug.Log("Guardado en " + Directory.GetCurrentDirectory().ToString() + "/" + nombreDirectorio +"/" + nombreArchivo + ".bin");
        }
    }

    //Cuando se va al juego se lleva el nombre del usuario, por si rompe el récord, guardarlo en el archivo
    public void Irmenuprincipal() {
        if (GameObject.Find("txtNombre").GetComponent<InputField>().text == "") {
            nombreJugador = "Sin nombre";
        } else {
            nombreJugador = GameObject.Find("txtNombre").GetComponent<InputField>().text;
        }        
        SceneManager.LoadScene("menu_tomatoh");
    }
    

}
