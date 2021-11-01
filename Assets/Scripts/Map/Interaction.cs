using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    private TileMap thisTileMap;

    public Slider scaleSlider, octaveSlider, lacunaritySlider, persistanceSlider, renderDistanceSlider;

    public InputField seedInputField;

    private void Start()
    {
        thisTileMap = GetComponent<TileMap>();
        seedInputField.text = thisTileMap.mapSeed.ToString();
    }

    public void onScaleSliderValueChanged()
    {
        thisTileMap.scale = scaleSlider.value;
    }
    
    public void onOctaveSliderValueChanged()
    {
        int octaveInt = Mathf.RoundToInt(octaveSlider.value);

        thisTileMap.octaves = octaveInt;
        octaveSlider.value = octaveInt;
    }
    public void onLacunaritySliderValueChanged()
    {
        thisTileMap.lacunarity = lacunaritySlider.value;
    }
    public void onPersistanceSliderValueChanged()
    {
        thisTileMap.persistance = persistanceSlider.value;
    }

    public void onRenderDistanceValueChanged()
    {
        int renderDistanceInt = Mathf.RoundToInt(renderDistanceSlider.value);

        thisTileMap.renderDistance = renderDistanceInt;
        renderDistanceSlider.value = renderDistanceInt;
    }

    public void onSeedInputFieldEndEditing()
    {
        thisTileMap.mapSeed = int.Parse(seedInputField.text);
    }
}
