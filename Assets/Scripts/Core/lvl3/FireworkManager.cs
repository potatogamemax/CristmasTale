using System.Collections;
using UnityEngine;

public class FireworkManager : MonoBehaviour
{
    public Firework[] fireworks;
    public float delayBetween = 1f;

    // ÇÀÏÓÑÊÀÅÒÑß ÂĞÓ×ÍÓŞ
    public IEnumerator StartPhase()
    {
        yield return StartCoroutine(PlayAll());
    }

    IEnumerator PlayAll()
    {
        for (int i = 0; i < fireworks.Length; i++)
        {
            yield return StartCoroutine(fireworks[i].Play());
            yield return new WaitForSeconds(delayBetween);
        }
    }
}