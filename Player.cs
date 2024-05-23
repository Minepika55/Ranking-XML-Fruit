using System;

[System.Serializable]
public class Player : IComparable<Player>
{
    public string name;
    public int click;

    public Player() { }

    public Player(string name, int click)
    {
        this.name = name;
        this.click = click;
    }

    public int CompareTo(Player other)
    {
        return other.click.CompareTo(this.click);
    }
}