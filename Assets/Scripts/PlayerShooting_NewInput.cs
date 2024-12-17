using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerShooting_NewInput : MonoBehaviour
{
    public bool GameIsNotStarted;

    public GameObject prefab;
    public GameObject shootPoint;
    public VisualEffect PlayerShootEffect;

    private bool GameIsPaused;

    public AudioSource audioSrc;
    public AudioClip laserSound;

    private void Start()
    {
        GameIsPaused = GetComponent<Pause>().GameIsPaused;
    }

    public void OnFire(InputValue value)
    {
        GameIsPaused = GetComponent<Pause>().GameIsPaused;
        if (value.isPressed && !GameIsPaused)
        {

            audioSrc.PlayOneShot(laserSound);

            GameObject clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            PlayerShootEffect.Play();
        }
    }
}