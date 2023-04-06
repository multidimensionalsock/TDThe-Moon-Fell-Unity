using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TextData", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class TextScriptable : ScriptableObject
{
	public String[] speech;
}
