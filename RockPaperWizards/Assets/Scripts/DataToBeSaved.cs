
using System.Collections.Generic;

[System.Serializable]
public class ProfilesSaveData
{
    public List<string> Profiles = new List<string>();
}
[System.Serializable] 
public class PlayerInfo
{
    public string name;
    public int wizard;
    public int voice;

    public int turnNumber;
    public Attacks currentAttack;

    public int lives;

    public List<string> activeGames;
}
public class GameData
{
    public int gameId;
    public List<PlayerInfo> players;
}