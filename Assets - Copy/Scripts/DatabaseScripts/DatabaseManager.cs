using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    private string userID;
    private DatabaseReference databaseReference;

    public InputField Name;
    public InputField Gold;

    public Text NameText;
    public Text GoldText;

    void Start()
    {

        userID = SystemInfo.deviceUniqueIdentifier;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update()
    {
        
    }

    public void CreateUser()
    {
        User newUser = new User(Name.text, int.Parse(Gold.text));
        string json = JsonUtility.ToJson(newUser);

        databaseReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetName(Action<String> onCallback)
    {
        var userNameData=databaseReference.Child("users").Child(userID).Child("Name").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if(userNameData!=null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallback.Invoke(snapshot.Value.ToString());
        }
    }
    public IEnumerator GetGold(Action<int> onCallback) 
    {
        var userGoldData = databaseReference.Child("users").Child(userID).Child("Gold").GetValueAsync();
        yield return new WaitUntil(predicate: () => userGoldData.IsCompleted);

        if (userGoldData != null)
        {
            DataSnapshot snapshot = userGoldData.Result;
            onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
        }
    }
    public void GetUserInfo()
    {
        StartCoroutine(GetName((string name) =>
        {
            NameText.text ="Name: "+ name;
        }));

        StartCoroutine(GetGold((int Gold) =>
        {
            GoldText.text = "Gold "+ Gold.ToString();
        }));
    }
    public void UpdateName()
    {
        databaseReference.Child("users").Child(userID).Child("Name").SetValueAsync(Name.text);
    }
    public void UpdateGold()
    {
        databaseReference.Child("users").Child(userID).Child("Gold").SetValueAsync(Gold.text);
    }
}
