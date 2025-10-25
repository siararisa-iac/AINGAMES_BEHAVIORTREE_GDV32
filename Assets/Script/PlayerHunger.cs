using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHunger : MonoBehaviour
{
    [SerializeField]
    private float maxHunger = 100;
    [SerializeField]
    private float decreaseRate = 10f;

    private float hunger;
    public float MaxHunger => maxHunger;


    public delegate void HungerDelegate(float current, float max);
    public static HungerDelegate OnHungerUpdated;

    public float Hunger
    {
        get { return hunger; }
        private set { hunger = Mathf.Clamp(value, 0, maxHunger); }
    }
    //or
    //public float Hunger => Mathf.Clamp(hunger, 0, maxHunger);

    private void Start()
    {
        Hunger = maxHunger;
        OnHungerUpdated += PrintHunger;
        OnHungerUpdated += CheckHunger;
    }

    private void Update()
    {
        Hunger -= Time.deltaTime * decreaseRate;
        OnHungerUpdated.Invoke(Hunger, MaxHunger);
    }

    public void IncreaseHunger(float value)
    {
        Hunger += value;
    }

    private void PrintHunger(float value, float maxValue)
    {
        Debug.Log($"Hunger is: {value}/{maxValue}");
    }

    private void CheckHunger(float current, float max)
    {
        if(current < max / 2)
        {
            Debug.Log("HUNGRY");
        }
    }
}
