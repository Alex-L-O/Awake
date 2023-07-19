using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public string nombreArchivo = "JuegoGuardado";
    public string nombreDirectorio = "Partidas";
   //public GameData datosjuego; //Instancia de la estructura
    public static int record; //Variable que carga el récord
    public static string nombreR; //Nombre de la persona que tiene el récord de puntos

    private void Start() {
        LoadFile();  //Al cargar la escena de juego se cargan los datos almacenados      
    }    

    //Método para salvar en archivo
    public void SaveToFile() {
        if (!Directory.Exists(nombreDirectorio)) Directory.CreateDirectory(nombreDirectorio);                
        BinaryFormatter formatter = new BinaryFormatter(); //Convierte los datos de unity en binarios
        FileStream saveFile = File.Create(nombreDirectorio + "/" + nombreArchivo + ".bin"); //Ubicación del archivo a grabar
        GameData datosjuego = new GameData(ManagerDisparo.puntosPlayer, 5.1f, Navegacion.nombreJugador); //Salva los datos del juego cuando pierde el jugador
        formatter.Serialize(saveFile, datosjuego);
        saveFile.Close();
        Debug.Log("Guardado en " + Directory.GetCurrentDirectory().ToString() + "/Saves/" + nombreArchivo + ".bin");
    }

    //Método para cargar los datos del archivo
    public void LoadFile() {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open(nombreDirectorio + "/" + nombreArchivo + ".bin", FileMode.Open);
        GameData loadData = (GameData)formatter.Deserialize(saveFile);      
        Debug.Log("Datos cargados *************");
        Debug.Log("Nombre " + loadData.nombre);
        Debug.Log("Puntos " + loadData.puntos);
        Debug.Log("Tiempo " + loadData.tiempo);
        record = loadData.puntos;
        nombreR = loadData.nombre;
    }

}
