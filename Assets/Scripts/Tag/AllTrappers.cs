using System.Collections.Generic;
using UnityEngine;

namespace VideoGenerator.Tag
{
    public class AllTrappers : MonoBehaviour
    {
        public static AllTrappers Instance { get; private set; }

        public List<string> SlowTrappers => m_SlowTrappers;
        [SerializeField] private List<string> m_SlowTrappers = new();

        public List<string> DrillTrappers => m_DrillTrappers;
        [SerializeField] private List<string> m_DrillTrappers = new();

        public List<string> FunkMC => m_FunkMC;
        [SerializeField] private List<string> m_FunkMC = new();

        private void Awake()
        {
            Instance = this;
        }

        public List<string> GetTrapperNames(BeatStyle style)
        {
            switch (style)
            {
                case BeatStyle.Slow:
                    return m_SlowTrappers;
                case BeatStyle.Drill:
                    return m_DrillTrappers;
                case BeatStyle.Funk:
                    return m_FunkMC;
            }

            return null;
        }

        public enum BeatStyle
        {
            Slow,
            Drill,
            Funk
        }
    }
}