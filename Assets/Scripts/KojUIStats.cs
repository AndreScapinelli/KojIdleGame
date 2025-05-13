using UnityEngine;
using UnityEngine.UI;

public class KojUIStats : MonoBehaviour
{
    [SerializeField] private Image kojDisplay;
    [SerializeField] private Sprite kojFullLife;
    [SerializeField] private Sprite kojLowLife;
    [Header("Referências das Barras de Status")]
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image hungerBar;
    [SerializeField] private Image cigaretteBar;
    [SerializeField] private Image selfLoveBar;
    [SerializeField] private Image bathroomBar;
    [SerializeField] private Image energyBar;

    [Header("Referência ao Koj")]
    [SerializeField] private Koj koj;

    private void Update()
    {
        if (koj == null) return;

        lifeBar.fillAmount = koj.GetLife() / 100f;
        hungerBar.fillAmount = koj.GetHunger() / 100f;
        cigaretteBar.fillAmount = koj.GetCigaretteAddiction() / 100f;
        selfLoveBar.fillAmount = koj.GetSelfLove() / 100f;
        bathroomBar.fillAmount = koj.GetBathroomNeed() / 100f;
        energyBar.fillAmount = koj.GetEnergy() / 100f;


        // Atualiza a imagem do Koj com base na vida
        if (koj.GetLife() > 50)
        {
            kojDisplay.sprite = kojFullLife;
        }
        else
        {
            kojDisplay.sprite = kojLowLife;
        }
    }
}