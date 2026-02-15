public interface ITriggerCheckable
{
    bool IsChasing { get; set; }
    bool IsColliding { get; set; }

    void SetInRangeStatus(bool isChasing);
    void SetCollidingStatus(bool isColliding);
}
