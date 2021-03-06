//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/New Controls.inputactions
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

public partial class @NewControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Rolling"",
            ""id"": ""f3f695aa-4e32-4940-89d5-80a505ded9c7"",
            ""actions"": [
                {
                    ""name"": ""UpDown"",
                    ""type"": ""Button"",
                    ""id"": ""fa6b00e3-f44e-41cf-bbe7-61cacc0b62e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftRight"",
                    ""type"": ""Button"",
                    ""id"": ""3da5636d-b35d-489e-8ee9-6aabb2c62506"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WS"",
                    ""id"": ""f471e1f8-7458-4bea-9d5b-8e2ccf3451cd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9d9eb5c6-1b8c-4b9e-bbbc-ad8535951a4f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3852f969-3732-4a72-957e-d9c5d3f2238a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""cd375da4-aef4-49db-b524-b803be08c45b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1e964ee8-7ad5-4c45-a6f6-50de7328abd7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""770962d8-3422-4ed0-b7ed-1ea906d205fc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""5220387e-6cdf-4c49-a4ab-65b1b14b5958"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7bcb70c0-edb8-4de8-bf3c-3d690f8d6099"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bfb8ab03-99c9-47bb-bd55-05035c5a9dd9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""09c79d2b-0c8e-4ebd-826b-9225de95e6d3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cf6115dd-dab2-402c-b7ce-a9b24d9fefdb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0f0b3f09-1b3e-4f91-84b4-af4f22aa677d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Rolling
        m_Rolling = asset.FindActionMap("Rolling", throwIfNotFound: true);
        m_Rolling_UpDown = m_Rolling.FindAction("UpDown", throwIfNotFound: true);
        m_Rolling_LeftRight = m_Rolling.FindAction("LeftRight", throwIfNotFound: true);
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

    // Rolling
    private readonly InputActionMap m_Rolling;
    private IRollingActions m_RollingActionsCallbackInterface;
    private readonly InputAction m_Rolling_UpDown;
    private readonly InputAction m_Rolling_LeftRight;
    public struct RollingActions
    {
        private @NewControls m_Wrapper;
        public RollingActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpDown => m_Wrapper.m_Rolling_UpDown;
        public InputAction @LeftRight => m_Wrapper.m_Rolling_LeftRight;
        public InputActionMap Get() { return m_Wrapper.m_Rolling; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RollingActions set) { return set.Get(); }
        public void SetCallbacks(IRollingActions instance)
        {
            if (m_Wrapper.m_RollingActionsCallbackInterface != null)
            {
                @UpDown.started -= m_Wrapper.m_RollingActionsCallbackInterface.OnUpDown;
                @UpDown.performed -= m_Wrapper.m_RollingActionsCallbackInterface.OnUpDown;
                @UpDown.canceled -= m_Wrapper.m_RollingActionsCallbackInterface.OnUpDown;
                @LeftRight.started -= m_Wrapper.m_RollingActionsCallbackInterface.OnLeftRight;
                @LeftRight.performed -= m_Wrapper.m_RollingActionsCallbackInterface.OnLeftRight;
                @LeftRight.canceled -= m_Wrapper.m_RollingActionsCallbackInterface.OnLeftRight;
            }
            m_Wrapper.m_RollingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpDown.started += instance.OnUpDown;
                @UpDown.performed += instance.OnUpDown;
                @UpDown.canceled += instance.OnUpDown;
                @LeftRight.started += instance.OnLeftRight;
                @LeftRight.performed += instance.OnLeftRight;
                @LeftRight.canceled += instance.OnLeftRight;
            }
        }
    }
    public RollingActions @Rolling => new RollingActions(this);
    public interface IRollingActions
    {
        void OnUpDown(InputAction.CallbackContext context);
        void OnLeftRight(InputAction.CallbackContext context);
    }
}
