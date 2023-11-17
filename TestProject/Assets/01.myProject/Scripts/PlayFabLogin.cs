using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private string username;
    public TMP_InputField loginIdField;
    public Button loginBtn;

    // Start is called before the first frame update
    void Start()
    {
        //loginIdField.onValueChanged.AddListener(() => SetUsername());
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "4FCDA";
        }
        loginBtn.onClick.AddListener(() => Login());
    }
    private bool IsValidUsername()
    {
        bool isValid = false;

        if(username.Length >= 3 && username.Length <= 24)
        {
            isValid = true;
        }
        return isValid;
    }

    private void LoginUsingCustomId()
    {
        Debug.Log($"Login to Playfab as {username}");
        var request = new LoginWithCustomIDRequest {CustomId = username, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginCustomIdSuccess, OnFailure);
    }

    private void UpdateDisplayName(string displayName)
    {
        Debug.Log($"당신은 업데이트 됐다 닉네임이 {displayName}");
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayName};
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameSuccess, OnFailure);
    }

   

    public void SetUsername(string username)
    {
        this.username = username;
        PlayerPrefs.SetString("USERNAME", username);
    }
    public void Login()
    {
        if (!IsValidUsername()) return;

        LoginUsingCustomId();
    }


    #region 플레이어 콜백
    private void OnLoginCustomIdSuccess(LoginResult result)
    {
        Debug.Log($"너는 로그인 됐다. 커스텀 아이디로{username} ");
        UpdateDisplayName(username);
    }
    private void OnDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log($"너는 갱신됐다 디스플레이 네임{username} ");
        SceneController.LoadMyScene("MainMenu");
    }
    private void OnFailure(PlayFabError error)
    {
        Debug.Log("넌 실패했다 로그인 그래 ");
    }
    #endregion


}
