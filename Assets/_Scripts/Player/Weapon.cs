using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSettings _settings;
    [SerializeField] private Transform _shootPosition;

    private AudioSource _audioSource;
    private float _lastShotTime;
    private bool _canShoot {
        get
        {
            float shotPerSecond = _settings.shotPerSecond;
            return Time.time > (_lastShotTime + 1 / shotPerSecond);
            
        }
    }

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    public bool Shoot()
    {
        if(!_canShoot)
            return false;
        
        Bullet bullet = CreateBullet();
        SetBulletSettings(bullet);
        CreateParticalShoot();
        PlaySoundShot();
        
        _lastShotTime = Time.time;
        return true;

    }

    private Bullet CreateBullet()
    {
        GameObject bullletGO = Instantiate(_settings.prefabBullet, _shootPosition.position, Quaternion.identity);
        return bullletGO.GetComponent<Bullet>();
    }

    private void SetBulletSettings(Bullet bullet)
    {
        SetBulletDirection(bullet);
        bullet.speed = _settings.bulletSpeed;
        bullet.force = _settings.bulletForce;
    }

    private void SetBulletDirection(Bullet bullet)
    {
        Vector3 hitPosition = RaycastUtility.GetRaycastMousePosition();
        Vector3 shotDirection = Vector3.Normalize(hitPosition - _shootPosition.position);
        bullet.direction = shotDirection;
    }

    private void CreateParticalShoot()
    {
        Instantiate(_settings.particalShot, _shootPosition.position, _shootPosition.rotation);
    }

    private void PlaySoundShot()
    {
        _audioSource.PlayOneShot(_settings.soundShot);
    }
}
