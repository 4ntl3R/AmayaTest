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

        [SerializeField] 
        private Vector3 rotation = Quaternion.identity.eulerAngles;

        public Vector3 Rotation => rotation;

        public string Identifier => _identifier;

        public Sprite Sprite => _sprite;
    }
}