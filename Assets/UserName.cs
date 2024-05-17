using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public Text userName;
    // Pool of characters to choose from
    private string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;:,.<>?";

    public int usernameLength = 8; // Length of the username

    // Function to generate a random username
    public string GenerateRandomUsername()
    {
        StringBuilder usernameBuilder = new StringBuilder();

        // Generating the first 4 or 5 characters consisting only of letters
        for (int i = 0; i < 4 || (i < 5 && Random.value > 0.5f); i++)
        {
            char randomLetter = letters[Random.Range(0, letters.Length)];
            usernameBuilder.Append(randomLetter);
        }

        // Generating the remaining characters
        for (int i = usernameBuilder.Length; i < usernameLength; i++)
        {
            char randomChar = characters[Random.Range(0, characters.Length)];
            usernameBuilder.Append(randomChar);
        }

        return usernameBuilder.ToString();
    }
    // Example usage
    void Start()
    {
        
  
    }

  public void   usernameSetter()
    {
        string randomUsername = GenerateRandomUsername();
        userName.text = randomUsername;

    }
}
