using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VideoGenerator.Tag
{
    public static class NameGenerator
    {
        public static string GenerateTitle()
        {
            string s = null;
            
            System.Random random = new();
            Type type = typeof(Words);
            Array values = type.GetEnumValues();

            for (int i = 0; i < 1; ++i)
            {
                int index = random.Next(values.Length);
                Words value = (Words)values.GetValue(index);
                s += $"{value} {GenerateArticle()} ";
            }

            return s;
        }
        
        public static string GenerateArticle()
        {
            string s = null;

            System.Random random = new();
            Type type = typeof(Articles);
            Array values = type.GetEnumValues();

            for (int i = 0; i < 1; ++i)
            {
                int index = random.Next(values.Length);
                Articles value = (Articles)values.GetValue(index);
                s = $"{value}";
            }

            return s;
        }
    }

    public enum Articles
    {
        deTerror2D,
        deTerror3D,
        deRpg2D,
        deRpg3D,
        deAcao2D,
        deAcao3D,
        deSimulador2D,
        deSimulador3D,
        deAventura2D,
        deAventura3D,
        comMultiplayer2D,
        comMultiplayer3D
    }

    public enum Words
    {
        nada
    }
}