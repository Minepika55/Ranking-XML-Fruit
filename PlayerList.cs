using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour
{
    public TextMeshProUGUI _playerListText;
    public TMP_InputField _playerNameInput;
    public TMP_InputField _playerScoreInput;
    public Button _addPlayerButton;
    private List<Player> players = new List<Player>();
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "jugadors.xml");
        CarregarJugadorsPerDefecte();
        CarregarJugadors();
        MostrarLista();

        // Add listener to the button click event
        _addPlayerButton.onClick.AddListener(OnAddPlayerButtonClicked);
    }

    void Update()
    {
        //MostrarLista();
        //GuardarJugadors();
    }

    void CarregarJugadorsPerDefecte()
    {
        if (!File.Exists(filePath))
        {
            players.Add(new Player("Tomaz91", 10));
            players.Add(new Player("Frost", 50));
            players.Add(new Player("Ritz", 90));
            players.Add(new Player("LuckHax", 120));
            GuardarJugadors();
        }
    }

    void GuardarJugadors()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, players);
        }
    }

    void CarregarJugadors()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                players = (List<Player>)serializer.Deserialize(stream);
            }
        }
    }

    void MostrarLista()
    {
        players.Sort(); // Ordenar els jugadors
        string playerList = "";

        for (int i = 0; i < players.Count && i < 3; i++)
        {
            playerList += players[i].name + " " + players[i].click + "\n";
        }

        _playerListText.text = playerList;

    }

    public void AfegirJugador(string nom, int puntuacio)
    {
        players.Add(new Player(nom, puntuacio));
        GuardarJugadors();
        MostrarLista();
    }

    private void OnAddPlayerButtonClicked()
    {
        string playerName = _playerNameInput.text;
        int playerScore;

        if (int.TryParse(_playerScoreInput.text, out playerScore))
        {
            AfegirJugador(playerName, playerScore);
            _playerNameInput.text = "";//Natejar Inputs
            _playerScoreInput.text = "";
        }
        else
        {
            Debug.LogError("Error");
        }
    }
}