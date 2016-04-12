using UnityEngine;

public class Weapon : MonoBehaviour {
    public bool InTwoArms;
    public WeaponType Type;
    public bool FireDamage;

    public enum WeaponType {
        No,
        Energy,
        Fire,
        Steel,
        Light
    }

}
