using UnityEngine;

public class User : MonoBehaviour
{
    public string Name;
    public int Gold;

    public User(string Name, int Gold)
    {
        this.Name = Name;
        this.Gold = Gold;  
    }
}
