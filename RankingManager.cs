using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public List<Jugador> jugadors = new List<Jugador>();
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "jugadors.xml");
        CarregarRanking();
    }

    public void AfegirJugador(string nom, int puntuacio)
    {
        jugadors.Add(new Jugador(nom, puntuacio));
        GuardarRanking();
    }

    public void GuardarRanking()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Jugador>));
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, jugadors);
        }
    }

    public void CarregarRanking()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Jugador>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                jugadors = (List<Jugador>)serializer.Deserialize(stream);
            }
        }
    }

    public List<Jugador> ObtenirTop3()
    {
        return jugadors.OrderByDescending(j => j.Puntuacio).Take(3).ToList();
    }
}
