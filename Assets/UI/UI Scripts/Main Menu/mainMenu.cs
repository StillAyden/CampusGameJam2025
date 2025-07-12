using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class mainMenu : MonoBehaviour
{
    public UIDocument _document;

    public Button _buttonPlay;
    public Button _buttonExit;
    public Button _openSettingButton;
    public Button _closeSettingButton;

    public List<Button> menuButtons = new List<Button>();

    public VisualElement _settingMenu;

    public Label _winorloseCondition;

    private float previousVolume;
    public AudioMixerGroup _masterMixerGroup;
    //private bool isMuted = false;

    private Slider _masterVolumeSlider;
    private Toggle _masterMuteToggle;

    // To Reder: I am not sure where this is supposed to be?
    //public soundManager_MainMenu _soundManager;
   
    // Start is called before the first frame update
    void Start()
    {

        //_soundManager = FindObjectOfType<soundManager_MainMenu>();

        //if (_soundManager == null)
        //{
        //    Debug.LogError("SoundManager not found in the scene!");
        //}

        VisualElement root = _document.rootVisualElement;

        _masterVolumeSlider = root.Q<Slider>("VolumeSlider");
        _masterMuteToggle = root.Q<Toggle>("MuteSound_Toggle");

        _buttonPlay = root.Q<Button>("Play");
        _buttonExit = root.Q<Button>("Exit");
        _openSettingButton = root.Q<Button>("Settings");
        _closeSettingButton = root.Q<Button>("Minimize");
        _settingMenu = root.Q<VisualElement>("SettingsMenu");

        _settingMenu.style.display = DisplayStyle.None;

        _buttonPlay.clicked += () => playGame();
        _buttonExit.clicked += () => exitGame();
        _openSettingButton.clicked += () => openSettings();
        _closeSettingButton.clicked += () => closeSettings();


        _buttonPlay.name = "Play Button";
        _buttonExit.name = "Exit Button";
        _closeSettingButton.name = "Close Settings";

        //_masterVolumeSlider.RegisterValueChangedCallback(evt =>
        //{
        //    _soundManager.UpdateMasterVolume(evt.newValue);
        //});

        //_masterMuteToggle.RegisterValueChangedCallback(evt =>
        //{
        //    _soundManager.MuteMasterVolume(evt.newValue);
        //});

        menuButtons.Add(_buttonPlay);
        menuButtons.Add(_buttonExit);
        menuButtons.Add(_openSettingButton);
    }

    public void playGame()
    {
        //play GamePlay


        // Reload the active scene
        //_soundManager.butttonPressed();
        //_soundManager.saveVolume();
        SceneManager.LoadScene("Gameplay");
    }

    public void exitGame()
    {
        //_soundManager.butttonPressed();
        Application.Quit();
    }
  
    public void openSettings()
    {
        //_soundManager.butttonPressed();
        _settingMenu.style.display = DisplayStyle.Flex;
    }

    public void closeSettings()
    {
        //_soundManager.butttonPressed();
        _settingMenu.style.display = DisplayStyle.None;
    }
    // Update is called once per frame
}