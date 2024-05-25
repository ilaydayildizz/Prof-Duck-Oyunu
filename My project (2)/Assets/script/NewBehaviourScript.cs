using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshPro problemText;
    public TextMeshPro resultText;
    public TextMeshPro correctResultText;

    private Coroutine currentCoroutine;

    void Start()
    {
        // Ýlk problemi oluþtur ve baþlat
        GenerateAndDisplayProblem();
    }

    void GenerateProblem()
    {
        // Rastgele iki sayý oluþtur
        int number1 = Random.Range(1, 101);
        int number2 = Random.Range(1, 101);

        // Rastgele bir iþlem seç
        string operation;
        string resultString = "";
        string correctResultString = "";
        int operatorIndex = Random.Range(0, 4);

        switch (operatorIndex)
        {
            case 0: // Toplama
                operation = "+";
                int sum = number1 + number2;
                resultString = sum.ToString();
                correctResultString = (sum + 1).ToString();
                break;
            case 1: // Çýkarma
                operation = "-";
                int difference = number1 - number2;
                resultString = difference.ToString();
                correctResultString = (difference + 1).ToString();
                break;
            case 2: // Çarpma
                operation = "*";
                int product = number1 * number2;
                resultString = product.ToString();
                correctResultString = (product + 1).ToString();
                break;
            case 3: // Bölme
                operation = "/";
                if (number2 == 0)
                {
                    number2 = 1; // Sýfýra bölmeyi önlemek için
                }
                float quotient = (float)number1 / number2;
                resultString = quotient.ToString("F2"); // Ýlk iki basamaðý al
                correctResultString = (quotient + 1).ToString("F2");
                break;
            default:
                operation = "+";
                int defaultSum = number1 + number2;
                resultString = defaultSum.ToString();
                correctResultString = (defaultSum + 1).ToString();
                break;
        }

        // Problem metnini oluþtur
        string problem = $"{number1} {operation} {number2} = ?";

        // TextMeshPro'ya yazdýr
        problemText.text = problem;
        resultText.text = resultString;
        correctResultText.text = correctResultString;

        // Debug.Log ile konsola yazdýrabilirsiniz
        Debug.Log("Problem: " + problem);
        Debug.Log("Result: " + resultString);
        Debug.Log("Correct Result: " + correctResultString);
    }

    IEnumerator DisplayProblem()
    {
        // Problemi göster
        problemText.gameObject.SetActive(true);
        resultText.gameObject.SetActive(true);
        correctResultText.gameObject.SetActive(true);

        // 5 saniye bekle
        yield return new WaitForSeconds(5);

        // Problemi gizle
        problemText.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        correctResultText.gameObject.SetActive(false);
    }

    void GenerateAndDisplayProblem()
    {
        GenerateProblem();

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(DisplayProblem());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food"))
        {
            // Yeni problem oluþtur ve göster
            GenerateAndDisplayProblem();
        }
    }
}