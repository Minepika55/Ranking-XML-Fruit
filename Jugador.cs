using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Jugador : MonoBehaviour
{
    public string Nom;
    public int Puntuacio;

    public Jugador(string nom, int puntuacio)
    {
        Nom = nom;
        Puntuacio = puntuacio;
    }
}
