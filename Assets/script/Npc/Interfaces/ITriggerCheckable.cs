public interface ITriggerCheckable
{
    bool isInRange { get; set; }

    void SetInRangeStatus(bool IsInRange);
}
