namespace Domain;

public class AllSubsequentCellsSumToFirstCellConstraint : IConstraint
{
    private readonly IReadOnlyCollection<Cell> _cells;
    private readonly int _target;

    public AllSubsequentCellsSumToFirstCellConstraint(IEnumerable<Cell> cells, int target)
    {
        _cells = cells.ToList().AsReadOnly();
        _target = target;
    }

    public bool IsValid()
    {
        if (!_cells.First().Value.HasValue)
        {
            return true;
        }

        if (_cells.Any(c => !c.Value.HasValue))
        {
            return _cells.Skip(1).Where(c => c.Value.HasValue).Sum(c => c.Value.Value) < _cells.First().Value.Value;
        }

        return _cells.Skip(1).Sum(c => c.Value.Value) == _cells.First().Value.Value;
    }
}