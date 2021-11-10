namespace Blazor.UI.Domain
{
    public class Board
    {
        private readonly Column[] _columns;

        public Board()
        {
            _columns = Enumerable.Range(0, 9).Select(_ => new Column()).ToArray();
        }

        public Board(Column[] columns)
        {
            _columns = columns;
        }

        public IEnumerable<IEnumerable<Cell>> Rows
        {
            get
            {
                for (var rowIndex = 0; rowIndex < 9; rowIndex++)
                {
                    yield return Enumerable.Range(0, 9).Select(i => _columns[i][rowIndex]);
                }
            }
        }

        public class Builder
        {
            private readonly Column[] _columns = Enumerable.Range(0, 9).Select(_ => new Column()).ToArray();

            public Builder WithColumn(int index, Column column)
            {
                _columns[index] = column;
                return this;
            }

            public Board Build()
            {
                return new Board(_columns);
            }
        }
    }
}
