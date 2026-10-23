public class Status
{
    public StatusData data;
    public StatusEffectManager owner;

    public int stacks;
    public int duration;

    public Status(
        StatusData data,
        StatusEffectManager owner,
        int stacks,
        int duration)
    {
        this.data = data;
        this.owner = owner;
        this.stacks = stacks;
        this.duration = duration;
    }
}