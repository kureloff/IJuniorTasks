using TMPro;
using UnityEngine;

[RequireComponent(typeof(CounterModel))]
[RequireComponent(typeof(TMP_Text))]
public class CounterView : MonoBehaviour
{
    private TMP_Text _text;
    private CounterModel _counterModel;

    private void Awake()
    {
        _counterModel = GetComponent<CounterModel>();
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _counterModel.ÑountChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _counterModel.ÑountChanged -= ChangeValue;
    }

    private void ChangeValue(int count)
    {
        _text.text = count.ToString();
    }
}
