using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class Life : MonoBehaviour
{
    public float amount;
    public UnityEvent onDeath;

    public Slider HealthBar;

    public GameObject bloodEffect;

    float elapsedTime = 0f; // 누적 경과 시간
    float fadedTime = 0.5f; // 총 소요 시간

    private void Start()
    {
        amount = 100f;
        HealthBar.maxValue = amount;
        HealthBar.value = amount;

        bloodEffect = GameObject.Find("Blood");
        bloodEffect.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    void Update()
    {
        HealthBar.value = amount;

        if (amount <= 0f)
        {
            onDeath.Invoke();
            //Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            elapsedTime = 0f;
            StartCoroutine(CoFadeIn());
        }

    }

    IEnumerator CoFadeIn()
    {

        while (elapsedTime <= fadedTime)
        {
            bloodEffect.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(1f, 0f, elapsedTime / fadedTime));

            elapsedTime += Time.deltaTime;
            Debug.Log("Fade In 중...");
            yield return null;
        }
        Debug.Log("Fade In 끝");
        bloodEffect.GetComponent<CanvasRenderer>().SetAlpha(0f);
        yield break;
    }

    IEnumerator CoFadeOut()
    {
        float elapsedTime = 0f; // 누적 경과 시간
        float fadedTime = 0.5f; // 총 소요 시간

        while (elapsedTime <= fadedTime)
        {
            bloodEffect.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, elapsedTime / fadedTime));

            elapsedTime += Time.deltaTime;
            Debug.Log("Fade Out 중...");
            yield return null;
        }

        Debug.Log("Fade Out 끝");
        yield break;
    }
}