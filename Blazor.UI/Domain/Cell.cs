namespace Blazor.UI.Domain
{
    public class Cell
    {
        private int? _value;
        private ValueType _valueType;

        public int? Value => _value;

        public ValueType ValueType => _valueType;

        public Cell()
        {
            _value = default;
            _valueType = ValueType.Unknown;
        }

        public Cell(int value)
        {
            _value = value;
            _valueType = ValueType.Fixed;
        }

        public void Guess(int value)
        {
            if (_valueType != ValueType.Fixed)
            {
                _value = value;
                _valueType = ValueType.Guess;
            }
        }

        public void Clear()
        {
            if (_valueType != ValueType.Fixed)
            {
                _value = default;
                _valueType = ValueType.Unknown;
            }
        }
    }
}
