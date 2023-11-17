using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public static Action GetPhotonFriends = delegate { };
    //[SerializeField] private GameObject loginPanel;
    //[SerializeField] private Button loginBtn;

    private void Awake()
    {
        //GameObject inputCanvas = GameObject.Find("FirstUiCanvas");
        //loginPanel =  inputCanvas.transform.GetChild(0).gameObject;
        //GameObject loginBtnObj = loginPanel.transform.GetChild(0).gameObject;
        //loginBtn = loginBtnObj.gameObject.GetComponent<Button>();
    }
    private void Start()
    {
        //Debug.Log(Guid.NewGuid().ToString());
        //string randomName = $"Tester{Guid.NewGuid().ToString()}";
        //loginBtn.onClick.AddListener(() => ClickLogIn(randomName));
        string name = PlayerPrefs.GetString("USERNAME");
        ClickLogIn(name);
    }

    public void ClickLogIn(string nickname)
    {
        PhotonNetwork.AuthValues = new AuthenticationValues();
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = nickname;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("연결됨");
        if(!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby(); //연결이 안되어있다면 로그인
        }
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();  
        Debug.Log("로비에 연결됨");
        //ClickCreateRoom("TestRoom");
        GetPhotonFriends?.Invoke();
    }

    public void ClickCreateRoom(string roomName)
    {
        RoomOptions myRoomOption = new RoomOptions();
        myRoomOption.IsOpen = true;
        myRoomOption.IsVisible = true;
        myRoomOption.MaxPlayers = 20;
        PhotonNetwork.JoinOrCreateRoom(roomName, myRoomOption, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        //base.OnCreatedRoom();
        Debug.Log("방 만들어짐");
    }

    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log("방 입장 성공");
    }
    public override void OnLeftRoom()
    {
        //base.OnLeftRoom();
        Debug.Log("당신은 방을 나갔습니다.");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        //base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("방 입장 실패");

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("플레이어 입장");
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("플레이어 나감");
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        //base.OnMasterClientSwitched(newMasterClient);
        Debug.Log($"NewMastser Client is {newMasterClient.UserId}");
    }

}
