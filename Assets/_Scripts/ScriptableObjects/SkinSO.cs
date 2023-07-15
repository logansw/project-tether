using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "ScriptableObjects/SkinSO", order = 1)]
public class SkinSO : ScriptableObject
{
    public string Name;
    public Sprite Body;
    public Sprite LeftHand;
    public Sprite RightHand;
}
