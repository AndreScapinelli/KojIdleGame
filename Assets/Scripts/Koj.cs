using UnityEngine;

public class Koj : MonoBehaviour
{
    [Header("Character Stats")]
    [SerializeField][Range(0, 100)] private float life = 100f;
    [SerializeField][Range(0, 100)] private float hunger = 0f;
    [SerializeField][Range(0, 100)] private float cigaretteAddiction = 0f;
    [SerializeField][Range(0, 100)] private float selfLove = 100f;
    [SerializeField][Range(0, 100)] private float bathroomNeed = 0f;
    [SerializeField][Range(0, 100)] private float energy = 100f;

    [Header("Stat Change Rates")]
    [SerializeField] private float hungerIncreaseRate = 2f;
    [SerializeField] private float addictionIncreaseRate = 1f;
    [SerializeField] private float bathroomIncreaseRate = 3f;
    [SerializeField] private float energyDecreaseRate = 1.5f;

    [Header("Action Settings")]
    [SerializeField] private float eatHungerReduction = 30f;
    [SerializeField] private float smokeAddictionReduction = 25f;
    [SerializeField] private float bathroomReduction = 100f;
    [SerializeField] private float energyIncreaseEat = 10f;
    [SerializeField] private float selfLoveDecreaseSmoke = 5f;

    [Header("Economy")]
    [SerializeField] private float money = 0f;

    private void Update()
    {
        hunger = Mathf.Clamp(hunger + hungerIncreaseRate * Time.deltaTime, 0, 100);
        cigaretteAddiction = Mathf.Clamp(cigaretteAddiction + addictionIncreaseRate * Time.deltaTime, 0, 100);
        bathroomNeed = Mathf.Clamp(bathroomNeed + bathroomIncreaseRate * Time.deltaTime, 0, 100);
        energy = Mathf.Clamp(energy - energyDecreaseRate * Time.deltaTime, 0, 100);

        // Consequências de status críticos
        if (hunger >= 100 || cigaretteAddiction >= 100 || bathroomNeed >= 100)
        {
            life = Mathf.Clamp(life - 5f * Time.deltaTime, 0, 100);
        }

        CheckGameOver();
    }

    public void Do_Eat()
    {
        hunger = Mathf.Clamp(hunger - eatHungerReduction, 0, 100);
        energy = Mathf.Clamp(energy + energyIncreaseEat, 0, 100);

        Debug.Log($"Koj comeu! Fome atual: {hunger} | Energia atual: {energy} | Vida atual: {life}");
    }

    public void Do_Smoke()
    {
        cigaretteAddiction = Mathf.Clamp(cigaretteAddiction - smokeAddictionReduction, 0, 100);
        selfLove = Mathf.Clamp(selfLove - selfLoveDecreaseSmoke, 0, 100);

        Debug.Log($"Koj fumou um cigarro! Vício atual: {cigaretteAddiction}");
    }

    public void Do_GoToBathroom()
    {
        bathroomNeed = Mathf.Clamp(bathroomNeed - bathroomReduction, 0, 100);

        Debug.Log($"Koj foi ao banheiro! Necessidade atual: {bathroomNeed}");
    }

    public void Do_Masturbation()
    {
        selfLove = Mathf.Clamp(selfLove + 10f, 0, 100);
        energy = Mathf.Clamp(energy - 5f, 0, 100);

        Debug.Log($"Koj se masturbou! Auto amor atual: {selfLove}");
    }

    public void Do_Sleep()
    {
        energy = Mathf.Clamp(energy + 50f, 0, 100);
        hunger = Mathf.Clamp(hunger + 10f, 0, 100);
        bathroomNeed = Mathf.Clamp(bathroomNeed + 5f, 0, 100);
        selfLove = Mathf.Clamp(selfLove + 5f, 0, 100);

        Debug.Log($"Koj dormiu! Energia atual: {energy} | Fome atual: {hunger} | Necessidade de banheiro atual: {bathroomNeed} | Auto amor atual: {selfLove}");
    }

    public void PlayGame()
    {
        float earned = Random.Range(10f, 50f);
        money += earned;
    }


    private void CheckGameOver()
    {
        if (life <= 0)
        {
            Debug.Log("Game Over: Koj morreu!");
            // Lógica de fim de jogo pode ser implementada aqui
        }
    }

    // Getters para acessar status externamente, se necessário
    public float GetLife() => life;
    public float GetHunger() => hunger;
    public float GetCigaretteAddiction() => cigaretteAddiction;
    public float GetSelfLove() => selfLove;
    public float GetBathroomNeed() => bathroomNeed;
    public float GetEnergy() => energy;
    public float GetMoney() => money;
}