using UnityEngine;
using System.Collections;
using System;


[Serializable]
public class BarcodeAPIResult
{
    public string code;
    public Product product;
}

[Serializable]
public class Product
{
    public string product_name_en;
    public string product_name;

    public string[] allergens_tags;
    public string nutriscore_grade;

    public Ingrediant[] ingredients;
    public string[] ingredients_analysis_tags;
}

[Serializable]
public class Ingrediant
{
    public string text;
    public string vegetarian;
    public string vegan;
    public float percent_estimate;
}
