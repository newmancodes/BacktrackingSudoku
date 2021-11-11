namespace Blazor.UI.Domain
{
    public class AllCellsSumToTargetConstraint : IConstraint
    {
        private readonly IReadOnlyCollection<Cell> _cells;
        private readonly int _target;

        public AllCellsSumToTargetConstraint(IEnumerable<Cell> cells, int target)
        {
            _cells = cells.ToList().AsReadOnly();
            _target = target;
        }

        public bool IsValid()
        {
            return _cells.All(c => c.Value.HasValue)
                && _cells.Sum(c => c.Value.Value) == _target;
        }
    }
}
