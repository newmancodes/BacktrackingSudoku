namespace Blazor.UI.Domain
{
    public class Column
    {
        private readonly Cell[] _cells;

        public Column()
        {
            _cells = Enumerable.Range(0, 9).Select(_ => new Cell()).ToArray();
        }

        public Column(Cell[] cells)
        {
            _cells = cells;
        }

        public Cell this[int index]
        {
            get => _cells[index];
        }

        public class Builder
        {
            private readonly Cell[] _cells = Enumerable.Range(0, 9).Select(_ => new Cell()).ToArray();

            public Builder WithCell(int index, int cellValue)
            {
                _cells[index] = new Cell(cellValue);
                return this;
            }

            public Column Build()
            {
                return new Column(_cells);
            }
        }
    }
}
