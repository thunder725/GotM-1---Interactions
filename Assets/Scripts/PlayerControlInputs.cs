// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControlInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlInputs"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""57b6df8f-03f1-4c55-ab0d-81d8301818a3"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3b5f8825-9cd1-4932-b326-f8b64f5e7559"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpecialOne"",
                    ""type"": ""Button"",
                    ""id"": ""1a19623b-a679-4d20-9e19-bcbffca68eb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RestoreShockwave"",
                    ""type"": ""Button"",
                    ""id"": ""591cd6f6-d4d5-4998-b05b-fd2a1124b92a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""ab8c1b11-5ee7-4d1c-bc99-c1bb3c433328"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Sticks"",
                    ""id"": ""5d6d33ff-3766-4581-8995-c8e88dff15b1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f291a150-98ae-43f0-8bc6-30649dcad477"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3d8ddaae-d714-4a13-a1ac-72a1db997e23"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""762ab344-9cff-4529-a189-a72c0e5062d8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7174df19-551a-4e4a-b3d2-2dab723352f2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ZQSD"",
                    ""id"": ""774a8175-1736-4f40-8937-01a6390f950d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""019cf0c8-e1d6-4693-876c-681075135d1e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""35ff9754-c497-46f7-aae3-dcea73dcc970"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""59403a31-ecf7-4170-9287-d7319da98015"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""baa06a52-542d-4afa-87eb-b65f16800859"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""66f77f99-421b-49e8-80ba-c00f785675ff"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b908348-573c-4b9b-a08c-d68ca0c2b150"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0580e6aa-27f9-4d2c-9665-5f9b38b3af33"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestoreShockwave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f8c82ea-67d2-4739-a87d-c5bfbeb75795"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestoreShockwave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bbb5266-968a-4858-98d3-a58608e99f3a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b9f2ba2-f9ec-404e-b478-4d1603691dd8"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Movement = m_Default.FindAction("Movement", throwIfNotFound: true);
        m_Default_SpecialOne = m_Default.FindAction("SpecialOne", throwIfNotFound: true);
        m_Default_RestoreShockwave = m_Default.FindAction("RestoreShockwave", throwIfNotFound: true);
        m_Default_Restart = m_Default.FindAction("Restart", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_Movement;
    private readonly InputAction m_Default_SpecialOne;
    private readonly InputAction m_Default_RestoreShockwave;
    private readonly InputAction m_Default_Restart;
    public struct DefaultActions
    {
        private @PlayerControlInputs m_Wrapper;
        public DefaultActions(@PlayerControlInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Default_Movement;
        public InputAction @SpecialOne => m_Wrapper.m_Default_SpecialOne;
        public InputAction @RestoreShockwave => m_Wrapper.m_Default_RestoreShockwave;
        public InputAction @Restart => m_Wrapper.m_Default_Restart;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @SpecialOne.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSpecialOne;
                @SpecialOne.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSpecialOne;
                @SpecialOne.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSpecialOne;
                @RestoreShockwave.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRestoreShockwave;
                @RestoreShockwave.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRestoreShockwave;
                @RestoreShockwave.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRestoreShockwave;
                @Restart.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @SpecialOne.started += instance.OnSpecialOne;
                @SpecialOne.performed += instance.OnSpecialOne;
                @SpecialOne.canceled += instance.OnSpecialOne;
                @RestoreShockwave.started += instance.OnRestoreShockwave;
                @RestoreShockwave.performed += instance.OnRestoreShockwave;
                @RestoreShockwave.canceled += instance.OnRestoreShockwave;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSpecialOne(InputAction.CallbackContext context);
        void OnRestoreShockwave(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
}
