using UnityEngine;

[System.Serializable]
public class ItemData
{
    public int id;
    public string title;
    public string description;
    public Color backgroundColor = Color.white;
    public Sprite icon;
    
    public ItemData(int id, string title, string description, Color backgroundColor = default)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.backgroundColor = backgroundColor == default ? Color.white : backgroundColor;
    }
}
