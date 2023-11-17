using Photon.Pun;
using Photon.Realtime;
using PlayfabFriendInfo = PlayFab.ClientModels.FriendInfo;
using PhotonFriendInfo = Photon.Realtime.FriendInfo;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PhotonFriendController : MonoBehaviourPunCallbacks
{
    public static Action<List<PhotonFriendInfo>> OnDisplayFriends = delegate { };
    private void Awake()
    {
        PlayfabFriendController.OnFriendListUpdated += HandleFriendsUpdated;
    }

    private void OnDestroy()
    {
        PlayfabFriendController.OnFriendListUpdated -= HandleFriendsUpdated;
    }
    private void HandleFriendsUpdated(List<PlayfabFriendInfo> friends)
    {
        if (friends.Count != 0)
        {
            string[] friendDisplayNames = friends.Select(f => f.TitleDisplayName).ToArray();
            PhotonNetwork.FindFriends(friendDisplayNames); //친구 이름 전달 ?? 일단은 따라치는느중
        }
        else
        {
            List<PhotonFriendInfo> friendList = new List<PhotonFriendInfo>();
            //Debug.Log($"여기 들어옴?{friendList}");
            OnDisplayFriends?.Invoke(friendList);
        }
    }

    public override void OnFriendListUpdate(List<PhotonFriendInfo> friendList)
    {
        //base.OnFriendListUpdate(friendList);
        Debug.Log("포톤 리스트 업테이트입니다");
        OnDisplayFriends?.Invoke(friendList);
    }

}
