using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiFriend : MonoBehaviour
{
    [SerializeField] private TMP_Text friendNameText;
    [SerializeField] private FriendInfo friend;

    public static Action<string> OnRemoveFriend = delegate { };

    public void Initialize(FriendInfo friend)
    {
        this.friend = friend;
        friendNameText.SetText(this.friend.UserId);

    }
    public void RemoveFriend()
    {
        OnRemoveFriend?.Invoke(friend.UserId);
    }
   

}

