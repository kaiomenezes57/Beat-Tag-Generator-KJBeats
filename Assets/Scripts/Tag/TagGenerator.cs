using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace VideoGenerator.Tag
{
    public class TagGenerator : MonoBehaviour
    {
        [SerializeField] TMPro.TMP_InputField tagInput;
        [SerializeField] private TMPro.TMP_Dropdown styleSelector;
        [SerializeField] private Button generateTagButton;
        private AllTrappers.BeatStyle style;

        private void Start()
        {
            generateTagButton.onClick.AddListener(GenerateTags);
            styleSelector.onValueChanged.AddListener((v) => ChangeStyle(v));
        }

        private void ChangeStyle(int value)
        {
            AllTrappers.BeatStyle dt = (AllTrappers.BeatStyle)value;
            style = dt;
        }

        private void GenerateTags()
        {
            string str = null;
            List<string> foundedTags = new();

            if (!string.IsNullOrEmpty(tagInput.text))
            {
                foundedTags = tagInput.text.Split(',').ToList();
                str = CreateTagsStructure(foundedTags, "TAGS PARA VIDEO");
            }

            str = SetFinalVisual(str, foundedTags);
            Debug.Log(NameGenerator.GenerateTitle());
            CreateAndWriteFile(str);
        }

        private string SetFinalVisual(string str, List<string> baseList)
        {
            str = str.Remove(str.Length - 1);
            str += "\n\n" + PickAdditionalNames(baseList);
            return str.Remove(str.Length - 1);
        }

        private string PickAdditionalNames(List<string> baseList)
        {
            var list = AllTrappers.Instance.GetTrapperNames(style);
            list.RemoveAll(n => baseList.Contains(n));

            return CreateTagsStructure(list, "TAGS COMPLEMENTARES");
        }

        private string CreateTagsStructure(List<string> tags, string title)
        {
            string str = $"{title}:\n";

            for (int i = 0; i < tags.Count; i++)
            {
                str += $"{tags[i]} type beat,beat estilo {tags[i]},{tags[i]} instrumental,";
            }

            return str;
        }

        private void CreateAndWriteFile(string str)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var fileName = "tags.txt";
            var fileNamePath = Path.Combine(path, fileName);

            using StreamWriter writer = File.CreateText(fileNamePath);
            writer.Write(str);
        }
    }
}