using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    // UI elements will be defined here
    public UIDocument _HUD;

    // VisualElements
    public VisualElement _PlayerProfile;
    public VisualElement _Map;
    public VisualElement _PotionPicker;
    public VisualElement _StatusEffectIndicatorBG;
    public VisualElement _StatusEffectIndicatorIcon;
    public VisualElement _HealthBar;
    public VisualElement _StaminaBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = _HUD.rootVisualElement;

        // Visual Elements
        _PlayerProfile = root.Q <VisualElement> ("PlayerProfile");
        _Map = root.Q<VisualElement>("Map");
        _PotionPicker = root.Q<VisualElement>("PotionPicker");
        _StatusEffectIndicatorBG = root.Q<VisualElement>("StatusEfefctIndicatorBG");
        _StatusEffectIndicatorIcon = root.Q<VisualElement>("StatusEfefctIndicatorIcon");
        _HealthBar = root.Q <VisualElement> ("HealthBar");
        _StaminaBar = root.Q <VisualElement> ("StaminaBar");
    }

}
