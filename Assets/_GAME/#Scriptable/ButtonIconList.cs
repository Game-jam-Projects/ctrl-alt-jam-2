using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonIconList", menuName = "_Scriptable/Button Icon List", order = 1)]
public class ButtonIconList : ScriptableObject
{
    [System.Serializable]
    public class ButtonIcon
    {
        public string name;
        public string buttonName;
        public Sprite keyboardIcon;
        public Sprite ps4Icon;
        public Sprite xboxIcon;
        public Sprite switchIcon;
    }

    public List<ButtonIcon> buttonIcons;
}
