using UnityEngine;

namespace AmayaTest.Data
{
    [System.Serializable]
    public sealed class CardData
    {
        [SerializeField] 
        private string _identifier;

        [SerializeField] 
        private Sprite _sprite;

        public string Identifier => _identifier;

        public Sprite Sprite => _sprite;
    }
}