using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public string Name;
    public string Discription;
    public DoorType Type;

    public enum DoorType {
        Monster,
        Class,
        Partner,
        Radiation,
        Trap,
        Other
    }
}
