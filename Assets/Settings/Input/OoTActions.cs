//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Settings/Input/OoTActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @OoTActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @OoTActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""OoTActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7ed1db27-b1ba-4d20-83b3-ef35ac90ab82"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f5dddde1-bd9b-4022-a93a-28b60741bc99"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""a4cec90a-bccd-4de7-9684-7f0b2b780289"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sword"",
                    ""type"": ""Button"",
                    ""id"": ""72849ff6-2a1a-4c84-8e52-6355d354f000"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""88a0351b-c611-4dca-b4ae-0da54d4ab8a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item1"",
                    ""type"": ""Button"",
                    ""id"": ""d5b333b9-6812-451b-a0f3-bb6e76a0597c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item2"",
                    ""type"": ""Button"",
                    ""id"": ""f0af2ca1-8835-4347-93e3-8560c6111016"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item3"",
                    ""type"": ""Button"",
                    ""id"": ""9bc6784b-c801-4d50-bada-9d391bdb3d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Navi"",
                    ""type"": ""Button"",
                    ""id"": ""80ef3789-2a2c-4887-ac92-39915f639ba7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""6ba0853f-9534-4efb-9122-d727ce0d177b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleMap"",
                    ""type"": ""Button"",
                    ""id"": ""3275a551-66ac-4ac5-a79e-79bfc0b5a744"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenSubscreen"",
                    ""type"": ""Button"",
                    ""id"": ""82729699-ee72-4337-9046-5fe380b888c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""87dcdee9-7d27-46d7-881a-14e3c24da3d2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1de79e3e-8510-453b-9be9-e65c7485d6d6"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Sword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8f1c965-22bd-419d-acf2-4e81e3cdd008"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""39c27fc0-fd9d-4604-aeae-d120287930f4"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7270951c-354f-4b78-b37f-9df46fd92d62"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""597625ca-0e0d-45c5-a970-ae2cfc1603e1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d3aa94a3-5f9c-4490-acf9-75325fef161e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""727123df-4ad1-4b11-a71a-fef9faa5dec7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f919ade-0b0b-4e05-a964-1002045bdcef"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e869fc6d-74a8-40f1-9551-32708f6352e5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a2236ce-1a63-4fbe-bfd9-6480a655e8f3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e1d3f42-e553-4adb-a0be-0fd21c29b78c"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da09fc56-8e67-4b42-aff4-2e3357b6a4f9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""626cd20d-9c4f-403c-baca-5767fb5fe792"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f579f87-87f6-4b9c-82f4-5691b6706b63"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34d519df-f7a8-4313-a431-5d49193ff2cc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f361200-ccfd-4c7c-97e4-1f35cd070fbd"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffec1278-8ab4-4ab4-b7f9-092f3cbc2f5d"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36d51ed0-3b21-4275-8564-c0fa94d2829d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd2ce8a4-5f36-4ba0-a769-cddff61f80c6"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1063fef8-e648-412e-9ef0-fc3efa9c6168"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4648fe4a-afcb-4e5f-b70f-188de3442ae9"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navi"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fcc260b-b4ee-440c-9152-fdbb6becaf46"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Navi"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08681146-3e53-42c9-9eff-11dac5a2950d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""206879aa-2dcc-4af3-ad22-67a048c9fd37"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00f9f829-8802-49e1-8b4a-284273746cb3"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ToggleMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a2a7107-4f3b-4bc2-a570-bd63aefd2998"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ToggleMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddbfc6c5-938f-4cb0-be74-962cbfbea905"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""OpenSubscreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcf02c4c-31dc-40a4-af4c-c281f1a5276c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""OpenSubscreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Subscreen"",
            ""id"": ""07d40c73-7b30-4651-ac47-57174f6cafe0"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""7a84a19c-f522-4f19-8927-2f7819777c94"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2c926871-da06-4636-b563-ad9ab8eba2a4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""b9e40e40-8629-4d7d-92cc-0e44a91837a5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4e71103c-3a11-4f9f-83c3-246a168c9388"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""59a8e085-f796-440f-8698-044120f0713b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b274fb59-da8c-4013-af7a-8ee7d8d7e711"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fba6377b-8429-4eff-b76c-96ba609a818d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Action = m_Player.FindAction("Action", throwIfNotFound: true);
        m_Player_Sword = m_Player.FindAction("Sword", throwIfNotFound: true);
        m_Player_Shield = m_Player.FindAction("Shield", throwIfNotFound: true);
        m_Player_Item1 = m_Player.FindAction("Item1", throwIfNotFound: true);
        m_Player_Item2 = m_Player.FindAction("Item2", throwIfNotFound: true);
        m_Player_Item3 = m_Player.FindAction("Item3", throwIfNotFound: true);
        m_Player_Navi = m_Player.FindAction("Navi", throwIfNotFound: true);
        m_Player_Target = m_Player.FindAction("Target", throwIfNotFound: true);
        m_Player_ToggleMap = m_Player.FindAction("ToggleMap", throwIfNotFound: true);
        m_Player_OpenSubscreen = m_Player.FindAction("OpenSubscreen", throwIfNotFound: true);
        // Subscreen
        m_Subscreen = asset.FindActionMap("Subscreen", throwIfNotFound: true);
        m_Subscreen_Navigate = m_Subscreen.FindAction("Navigate", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Action;
    private readonly InputAction m_Player_Sword;
    private readonly InputAction m_Player_Shield;
    private readonly InputAction m_Player_Item1;
    private readonly InputAction m_Player_Item2;
    private readonly InputAction m_Player_Item3;
    private readonly InputAction m_Player_Navi;
    private readonly InputAction m_Player_Target;
    private readonly InputAction m_Player_ToggleMap;
    private readonly InputAction m_Player_OpenSubscreen;
    public struct PlayerActions
    {
        private @OoTActions m_Wrapper;
        public PlayerActions(@OoTActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Action => m_Wrapper.m_Player_Action;
        public InputAction @Sword => m_Wrapper.m_Player_Sword;
        public InputAction @Shield => m_Wrapper.m_Player_Shield;
        public InputAction @Item1 => m_Wrapper.m_Player_Item1;
        public InputAction @Item2 => m_Wrapper.m_Player_Item2;
        public InputAction @Item3 => m_Wrapper.m_Player_Item3;
        public InputAction @Navi => m_Wrapper.m_Player_Navi;
        public InputAction @Target => m_Wrapper.m_Player_Target;
        public InputAction @ToggleMap => m_Wrapper.m_Player_ToggleMap;
        public InputAction @OpenSubscreen => m_Wrapper.m_Player_OpenSubscreen;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Action.started += instance.OnAction;
            @Action.performed += instance.OnAction;
            @Action.canceled += instance.OnAction;
            @Sword.started += instance.OnSword;
            @Sword.performed += instance.OnSword;
            @Sword.canceled += instance.OnSword;
            @Shield.started += instance.OnShield;
            @Shield.performed += instance.OnShield;
            @Shield.canceled += instance.OnShield;
            @Item1.started += instance.OnItem1;
            @Item1.performed += instance.OnItem1;
            @Item1.canceled += instance.OnItem1;
            @Item2.started += instance.OnItem2;
            @Item2.performed += instance.OnItem2;
            @Item2.canceled += instance.OnItem2;
            @Item3.started += instance.OnItem3;
            @Item3.performed += instance.OnItem3;
            @Item3.canceled += instance.OnItem3;
            @Navi.started += instance.OnNavi;
            @Navi.performed += instance.OnNavi;
            @Navi.canceled += instance.OnNavi;
            @Target.started += instance.OnTarget;
            @Target.performed += instance.OnTarget;
            @Target.canceled += instance.OnTarget;
            @ToggleMap.started += instance.OnToggleMap;
            @ToggleMap.performed += instance.OnToggleMap;
            @ToggleMap.canceled += instance.OnToggleMap;
            @OpenSubscreen.started += instance.OnOpenSubscreen;
            @OpenSubscreen.performed += instance.OnOpenSubscreen;
            @OpenSubscreen.canceled += instance.OnOpenSubscreen;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Action.started -= instance.OnAction;
            @Action.performed -= instance.OnAction;
            @Action.canceled -= instance.OnAction;
            @Sword.started -= instance.OnSword;
            @Sword.performed -= instance.OnSword;
            @Sword.canceled -= instance.OnSword;
            @Shield.started -= instance.OnShield;
            @Shield.performed -= instance.OnShield;
            @Shield.canceled -= instance.OnShield;
            @Item1.started -= instance.OnItem1;
            @Item1.performed -= instance.OnItem1;
            @Item1.canceled -= instance.OnItem1;
            @Item2.started -= instance.OnItem2;
            @Item2.performed -= instance.OnItem2;
            @Item2.canceled -= instance.OnItem2;
            @Item3.started -= instance.OnItem3;
            @Item3.performed -= instance.OnItem3;
            @Item3.canceled -= instance.OnItem3;
            @Navi.started -= instance.OnNavi;
            @Navi.performed -= instance.OnNavi;
            @Navi.canceled -= instance.OnNavi;
            @Target.started -= instance.OnTarget;
            @Target.performed -= instance.OnTarget;
            @Target.canceled -= instance.OnTarget;
            @ToggleMap.started -= instance.OnToggleMap;
            @ToggleMap.performed -= instance.OnToggleMap;
            @ToggleMap.canceled -= instance.OnToggleMap;
            @OpenSubscreen.started -= instance.OnOpenSubscreen;
            @OpenSubscreen.performed -= instance.OnOpenSubscreen;
            @OpenSubscreen.canceled -= instance.OnOpenSubscreen;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Subscreen
    private readonly InputActionMap m_Subscreen;
    private List<ISubscreenActions> m_SubscreenActionsCallbackInterfaces = new List<ISubscreenActions>();
    private readonly InputAction m_Subscreen_Navigate;
    public struct SubscreenActions
    {
        private @OoTActions m_Wrapper;
        public SubscreenActions(@OoTActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_Subscreen_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_Subscreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SubscreenActions set) { return set.Get(); }
        public void AddCallbacks(ISubscreenActions instance)
        {
            if (instance == null || m_Wrapper.m_SubscreenActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SubscreenActionsCallbackInterfaces.Add(instance);
            @Navigate.started += instance.OnNavigate;
            @Navigate.performed += instance.OnNavigate;
            @Navigate.canceled += instance.OnNavigate;
        }

        private void UnregisterCallbacks(ISubscreenActions instance)
        {
            @Navigate.started -= instance.OnNavigate;
            @Navigate.performed -= instance.OnNavigate;
            @Navigate.canceled -= instance.OnNavigate;
        }

        public void RemoveCallbacks(ISubscreenActions instance)
        {
            if (m_Wrapper.m_SubscreenActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISubscreenActions instance)
        {
            foreach (var item in m_Wrapper.m_SubscreenActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SubscreenActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SubscreenActions @Subscreen => new SubscreenActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnSword(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnItem1(InputAction.CallbackContext context);
        void OnItem2(InputAction.CallbackContext context);
        void OnItem3(InputAction.CallbackContext context);
        void OnNavi(InputAction.CallbackContext context);
        void OnTarget(InputAction.CallbackContext context);
        void OnToggleMap(InputAction.CallbackContext context);
        void OnOpenSubscreen(InputAction.CallbackContext context);
    }
    public interface ISubscreenActions
    {
        void OnNavigate(InputAction.CallbackContext context);
    }
}
