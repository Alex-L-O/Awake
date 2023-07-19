using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataController : MonoBehaviour
{
    [SerializeField]FileManager fm;
    GameData data;

    public void SetPuntos(int pts) {
        data.puntos = pts;
    }

    public float GetPuntos(){
        return data.puntos;
    }
  
}