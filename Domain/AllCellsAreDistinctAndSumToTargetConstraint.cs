namespace Domain;

public class AllCellsAreDistinctAndSumToTargetConstraint : IConstraint
{
    private readonly IReadOnlyCollection<Cell> _cells;
    private readonly int _target;

    public AllCellsAreDistinctAndSumToTargetConstraint(IEnumerable<Cell> cells, int target)
    {
        _cells = cells.ToList().AsReadOnly();
        _target = target;
    }

    public bool IsValid()
    {
        if (_cells.Any(c => !c.Value.HasValue))
        {
            return _cells.Where(c => c.Value.HasValue).Sum(c => c.Value.Value) < _target;
        }

        return _cells.Distinct().Count() == _cells.Count
               && _cells.Sum(c => c.Value.Value) == _target;
    }
}