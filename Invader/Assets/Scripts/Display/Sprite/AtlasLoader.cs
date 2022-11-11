using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AtlasLoader
{
    private static Dictionary<string, Sprite> SpriteDictionary = new Dictionary<string, Sprite>();

    public static void LoadSprites(string baseName)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(baseName);
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("BaseSpriteAtlas " + baseName + " does not exist!");
            return;
        }

        foreach (Sprite sprite in sprites)
        {
            if (!SpriteDictionary.ContainsKey(sprite.name))
            {
                SpriteDictionary.Add(sprite.name, sprite);
            }
        }
    }

    public static Sprite GetSprite(string spriteName)
    {
        if (!SpriteDictionary.TryGetValue(spriteName, out Sprite sprite))
        {
            Debug.LogError("Sprite " + spriteName + " does not exist!");
            return null;
        }

        return sprite;
    }
}
