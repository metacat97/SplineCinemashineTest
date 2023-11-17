using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;
using System.Linq;

public class PlayfabFriendController : MonoBehaviour
{
    public static Action<List<FriendInfo>> OnFriendListUpdated = delegate { };
    private List<FriendInfo> friends;
    private void Awake()
    {
        friends = new List<FriendInfo>();
        PhotonConnect.GetPhotonFriends += HandleGetFriends;
        UiAddFriend.OnAddFriend += HandleAddPlayfabFriend;
        UiFriend.OnRemoveFriend += HandleRemoveFriend;
    }
    private void OnDestroy()
    {
        UiAddFriend.OnAddFriend -= HandleAddPlayfabFriend;
        UiFriend.OnRemoveFriend -= HandleRemoveFriend;
    }

    void Start()
    {
        //HandleRemoveFriend(string name)
    }
    private void HandleAddPlayfabFriend(string name)
    {
        var request = new AddFriendRequest { FriendTitleDisplayName = name };
        PlayFabClientAPI.AddFriend(request, OnFriendedAddedSuccess, OnFailure);
    }
    private void HandleGetFriends()
    {
        GetPlayfabFriends();
    }
    private void GetPlayfabFriends()
    {
        var request = new GetFriendsListRequest {  XboxToken = null };
        //이거 직접 추가함
        
        PlayFabClientAPI.GetFriendsList(request, OnFriendListSuccess, OnFailure);
    }
    private void HandleRemoveFriend(string name)
    {
        string id = friends.FirstOrDefault(f => f.TitleDisplayName == name).FriendPlayFabId;
        var request = new RemoveFriendRequest { FriendPlayFabId = id };
        PlayFabClientAPI.RemoveFriend(request, OnFriendRemoveSuccess, OnFailure);
    }

    private void OnFriendListSuccess(GetFriendsListResult result)
    {
        friends = result.Friends;
        OnFriendListUpdated?.Invoke(result.Friends);
    }
    private void OnFriendRemoveSuccess(RemoveFriendResult result)
    {
        GetPlayfabFriends();
    }
    private void OnFriendedAddedSuccess(AddFriendResult result)
    {
        GetPlayfabFriends();
    }

    private void OnFailure(PlayFabError error)
    {
        Debug.Log($"Error 친구 추가할 때 에러입니다요{error.GenerateErrorReport()}");
    }

}
