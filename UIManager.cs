using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_InputField nomInput;
    public TMP_InputField puntuacioInput;
    public TextMeshProUGUI rankingText;
    public PlayerList playerListManager;

    void Start()
    {
        RefrescarRanking();
    }

    public void AfegirJugador()
    {
        string nom = nomInput.text;
        int puntuacio;

        if (int.TryParse(puntuacioInput.text, out puntuacio))
        {
            playerListManager.AfegirJugador(nom, puntuacio);
            RefrescarRanking();
        }
        else
        {
            Debug.LogError("Error.");
        }
    }

    public void RefrescarRanking()
    {
        rankingText.text = playerListManager._playerListText.text;
    }
}
