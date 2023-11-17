using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDisplayFriend : MonoBehaviour
{
    [SerializeField] private Transform friendContainer;
    [SerializeField] private UiFriend uiFriendPrefab;

    private void Awake()
    {
        PhotonFriendController.OnDisplayFriends += HandleDisplayFriends;
    }
    private void OnDestroy()
    {
        PhotonFriendController.OnDisplayFriends += HandleDisplayFriends;
    }
    private void HandleDisplayFriends(List<FriendInfo> friends)
    {
        foreach(Transform child in friendContainer)
        {
            Debug.Log(child.gameObject.name);   
            Destroy(child.gameObject);
        }

        foreach(FriendInfo friend in friends)
        {
            UiFriend uifriend = Instantiate(uiFriendPrefab, friendContainer);
            uifriend.Initialize(friend);
        }

    }
}
