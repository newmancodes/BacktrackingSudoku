namespace Blazor.UI.Domain
{
    public class EachDigitRepresentedOnceConstraint : IConstraint
    {
        private readonly IReadOnlyCollection<Cell> _cells;

        public EachDigitRepresentedOnceConstraint(IEnumerable<Cell> cells)
        {
            _cells = cells.ToList().AsReadOnly();
        }

        public bool IsValid()
        {
            return _cells.Where(c => c.Value.HasValue).GroupBy(c => c.Value.Value).All(g => g.Count() == 1);
        }
    }
}
