using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataMusuh", menuName = "ScriptableObjects/DataMusuh", order = 1)]

public class MusuhData : ScriptableObject
{
    public float InitialHealth, CdBasicAttack, CdSkill1, CdSkill2, CdSkill3;
}
