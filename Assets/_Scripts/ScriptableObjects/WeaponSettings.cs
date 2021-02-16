using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSettings", menuName = "ScriptableObjects/Weapon Settings", order = 1)]
public class WeaponSettings : ScriptableObject
{
    public GameObject prefabBullet;
    public GameObject particalShot;
    public AudioClip soundShot;
    public float bulletSpeed;
    public float bulletForce;
    public float shotPerSecond;
}
