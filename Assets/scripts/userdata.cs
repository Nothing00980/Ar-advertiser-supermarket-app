
using UnityEngine;

[CreateAssetMenu]
public class userdata : ScriptableObject
{
   public string username;
    public string email;
    public string phone;
    public string userId;
    public string token;

    // Method to populate user data
    public void PopulateUserData(string username, string email, string phone, string userId, string token)
    {
        this.username = username;
        this.email = email;
        this.phone = phone;
        this.userId = userId;
        this.token = token;
    }
    
}
